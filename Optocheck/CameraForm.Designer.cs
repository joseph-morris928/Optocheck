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
            this.pictureBoxLiveImage = new System.Windows.Forms.PictureBox();
            this.modelLabel = new System.Windows.Forms.Label();
            this.snLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLiveImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxLiveImage
            // 
            this.pictureBoxLiveImage.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxLiveImage.Name = "pictureBoxLiveImage";
            this.pictureBoxLiveImage.Size = new System.Drawing.Size(465, 390);
            this.pictureBoxLiveImage.TabIndex = 0;
            this.pictureBoxLiveImage.TabStop = false;
            this.pictureBoxLiveImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxLiveImage_Paint);
            // 
            // modelLabel
            // 
            this.modelLabel.AutoSize = true;
            this.modelLabel.Location = new System.Drawing.Point(9, 412);
            this.modelLabel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.modelLabel.Name = "modelLabel";
            this.modelLabel.Size = new System.Drawing.Size(42, 13);
            this.modelLabel.TabIndex = 1;
            this.modelLabel.Text = "model#";
            // 
            // snLabel
            // 
            this.snLabel.AutoSize = true;
            this.snLabel.Location = new System.Drawing.Point(9, 439);
            this.snLabel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.snLabel.Name = "snLabel";
            this.snLabel.Size = new System.Drawing.Size(69, 13);
            this.snLabel.TabIndex = 2;
            this.snLabel.Text = "serial number";
            // 
            // CameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 466);
            this.Controls.Add(this.snLabel);
            this.Controls.Add(this.modelLabel);
            this.Controls.Add(this.pictureBoxLiveImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CameraForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CameraForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLiveImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLiveImage;
        private System.Windows.Forms.Label modelLabel;
        private System.Windows.Forms.Label snLabel;
    }
}