namespace Optocheck
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.scanButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.infinityRadioButton = new System.Windows.Forms.RadioButton();
            this.zboxRadioButton = new System.Windows.Forms.RadioButton();
            this.frontRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mirror Type";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(28, 171);
            this.scanButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(112, 36);
            this.scanButton.TabIndex = 2;
            this.scanButton.Text = "Scan";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(189, 64);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(843, 273);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // infinityRadioButton
            // 
            this.infinityRadioButton.AutoSize = true;
            this.infinityRadioButton.Location = new System.Drawing.Point(12, 64);
            this.infinityRadioButton.Name = "infinityRadioButton";
            this.infinityRadioButton.Size = new System.Drawing.Size(105, 29);
            this.infinityRadioButton.TabIndex = 5;
            this.infinityRadioButton.TabStop = true;
            this.infinityRadioButton.Text = "Infinity";
            this.infinityRadioButton.UseVisualStyleBackColor = true;
            // 
            // zboxRadioButton
            // 
            this.zboxRadioButton.AutoSize = true;
            this.zboxRadioButton.Location = new System.Drawing.Point(12, 99);
            this.zboxRadioButton.Name = "zboxRadioButton";
            this.zboxRadioButton.Size = new System.Drawing.Size(100, 29);
            this.zboxRadioButton.TabIndex = 6;
            this.zboxRadioButton.TabStop = true;
            this.zboxRadioButton.Text = "Z-Box";
            this.zboxRadioButton.UseVisualStyleBackColor = true;
            // 
            // frontRadioButton
            // 
            this.frontRadioButton.AutoSize = true;
            this.frontRadioButton.Location = new System.Drawing.Point(12, 134);
            this.frontRadioButton.Name = "frontRadioButton";
            this.frontRadioButton.Size = new System.Drawing.Size(93, 29);
            this.frontRadioButton.TabIndex = 7;
            this.frontRadioButton.TabStop = true;
            this.frontRadioButton.Text = "Front";
            this.frontRadioButton.UseVisualStyleBackColor = true;
            this.frontRadioButton.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 358);
            this.Controls.Add(this.frontRadioButton);
            this.Controls.Add(this.zboxRadioButton);
            this.Controls.Add(this.infinityRadioButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.scanButton);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Optocheck";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton infinityRadioButton;
        private System.Windows.Forms.RadioButton zboxRadioButton;
        private System.Windows.Forms.RadioButton frontRadioButton;
    }
}

