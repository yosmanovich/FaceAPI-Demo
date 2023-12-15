using Microsoft.Azure.CognitiveServices.Vision.Face.Models;

namespace FaceAPI_Demo
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dlgOpenImage = new OpenFileDialog();
            txtResults = new TextBox();
            panel2 = new Panel();
            panel1 = new Panel();
            gbxAvailableAttributes = new GroupBox();
            cbxAccessories = new CheckBox();
            cbxBlur = new CheckBox();
            cbxExposure = new CheckBox();
            cbxQualityForRecognition = new CheckBox();
            btnDetectFace = new Button();
            cbxMask = new CheckBox();
            cbxOcclusion = new CheckBox();
            cbxHeadPose = new CheckBox();
            cbxNoise = new CheckBox();
            cbxGlasses = new CheckBox();
            groupBox1 = new GroupBox();
            cbxAge = new CheckBox();
            cbxEmotion = new CheckBox();
            cbxSmile = new CheckBox();
            cbxFacialHair = new CheckBox();
            cbxGender = new CheckBox();
            cbxMakeup = new CheckBox();
            cbxHair = new CheckBox();
            gbxMatching = new GroupBox();
            btnTrainGroup = new Button();
            btnBuildPersonGroup = new Button();
            btnIdentifyPerson = new Button();
            btnDeletePersonGroup = new Button();
            pbxCandidateImage = new PictureBox();
            btnSelectImage = new Button();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            gbxAvailableAttributes.SuspendLayout();
            groupBox1.SuspendLayout();
            gbxMatching.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxCandidateImage).BeginInit();
            SuspendLayout();
            // 
            // txtResults
            // 
            txtResults.Dock = DockStyle.Bottom;
            txtResults.Location = new Point(0, 359);
            txtResults.Multiline = true;
            txtResults.Name = "txtResults";
            txtResults.Size = new Size(956, 175);
            txtResults.TabIndex = 25;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(txtResults);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(956, 534);
            panel2.TabIndex = 28;
            // 
            // panel1
            // 
            panel1.Controls.Add(gbxAvailableAttributes);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(gbxMatching);
            panel1.Controls.Add(pbxCandidateImage);
            panel1.Controls.Add(btnSelectImage);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(956, 359);
            panel1.TabIndex = 27;
            // 
            // gbxAvailableAttributes
            // 
            gbxAvailableAttributes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gbxAvailableAttributes.Controls.Add(cbxAccessories);
            gbxAvailableAttributes.Controls.Add(cbxBlur);
            gbxAvailableAttributes.Controls.Add(cbxExposure);
            gbxAvailableAttributes.Controls.Add(cbxQualityForRecognition);
            gbxAvailableAttributes.Controls.Add(btnDetectFace);
            gbxAvailableAttributes.Controls.Add(cbxMask);
            gbxAvailableAttributes.Controls.Add(cbxOcclusion);
            gbxAvailableAttributes.Controls.Add(cbxHeadPose);
            gbxAvailableAttributes.Controls.Add(cbxNoise);
            gbxAvailableAttributes.Controls.Add(cbxGlasses);
            gbxAvailableAttributes.Location = new Point(417, 9);
            gbxAvailableAttributes.Name = "gbxAvailableAttributes";
            gbxAvailableAttributes.Size = new Size(200, 341);
            gbxAvailableAttributes.TabIndex = 26;
            gbxAvailableAttributes.TabStop = false;
            gbxAvailableAttributes.Text = "Available Attributes";
            // 
            // cbxAccessories
            // 
            cbxAccessories.AutoSize = true;
            cbxAccessories.Location = new Point(18, 22);
            cbxAccessories.Name = "cbxAccessories";
            cbxAccessories.Size = new Size(87, 19);
            cbxAccessories.TabIndex = 7;
            cbxAccessories.Text = "Accessories";
            cbxAccessories.UseVisualStyleBackColor = true;
            // 
            // cbxBlur
            // 
            cbxBlur.AutoSize = true;
            cbxBlur.Location = new Point(18, 47);
            cbxBlur.Name = "cbxBlur";
            cbxBlur.Size = new Size(47, 19);
            cbxBlur.TabIndex = 9;
            cbxBlur.Text = "Blur";
            cbxBlur.UseVisualStyleBackColor = true;
            // 
            // cbxExposure
            // 
            cbxExposure.AutoSize = true;
            cbxExposure.Location = new Point(18, 72);
            cbxExposure.Name = "cbxExposure";
            cbxExposure.Size = new Size(74, 19);
            cbxExposure.TabIndex = 11;
            cbxExposure.Text = "Exposure";
            cbxExposure.UseVisualStyleBackColor = true;
            // 
            // cbxQualityForRecognition
            // 
            cbxQualityForRecognition.AutoSize = true;
            cbxQualityForRecognition.Checked = true;
            cbxQualityForRecognition.CheckState = CheckState.Checked;
            cbxQualityForRecognition.Location = new Point(18, 222);
            cbxQualityForRecognition.Name = "cbxQualityForRecognition";
            cbxQualityForRecognition.Size = new Size(151, 19);
            cbxQualityForRecognition.TabIndex = 21;
            cbxQualityForRecognition.Text = "Quality For Recognition";
            cbxQualityForRecognition.UseVisualStyleBackColor = true;
            // 
            // btnDetectFace
            // 
            btnDetectFace.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDetectFace.Location = new Point(6, 318);
            btnDetectFace.Name = "btnDetectFace";
            btnDetectFace.Size = new Size(108, 23);
            btnDetectFace.TabIndex = 1;
            btnDetectFace.Text = "Detect Face";
            btnDetectFace.UseVisualStyleBackColor = true;
            btnDetectFace.Click += btnDetectFace_Click;
            // 
            // cbxMask
            // 
            cbxMask.AutoSize = true;
            cbxMask.Location = new Point(18, 147);
            cbxMask.Name = "cbxMask";
            cbxMask.Size = new Size(54, 19);
            cbxMask.TabIndex = 13;
            cbxMask.Text = "Mask";
            cbxMask.UseVisualStyleBackColor = true;
            // 
            // cbxOcclusion
            // 
            cbxOcclusion.AutoSize = true;
            cbxOcclusion.Location = new Point(18, 197);
            cbxOcclusion.Name = "cbxOcclusion";
            cbxOcclusion.Size = new Size(79, 19);
            cbxOcclusion.TabIndex = 20;
            cbxOcclusion.Text = "Occlusion";
            cbxOcclusion.UseVisualStyleBackColor = true;
            // 
            // cbxHeadPose
            // 
            cbxHeadPose.AutoSize = true;
            cbxHeadPose.Location = new Point(18, 122);
            cbxHeadPose.Name = "cbxHeadPose";
            cbxHeadPose.Size = new Size(82, 19);
            cbxHeadPose.TabIndex = 15;
            cbxHeadPose.Text = "Head Pose";
            cbxHeadPose.UseVisualStyleBackColor = true;
            // 
            // cbxNoise
            // 
            cbxNoise.AutoSize = true;
            cbxNoise.Location = new Point(18, 172);
            cbxNoise.Name = "cbxNoise";
            cbxNoise.Size = new Size(56, 19);
            cbxNoise.TabIndex = 19;
            cbxNoise.Text = "Noise";
            cbxNoise.UseVisualStyleBackColor = true;
            // 
            // cbxGlasses
            // 
            cbxGlasses.AutoSize = true;
            cbxGlasses.Location = new Point(18, 97);
            cbxGlasses.Name = "cbxGlasses";
            cbxGlasses.Size = new Size(64, 19);
            cbxGlasses.TabIndex = 17;
            cbxGlasses.Text = "Glasses";
            cbxGlasses.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.Controls.Add(cbxAge);
            groupBox1.Controls.Add(cbxEmotion);
            groupBox1.Controls.Add(cbxSmile);
            groupBox1.Controls.Add(cbxFacialHair);
            groupBox1.Controls.Add(cbxGender);
            groupBox1.Controls.Add(cbxMakeup);
            groupBox1.Controls.Add(cbxHair);
            groupBox1.Location = new Point(623, 7);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(163, 343);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Text = "Retired Attributes";
            // 
            // cbxAge
            // 
            cbxAge.AutoSize = true;
            cbxAge.Enabled = false;
            cbxAge.Location = new Point(19, 22);
            cbxAge.Name = "cbxAge";
            cbxAge.Size = new Size(47, 19);
            cbxAge.TabIndex = 8;
            cbxAge.Text = "Age";
            cbxAge.UseVisualStyleBackColor = true;
            // 
            // cbxEmotion
            // 
            cbxEmotion.AutoSize = true;
            cbxEmotion.Enabled = false;
            cbxEmotion.Location = new Point(19, 47);
            cbxEmotion.Name = "cbxEmotion";
            cbxEmotion.Size = new Size(71, 19);
            cbxEmotion.TabIndex = 10;
            cbxEmotion.Text = "Emotion";
            cbxEmotion.UseVisualStyleBackColor = true;
            // 
            // cbxSmile
            // 
            cbxSmile.AutoSize = true;
            cbxSmile.Enabled = false;
            cbxSmile.Location = new Point(19, 172);
            cbxSmile.Name = "cbxSmile";
            cbxSmile.Size = new Size(55, 19);
            cbxSmile.TabIndex = 22;
            cbxSmile.Text = "Smile";
            cbxSmile.UseVisualStyleBackColor = true;
            // 
            // cbxFacialHair
            // 
            cbxFacialHair.AutoSize = true;
            cbxFacialHair.Enabled = false;
            cbxFacialHair.Location = new Point(19, 72);
            cbxFacialHair.Name = "cbxFacialHair";
            cbxFacialHair.Size = new Size(81, 19);
            cbxFacialHair.TabIndex = 12;
            cbxFacialHair.Text = "Facial Hair";
            cbxFacialHair.UseVisualStyleBackColor = true;
            // 
            // cbxGender
            // 
            cbxGender.AutoSize = true;
            cbxGender.Enabled = false;
            cbxGender.Location = new Point(19, 97);
            cbxGender.Name = "cbxGender";
            cbxGender.Size = new Size(64, 19);
            cbxGender.TabIndex = 18;
            cbxGender.Text = "Gender";
            cbxGender.UseVisualStyleBackColor = true;
            // 
            // cbxMakeup
            // 
            cbxMakeup.AutoSize = true;
            cbxMakeup.Enabled = false;
            cbxMakeup.Location = new Point(19, 147);
            cbxMakeup.Name = "cbxMakeup";
            cbxMakeup.Size = new Size(69, 19);
            cbxMakeup.TabIndex = 14;
            cbxMakeup.Text = "Makeup";
            cbxMakeup.UseVisualStyleBackColor = true;
            // 
            // cbxHair
            // 
            cbxHair.AutoSize = true;
            cbxHair.Enabled = false;
            cbxHair.Location = new Point(19, 122);
            cbxHair.Name = "cbxHair";
            cbxHair.Size = new Size(48, 19);
            cbxHair.TabIndex = 16;
            cbxHair.Text = "Hair";
            cbxHair.UseVisualStyleBackColor = true;
            // 
            // gbxMatching
            // 
            gbxMatching.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            gbxMatching.Controls.Add(btnTrainGroup);
            gbxMatching.Controls.Add(btnBuildPersonGroup);
            gbxMatching.Controls.Add(btnIdentifyPerson);
            gbxMatching.Controls.Add(btnDeletePersonGroup);
            gbxMatching.Location = new Point(786, 9);
            gbxMatching.Name = "gbxMatching";
            gbxMatching.Size = new Size(167, 341);
            gbxMatching.TabIndex = 26;
            gbxMatching.TabStop = false;
            gbxMatching.Text = "Matching";
            // 
            // btnTrainGroup
            // 
            btnTrainGroup.Location = new Point(6, 49);
            btnTrainGroup.Name = "btnTrainGroup";
            btnTrainGroup.Size = new Size(148, 23);
            btnTrainGroup.TabIndex = 7;
            btnTrainGroup.Text = "Train Person Group";
            btnTrainGroup.UseVisualStyleBackColor = true;
            btnTrainGroup.Click += btnTrainGroup_Click;
            // 
            // btnBuildPersonGroup
            // 
            btnBuildPersonGroup.Location = new Point(6, 20);
            btnBuildPersonGroup.Name = "btnBuildPersonGroup";
            btnBuildPersonGroup.Size = new Size(148, 23);
            btnBuildPersonGroup.TabIndex = 4;
            btnBuildPersonGroup.Text = "Build Person Group";
            btnBuildPersonGroup.UseVisualStyleBackColor = true;
            btnBuildPersonGroup.Click += btnBuildPersonGroup_Click;
            // 
            // btnIdentifyPerson
            // 
            btnIdentifyPerson.Location = new Point(6, 318);
            btnIdentifyPerson.Name = "btnIdentifyPerson";
            btnIdentifyPerson.Size = new Size(148, 23);
            btnIdentifyPerson.TabIndex = 5;
            btnIdentifyPerson.Text = "Identify Person in Group";
            btnIdentifyPerson.UseVisualStyleBackColor = true;
            btnIdentifyPerson.Click += btnIdentifyPerson_Click;
            // 
            // btnDeletePersonGroup
            // 
            btnDeletePersonGroup.Location = new Point(6, 78);
            btnDeletePersonGroup.Name = "btnDeletePersonGroup";
            btnDeletePersonGroup.Size = new Size(148, 23);
            btnDeletePersonGroup.TabIndex = 6;
            btnDeletePersonGroup.Text = "Delete Person Group";
            btnDeletePersonGroup.UseVisualStyleBackColor = true;
            btnDeletePersonGroup.Click += btnDeletePersonGroup_Click;
            // 
            // pbxCandidateImage
            // 
            pbxCandidateImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbxCandidateImage.Location = new Point(13, 7);
            pbxCandidateImage.Name = "pbxCandidateImage";
            pbxCandidateImage.Size = new Size(398, 311);
            pbxCandidateImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCandidateImage.TabIndex = 2;
            pbxCandidateImage.TabStop = false;
            pbxCandidateImage.Paint += pbxCandidateImage_Paint;
            // 
            // btnSelectImage
            // 
            btnSelectImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSelectImage.Location = new Point(303, 327);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(108, 23);
            btnSelectImage.TabIndex = 3;
            btnSelectImage.Text = "Select Image";
            btnSelectImage.UseVisualStyleBackColor = true;
            btnSelectImage.Click += btnSelectImage_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(956, 534);
            Controls.Add(panel2);
            Name = "frmMain";
            Text = "Face API Demo";
            Load += frmMain_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            gbxAvailableAttributes.ResumeLayout(false);
            gbxAvailableAttributes.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbxMatching.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxCandidateImage).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private OpenFileDialog dlgOpenImage;
        private TextBox txtResults;
        private Panel panel2;
        private Panel panel1;
        private GroupBox gbxAvailableAttributes;
        private CheckBox cbxAccessories;
        private CheckBox cbxBlur;
        private CheckBox cbxExposure;
        private CheckBox cbxQualityForRecognition;
        private Button btnDetectFace;
        private CheckBox cbxMask;
        private CheckBox cbxOcclusion;
        private CheckBox cbxHeadPose;
        private CheckBox cbxNoise;
        private CheckBox cbxGlasses;
        private GroupBox groupBox1;
        private CheckBox cbxAge;
        private CheckBox cbxEmotion;
        private CheckBox cbxSmile;
        private CheckBox cbxFacialHair;
        private CheckBox cbxGender;
        private CheckBox cbxMakeup;
        private CheckBox cbxHair;
        private PictureBox pbxCandidateImage;
        private Button btnSelectImage;
        private GroupBox gbxMatching;
        private Button btnTrainGroup;
        private Button btnBuildPersonGroup;
        private Button btnIdentifyPerson;
        private Button btnDeletePersonGroup;
    }
}
