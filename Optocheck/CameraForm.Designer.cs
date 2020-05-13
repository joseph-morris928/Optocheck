namespace Optocheck
{
    partial class CameraForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cameraSelection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.imageOutput = new System.Windows.Forms.PictureBox();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.liveViewLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // cameraSelection
            // 
            this.cameraSelection.FormattingEnabled = true;
            this.cameraSelection.Location = new System.Drawing.Point(371, 20);
            this.cameraSelection.Name = "cameraSelection";
            this.cameraSelection.Size = new System.Drawing.Size(121, 21);
            this.cameraSelection.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please select the Serial Number of the Camera you would like connected:";
            // 
            // connectButton
            // 
            this.connectButton.Enabled = false;
            this.connectButton.Location = new System.Drawing.Point(498, 18);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.ForeColor = System.Drawing.Color.Green;
            this.connectionStatusLabel.Location = new System.Drawing.Point(12, 44);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(566, 23);
            this.connectionStatusLabel.TabIndex = 3;
            this.connectionStatusLabel.Text = "Connection Successful!";
            this.connectionStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.connectionStatusLabel.Visible = false;
            // 
            // imageOutput
            // 
            this.imageOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imageOutput.Location = new System.Drawing.Point(12, 70);
            this.imageOutput.Name = "imageOutput";
            this.imageOutput.Size = new System.Drawing.Size(566, 373);
            this.imageOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imageOutput.TabIndex = 4;
            this.imageOutput.TabStop = false;
            this.imageOutput.Visible = false;
            this.imageOutput.Paint += new System.Windows.Forms.PaintEventHandler(this.imageOutput_Paint);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Location = new System.Drawing.Point(459, 449);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(119, 23);
            this.disconnectButton.TabIndex = 5;
            this.disconnectButton.Text = "Disconnect Camera";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // liveViewLabel
            // 
            this.liveViewLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.liveViewLabel.Location = new System.Drawing.Point(15, 73);
            this.liveViewLabel.Name = "liveViewLabel";
            this.liveViewLabel.Size = new System.Drawing.Size(560, 367);
            this.liveViewLabel.TabIndex = 6;
            this.liveViewLabel.Text = "A Live View will be shown here when a camera is connected";
            this.liveViewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 481);
            this.Controls.Add(this.imageOutput);
            this.Controls.Add(this.liveViewLabel);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectionStatusLabel);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cameraSelection);
            this.Name = "CameraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect Camera";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CameraForm_FormClosing);
            this.Load += new System.EventHandler(this.CameraForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cameraSelection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label connectionStatusLabel;
        private System.Windows.Forms.PictureBox imageOutput;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Label liveViewLabel;
    }
}