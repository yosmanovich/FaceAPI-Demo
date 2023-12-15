using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;

namespace FaceAPI
{
    public class FaceAPI
    {
        private readonly IFaceClient _client;

        public FaceAPI(string endpoint, string key)
        {            
            _client = new FaceClient(new ApiKeyServiceClientCredentials(key)) { Endpoint = endpoint };
        }

        public async Task<List<DetectedFace>> DetectFaceRecognize(string url, List<FaceAttributeType> attributes, string recognitionModel = RecognitionModel.Recognition04, string detectionModel = DetectionModel.Detection03)
        {
            IList<DetectedFace> detectedFaces = await _client.Face.DetectWithUrlAsync(url, recognitionModel: recognitionModel, detectionModel: detectionModel, returnFaceAttributes: attributes);
            return SufficientQualityFaces(detectedFaces);
        }
        public async Task<List<DetectedFace>> DetectFaceRecognize(byte [] image, List<FaceAttributeType> attributes, string recognitionModel = RecognitionModel.Recognition04, string detectionModel = DetectionModel.Detection03)
        {
            IList<DetectedFace> detectedFaces = new List<DetectedFace>();
            using (MemoryStream imgStream = new MemoryStream(image))
            {
                try
                {
                    detectedFaces = await _client.Face.DetectWithStreamAsync(imgStream, recognitionModel: recognitionModel, detectionModel: detectionModel, returnFaceAttributes: attributes);
                }
                catch (Exception ex) { throw ex; }
            }
            return SufficientQualityFaces(detectedFaces);
        }
        private List<DetectedFace> SufficientQualityFaces(IList<DetectedFace> detectedFaces)
        {
            List<DetectedFace> sufficientQualityFaces = new List<DetectedFace>();
            foreach (DetectedFace detectedFace in detectedFaces)
            {
                var faceQualityForRecognition = detectedFace.FaceAttributes.QualityForRecognition;
                if (faceQualityForRecognition.HasValue && (faceQualityForRecognition.Value >= QualityForRecognition.Medium))
                {
                    sufficientQualityFaces.Add(detectedFace);
                }
            }
            return sufficientQualityFaces.ToList();
        }

        public async Task<string> BuildPersonGroup(string url, Dictionary<string, string[]> personDictionary,string personGroupId, string personGroupName, string recognitionModel = RecognitionModel.Recognition04)
        {
            await _client.PersonGroup.CreateAsync(personGroupId, personGroupName, recognitionModel: recognitionModel);
            foreach (var groupedFace in personDictionary.Keys)
            {
                await Task.Delay(250);
                Person person = await _client.PersonGroupPerson.CreateAsync(personGroupId: personGroupId, name: groupedFace);

                foreach (var similarImage in personDictionary[groupedFace])
                {
                    IList<DetectedFace> detectedFaces1 = await _client.Face.DetectWithUrlAsync($"{url}{similarImage}",
                        recognitionModel: recognitionModel,
                        detectionModel: DetectionModel.Detection03,
                        returnFaceAttributes: new List<FaceAttributeType> { FaceAttributeType.QualityForRecognition });
                    bool sufficientQuality = true;
                    foreach (var face1 in detectedFaces1)
                    {
                        var faceQualityForRecognition = face1.FaceAttributes.QualityForRecognition;
                        if (faceQualityForRecognition.HasValue && (faceQualityForRecognition.Value != QualityForRecognition.High))
                        {
                            sufficientQuality = false;
                            break;
                        }
                    }

                    if (!sufficientQuality)
                    {
                        continue;
                    }
       
                    PersistedFace face = await _client.PersonGroupPerson.AddFaceFromUrlAsync(personGroupId, person.PersonId,
                        $"{url}{similarImage}", similarImage);
                }
            }
            await TrainPersonGroup(personGroupId);
            return personGroupId;
        }

