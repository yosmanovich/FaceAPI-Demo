using FaceAPI_Demo.Properties;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace FaceAPI_Demo
{
    public partial class frmMain : Form
    {
        private const string PERSON_GROUP_NAME = "FaceAPI-Demo";
        private readonly FaceAPI.FaceAPI _faceAPI;
        private string? _currentImageFile;
        private string ?_currentPersonGroupID;
        private Dictionary<int, DetectedFace>? _detectedFaces;

        public frmMain()
        {
            InitializeComponent();
            _faceAPI = new FaceAPI.FaceAPI(Settings.Default.ENDPOINT, Settings.Default.SUBSCRIPTION_KEY);
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            if (dlgOpenImage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pbxCandidateImage.Load(dlgOpenImage.FileName);
                    _currentImageFile = dlgOpenImage.FileName;
                    _detectedFaces = null;
                    pbxCandidateImage.Refresh();
                }
                catch { }
            }
        }

        private async void btnDetectFace_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentImageFile))
            {
                List<FaceAttributeType> attributes = new List<FaceAttributeType>();
                if (cbxAccessories.Checked) attributes.Add(FaceAttributeType.Accessories);
                if (cbxAge.Checked) attributes.Add(FaceAttributeType.Age);
                if (cbxBlur.Checked) attributes.Add(FaceAttributeType.Blur);
                if (cbxEmotion.Checked) attributes.Add(FaceAttributeType.Emotion);
                if (cbxExposure.Checked) attributes.Add(FaceAttributeType.Exposure);
                if (cbxFacialHair.Checked) attributes.Add(FaceAttributeType.FacialHair);
                if (cbxGender.Checked) attributes.Add(FaceAttributeType.Gender);
                if (cbxGlasses.Checked) attributes.Add(FaceAttributeType.Glasses);
                if (cbxHair.Checked) attributes.Add(FaceAttributeType.Hair);
                if (cbxHeadPose.Checked) attributes.Add(FaceAttributeType.HeadPose);
                if (cbxMakeup.Checked) attributes.Add(FaceAttributeType.Makeup);
                if (cbxMask.Checked) attributes.Add(FaceAttributeType.Mask);
                if (cbxNoise.Checked) attributes.Add(FaceAttributeType.Noise);
                if (cbxOcclusion.Checked) attributes.Add(FaceAttributeType.Occlusion);
                if (cbxQualityForRecognition.Checked) attributes.Add(FaceAttributeType.QualityForRecognition);
                if (cbxSmile.Checked) attributes.Add(FaceAttributeType.Smile);

                try
                {
                    var detectedFaces = await _faceAPI.DetectFaceRecognize(File.ReadAllBytes(_currentImageFile), attributes);
                    _detectedFaces = detectedFaces.Select((s, i) => new { s, i }).ToDictionary(x => x.i, x => x.s);
                    pbxCandidateImage.Refresh();
                    
                    StringBuilder sb = new StringBuilder();
                    foreach (var detectedfaceKey in _detectedFaces.Keys)
                    {
                        var detectedface = _detectedFaces[detectedfaceKey];
                        sb.AppendLine($"Face {detectedfaceKey + 1} Detected at Location:Left:{detectedface.FaceRectangle.Left}, Top:{detectedface.FaceRectangle.Top}, Width:{detectedface.FaceRectangle.Width}, Height:{detectedface.FaceRectangle.Height}");
                        if (detectedface.FaceAttributes.Accessories != null)
                        {
                            sb.AppendLine($"Accessories:");
                            foreach (var acc in detectedface.FaceAttributes.Accessories)
                            {
                                sb.AppendLine($"Accessories:");
                                sb.AppendLine($"           Type:{acc.Type}");
                                sb.AppendLine($"           Confidence:{acc.Confidence}");
                            }
                        }
                        if (detectedface.FaceAttributes.Age != null) { }
                        if (detectedface.FaceAttributes.Blur != null)
                        {
                            sb.AppendLine($"Blur:");
                            sb.AppendLine($"           Level:{detectedface.FaceAttributes.Blur.BlurLevel}");
                            sb.AppendLine($"           Value:{detectedface.FaceAttributes.Blur.Value}");
                        }
                        if (detectedface.FaceAttributes.Emotion != null) { }
                        if (detectedface.FaceAttributes.Exposure != null)
                        {
                            sb.AppendLine($"Exposure:");
                            sb.AppendLine($"           Level:{detectedface.FaceAttributes.Exposure.ExposureLevel}");
                            sb.AppendLine($"           Value:{detectedface.FaceAttributes.Exposure.Value}");
                        }
                        if (detectedface.FaceAttributes.FacialHair != null) { }
                        if (detectedface.FaceAttributes.Gender != null) { }
                        if (detectedface.FaceAttributes.Glasses != null)
                        {
                            sb.Append($"Glasses: ");
                            if (detectedface.FaceAttributes.Glasses.Equals("NoGlasses")) sb.AppendLine("None");
                            if (detectedface.FaceAttributes.Glasses.Equals("ReadingGlasses")) sb.AppendLine("Reading Glasses");
                            if (detectedface.FaceAttributes.Glasses.Equals("Sunglasses")) sb.AppendLine("Sunglasses");
                            if (detectedface.FaceAttributes.Glasses.Equals("Swimming Goggles")) sb.AppendLine("Swimming Goggles");
                        }

                        if (detectedface.FaceAttributes.Hair != null) { }
                        if (detectedface.FaceAttributes.HeadPose != null)
                        {
                            sb.AppendLine($"Head Pose:");
                            sb.AppendLine($"           Pitch:{detectedface.FaceAttributes.HeadPose.Pitch}");
                            sb.AppendLine($"           Roll:{detectedface.FaceAttributes.HeadPose.Roll}");
                            sb.AppendLine($"           Yaw:{detectedface.FaceAttributes.HeadPose.Yaw}");
                        }
                        if (detectedface.FaceAttributes.Makeup != null) { }
                        if (detectedface.FaceAttributes.Mask != null) { }
                        if (detectedface.FaceAttributes.Noise != null)
                        {
                            sb.AppendLine($"Noise:");
                            sb.AppendLine($"           Level:{detectedface.FaceAttributes.Noise.NoiseLevel}");
                            sb.AppendLine($"           Value:{detectedface.FaceAttributes.Noise.Value}");
                        }
                        if (detectedface.FaceAttributes.Occlusion != null)
                        {
                            sb.AppendLine($"Occlusion:");
                            if (detectedface.FaceAttributes.Occlusion.EyeOccluded) sb.AppendLine($"Eyes occluded");
                            if (detectedface.FaceAttributes.Occlusion.ForeheadOccluded) sb.AppendLine($"Forehead occluded");
                            if (detectedface.FaceAttributes.Occlusion.MouthOccluded) sb.AppendLine($"Mouth occluded");
                        }
                        if (detectedface.FaceAttributes.QualityForRecognition != null) { sb.AppendLine($"Face Quality:{detectedface.FaceAttributes.QualityForRecognition}"); }
                        if (detectedface.FaceAttributes.Smile != null) { }
                        txtResults.Text = sb.ToString();
                    }
                }
                catch (Exception ex)
                {
                    txtResults.Text = $"Invalid Attributes sent {ex.Message}";
                }
            }
        }
        private async void btnBuildPersonGroup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentPersonGroupID))
            {
                string IMAGE_BASE_URL = "https://raw.githubusercontent.com/Azure-Samples/cognitive-services-sample-data-files/master/Face/images/";
                Dictionary<string, string[]> personDictionary = new Dictionary<string, string[]>
            {
                { "Family1-Dad", new[] { "Family1-Dad1.jpg", "Family1-Dad2.jpg" } },
                { "Family1-Mom", new[] { "Family1-Mom1.jpg", "Family1-Mom2.jpg" } },
                { "Family1-Son", new[] { "Family1-Son1.jpg", "Family1-Son2.jpg" } },
                { "Family1-Daughter", new[] { "Family1-Daughter1.jpg", "Family1-Daughter2.jpg" } },
                { "Family2-Lady", new[] { "Family2-Lady1.jpg", "Family2-Lady2.jpg" } },
                { "Family2-Man", new[] { "Family2-Man1.jpg", "Family2-Man2.jpg" } }
            };
                _currentPersonGroupID = await _faceAPI.BuildPersonGroup(IMAGE_BASE_URL, personDictionary, Guid.NewGuid().ToString(), PERSON_GROUP_NAME);
            }
        }
        private async void frmMain_Load(object sender, EventArgs e)
        {
            
            string path = @$"{Application.StartupPath}\Images\";
            string filename = "face-detection-demo1-4f7bb821.png";
            pbxCandidateImage.Load($"{path}{filename}");
            _currentImageFile = $"{path}{filename}";
            var personGroups = await _faceAPI.GetPersonGroups();
            var personGroup = personGroups.SingleOrDefault(s => s.Name == PERSON_GROUP_NAME);
            if (personGroup != null) _currentPersonGroupID = personGroup.PersonGroupId;
            var trainingStatus = await _faceAPI.GetTrainingStatus(_currentPersonGroupID);
            if (trainingStatus.Status != TrainingStatusType.Succeeded)
            {
                await _faceAPI.TrainPersonGroup(_currentPersonGroupID);
            }
        }

        private async void btnIdentifyPerson_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentPersonGroupID))
            {
                var detectedFaces = await _faceAPI.DetectFaceRecognize(File.ReadAllBytes(_currentImageFile), new List<FaceAttributeType> { FaceAttributeType.QualityForRecognition });
                _detectedFaces = detectedFaces.Select((s, i) => new { s, i }).ToDictionary(x => x.i, x => x.s);
                pbxCandidateImage.Refresh();
                var verifyResults = await _faceAPI.DetectFaces(_detectedFaces, _currentPersonGroupID);
                try
                {
                    StringBuilder sb = new StringBuilder();
                    if (verifyResults.Count > 0)
                    {
                        foreach (var verifyResult in verifyResults)
                        {                            
                            sb.AppendLine($"Face {verifyResult.Id + 1} matches {verifyResult.Name}");
                            sb.AppendLine($"Is Identical: {verifyResult.verifyResult.IsIdentical}");
                            sb.AppendLine($"Confidence: {verifyResult.verifyResult.Confidence}");
                        }
                    }
                    foreach (var key in _detectedFaces.Keys)
                    {
                        if (verifyResults.Where(s => s.Id == key).Count() == 0)
                        {
                            sb.AppendLine($"Face {key + 1} has no match");
                        }
                    }
                    txtResults.Text = sb.ToString();
                }
                catch (Exception ex)
                { }
            }
        }

        private async void btnDeletePersonGroup_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentPersonGroupID))
            {
                await _faceAPI.DeletePersonGroup(_currentPersonGroupID);
                _currentPersonGroupID = null;
            }
        }

        private async void btnTrainGroup_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentPersonGroupID))
            {
                await _faceAPI.TrainPersonGroup(_currentPersonGroupID);
                _currentPersonGroupID = null;
            }
        }

        private void pbxCandidateImage_Paint(object sender, PaintEventArgs e)
        {
            float scaleY = (float)pbxCandidateImage.Height / (float)pbxCandidateImage.Image.Height;
            float scaleX = (float)pbxCandidateImage.Width / (float)pbxCandidateImage.Image.Width;
            int f = 1;
            if (_detectedFaces != null)
            {
                foreach (var faceKey in _detectedFaces.Keys) {
                    var face = _detectedFaces[faceKey];
                    Rectangle rect = new Rectangle((int)(face.FaceRectangle.Left * scaleX), (int)(face.FaceRectangle.Top * scaleY), (int)(face.FaceRectangle.Width * scaleX), (int)(face.FaceRectangle.Height * scaleY));
                    Rectangle text = new Rectangle((int)((face.FaceRectangle.Left + 5)  * scaleX), (int)((face.FaceRectangle.Top + 5) * scaleY), 10,10);
                    Graphics g = e.Graphics;
                    
                    using (Pen pen = new Pen(Color.Red, 14))
                    {                        
                        g.DrawRectangle(pen, rect);                        
                    }
                    using (Pen pen = new Pen(Color.White, 18))
                    {
                        g.DrawRectangle(pen, text);
                        g.DrawString($"{faceKey + 1}", new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Black), text);
                    }
                }
            }
        }
    }
}