        public async Task<string> BuildPersonGroup(Dictionary<string, List<byte[]>> personDictionary, string personGroupId, string personGroupName, string recognitionModel = RecognitionModel.Recognition04)
        {            
            await _client.PersonGroup.CreateAsync(personGroupId, personGroupName, recognitionModel: recognitionModel);
            // The similar faces will be grouped into a single person group person.
            foreach (var groupedFace in personDictionary.Keys)
            {
                // Limit TPS
                await Task.Delay(250);
                Person person = await _client.PersonGroupPerson.CreateAsync(personGroupId: personGroupId, name: groupedFace);

                // Add face to the person group person.
                foreach (var similarImage in personDictionary[groupedFace])
                {
                    using (MemoryStream imgStream = new MemoryStream(similarImage))
                    {
                        IList<DetectedFace> detectedFaces1 = await _client.Face.DetectWithStreamAsync(imgStream,
                        recognitionModel: recognitionModel,
                        detectionModel: DetectionModel.Detection03,
                        returnFaceAttributes: new List<FaceAttributeType> { FaceAttributeType.QualityForRecognition });
                        bool sufficientQuality = true;
                        foreach (var face1 in detectedFaces1)
                        {
                            var faceQualityForRecognition = face1.FaceAttributes.QualityForRecognition;
                            //  Only "high" quality images are recommended for person enrollment
                            if (faceQualityForRecognition.HasValue && (faceQualityForRecognition.Value != QualityForRecognition.High))
                            {
                                sufficientQuality = false;
                                break;
                            }
                        }

                        if (!sufficientQuality)
                        {
                            continue;
                        }
                        PersistedFace face = await _client.PersonGroupPerson.AddFaceFromStreamAsync(personGroupId, person.PersonId, imgStream);
                    }
                }
            }
            await TrainPersonGroup(personGroupId);
            return personGroupId;
        }
        public async Task<TrainingStatus> GetTrainingStatus(String personGroupId) => await _client.PersonGroup.GetTrainingStatusAsync(personGroupId);
        
        public async Task TrainPersonGroup(String personGroupId)
        {
            await _client.PersonGroup.TrainAsync(personGroupId);            

            while (true)
            {
                await Task.Delay(1000);
                var trainingStatus = await _client.PersonGroup.GetTrainingStatusAsync(personGroupId);
                if (trainingStatus.Status == TrainingStatusType.Succeeded) { break; }
            }            
        }
        public async Task DeletePersonGroup(String personGroupId)
        {
            await _client.PersonGroup.DeleteAsync(personGroupId);
        }
        public async Task<IList<PersonGroup>> GetPersonGroups() => await _client.PersonGroup.ListAsync();
        public async Task<List<VerifyInformation>> DetectFaces(Dictionary<int, DetectedFace> detectedFaces, string personGroupID)
        { 
            List<VerifyInformation> verifyResults = new List<VerifyInformation>();
            List<Guid> sourceFaceIds = new List<Guid>();

            foreach (var detectedFaceKey in detectedFaces.Keys) { sourceFaceIds.Add(detectedFaces[detectedFaceKey].FaceId.Value); }

            var identifyResults = await _client.Face.IdentifyAsync(sourceFaceIds, personGroupID);
            
            foreach (var identifyResult in identifyResults)
            {
                if (identifyResult.Candidates.Count > 0)
                {
                    Person person = await _client.PersonGroupPerson.GetAsync(personGroupID, identifyResult.Candidates[0].PersonId);
                    VerifyResult verifyResult = await _client.Face.VerifyFaceToPersonAsync(identifyResult.FaceId, person.PersonId, personGroupID);
                    int id = -1;
                    foreach (var detectedFaceKey in detectedFaces.Keys)
                    { if (detectedFaces[detectedFaceKey].FaceId.Equals(identifyResult.FaceId)) { id = detectedFaceKey; } }
                    verifyResults.Add(new VerifyInformation(id, identifyResult.FaceId, person.Name, person.PersonId, verifyResult));
                }
            }
            return verifyResults;
        }
    }
    public class VerifyInformation
    {
        public VerifyInformation(int Id, Guid FaceId, string Name, Guid PersonId, VerifyResult verifyResult)
        {
            this.Id = Id;
            this.FaceId = FaceId;
            this.Name = Name;
            this.PersonId = PersonId;
            this.verifyResult = verifyResult;
        }
        public int Id { get; private set; }
        public Guid FaceId { get; private set; }
        public string Name { get; private set; }
        public Guid PersonId { get; private set; }
        public VerifyResult verifyResult { get; private set; }
    }
    
}
