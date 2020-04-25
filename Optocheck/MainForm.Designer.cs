namespace Optocheck
{
    partial class Optocheck
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Optocheck));
            this.mirrorTypeLabel = new System.Windows.Forms.Label();
            this.scanButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.expectedValueLabel = new System.Windows.Forms.Label();
            this.measuredValueLabel = new System.Windows.Forms.Label();
            this.passOrFailLabel = new System.Windows.Forms.Label();
            this.measuredValue1 = new System.Windows.Forms.Label();
            this.measuredValue2 = new System.Windows.Forms.Label();
            this.measuredValue3 = new System.Windows.Forms.Label();
            this.measuredValue4 = new System.Windows.Forms.Label();
            this.measurementName1 = new System.Windows.Forms.Label();
            this.measurementName2 = new System.Windows.Forms.Label();
            this.measurementName3 = new System.Windows.Forms.Label();
            this.measurementName4 = new System.Windows.Forms.Label();
            this.expectedValue1 = new System.Windows.Forms.Label();
            this.expectedValue2 = new System.Windows.Forms.Label();
            this.expectedValue3 = new System.Windows.Forms.Label();
            this.expectedValue4 = new System.Windows.Forms.Label();
            this.statusLabel1 = new System.Windows.Forms.Label();
            this.statusLabel2 = new System.Windows.Forms.Label();
            this.statusLabel3 = new System.Windows.Forms.Label();
            this.statusLabel4 = new System.Windows.Forms.Label();
            this.infinityRadioButton = new System.Windows.Forms.RadioButton();
            this.zboxRadioButton = new System.Windows.Forms.RadioButton();
            this.frontRadioButton = new System.Windows.Forms.RadioButton();
            this.cancelScanButton = new System.Windows.Forms.Button();
            this.scanProgressBar = new System.Windows.Forms.ProgressBar();
            this.exitButton = new System.Windows.Forms.Button();
            this.scanTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takePicture_button = new System.Windows.Forms.Button();
            this.arduinoInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mirrorTypeLabel
            // 
            this.mirrorTypeLabel.AutoSize = true;
            this.mirrorTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mirrorTypeLabel.Location = new System.Drawing.Point(13, 26);
            this.mirrorTypeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mirrorTypeLabel.Name = "mirrorTypeLabel";
            this.mirrorTypeLabel.Size = new System.Drawing.Size(87, 20);
            this.mirrorTypeLabel.TabIndex = 1;
            this.mirrorTypeLabel.Text = "Mirror Type";
            // 
            // scanButton
            // 
            this.scanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanButton.Location = new System.Drawing.Point(7, 164);
            this.scanButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(169, 40);
            this.scanButton.TabIndex = 2;
            this.scanButton.Text = "Scan";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.nameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.expectedValueLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.measuredValueLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.passOrFailLabel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.measuredValue1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.measuredValue2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.measuredValue3, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.measuredValue4, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.measurementName1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.measurementName2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.measurementName3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.measurementName4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.expectedValue1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.expectedValue2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.expectedValue3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.expectedValue4, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.statusLabel1, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.statusLabel2, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.statusLabel3, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.statusLabel4, 3, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(184, 29);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(798, 625);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // nameLabel
            // 
            this.nameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(5, 2);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(191, 50);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // expectedValueLabel
            // 
            this.expectedValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expectedValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expectedValueLabel.Location = new System.Drawing.Point(204, 2);
            this.expectedValueLabel.Name = "expectedValueLabel";
            this.expectedValueLabel.Size = new System.Drawing.Size(191, 50);
            this.expectedValueLabel.TabIndex = 1;
            this.expectedValueLabel.Text = "Expected Value";
            this.expectedValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // measuredValueLabel
            // 
            this.measuredValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.measuredValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.measuredValueLabel.Location = new System.Drawing.Point(403, 2);
            this.measuredValueLabel.Name = "measuredValueLabel";
            this.measuredValueLabel.Size = new System.Drawing.Size(191, 50);
            this.measuredValueLabel.TabIndex = 2;
            this.measuredValueLabel.Text = "Measured Value";
            this.measuredValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // passOrFailLabel
            // 
            this.passOrFailLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passOrFailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passOrFailLabel.Location = new System.Drawing.Point(602, 2);
            this.passOrFailLabel.Name = "passOrFailLabel";
            this.passOrFailLabel.Size = new System.Drawing.Size(191, 50);
            this.passOrFailLabel.TabIndex = 4;
            this.passOrFailLabel.Text = "Pass/Fail";
            this.passOrFailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // measuredValue1
            // 
            this.measuredValue1.AutoSize = true;
            this.measuredValue1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.measuredValue1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.measuredValue1.Location = new System.Drawing.Point(403, 54);
            this.measuredValue1.Name = "measuredValue1";
            this.measuredValue1.Size = new System.Drawing.Size(191, 140);
            this.measuredValue1.TabIndex = 5;
            this.measuredValue1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // measuredValue2
            // 
            this.measuredValue2.AutoSize = true;
            this.measuredValue2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.measuredValue2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.measuredValue2.Location = new System.Drawing.Point(403, 196);
            this.measuredValue2.Name = "measuredValue2";
            this.measuredValue2.Size = new System.Drawing.Size(191, 140);
            this.measuredValue2.TabIndex = 6;
            this.measuredValue2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // measuredValue3
            // 
            this.measuredValue3.AutoSize = true;
            this.measuredValue3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.measuredValue3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.measuredValue3.Location = new System.Drawing.Point(403, 338);
            this.measuredValue3.Name = "measuredValue3";
            this.measuredValue3.Size = new System.Drawing.Size(191, 140);
            this.measuredValue3.TabIndex = 7;
            this.measuredValue3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // measuredValue4
            // 
            this.measuredValue4.AutoSize = true;
            this.measuredValue4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.measuredValue4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.measuredValue4.Location = new System.Drawing.Point(403, 480);
            this.measuredValue4.Name = "measuredValue4";
            this.measuredValue4.Size = new System.Drawing.Size(191, 143);
            this.measuredValue4.TabIndex = 8;
            this.measuredValue4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // measurementName1
            // 
            this.measurementName1.AutoSize = true;
            this.measurementName1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.measurementName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.measurementName1.Location = new System.Drawing.Point(5, 54);
            this.measurementName1.Name = "measurementName1";
            this.measurementName1.Size = new System.Drawing.Size(191, 140);
            this.measurementName1.TabIndex = 15;
            this.measurementName1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.measurementName1.Click += new System.EventHandler(this.measurementName_Click);
            // 
            // measurementName2
            // 
            this.measurementName2.AutoSize = true;
            this.measurementName2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.measurementName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.measurementName2.Location = new System.Drawing.Point(5, 196);
            this.measurementName2.Name = "measurementName2";
            this.measurementName2.Size = new System.Drawing.Size(191, 140);
            this.measurementName2.TabIndex = 16;
            this.measurementName2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.measurementName2.Click += new System.EventHandler(this.measurementName_Click);
            // 
            // measurementName3
            // 
            this.measurementName3.AutoSize = true;
            this.measurementName3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.measurementName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.measurementName3.Location = new System.Drawing.Point(5, 338);
            this.measurementName3.Name = "measurementName3";
            this.measurementName3.Size = new System.Drawing.Size(191, 140);
            this.measurementName3.TabIndex = 17;
            this.measurementName3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.measurementName3.Click += new System.EventHandler(this.measurementName_Click);
            // 
            // measurementName4
            // 
            this.measurementName4.AutoSize = true;
            this.measurementName4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.measurementName4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.measurementName4.Location = new System.Drawing.Point(5, 480);
            this.measurementName4.Name = "measurementName4";
            this.measurementName4.Size = new System.Drawing.Size(191, 143);
            this.measurementName4.TabIndex = 18;
            this.measurementName4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.measurementName4.Click += new System.EventHandler(this.measurementName_Click);
            // 
            // expectedValue1
            // 
            this.expectedValue1.AutoSize = true;
            this.expectedValue1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expectedValue1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expectedValue1.Location = new System.Drawing.Point(204, 54);
            this.expectedValue1.Name = "expectedValue1";
            this.expectedValue1.Size = new System.Drawing.Size(191, 140);
            this.expectedValue1.TabIndex = 25;
            this.expectedValue1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // expectedValue2
            // 
            this.expectedValue2.AutoSize = true;
            this.expectedValue2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expectedValue2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expectedValue2.Location = new System.Drawing.Point(204, 196);
            this.expectedValue2.Name = "expectedValue2";
            this.expectedValue2.Size = new System.Drawing.Size(191, 140);
            this.expectedValue2.TabIndex = 25;
            this.expectedValue2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // expectedValue3
            // 
            this.expectedValue3.AutoSize = true;
            this.expectedValue3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expectedValue3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expectedValue3.Location = new System.Drawing.Point(204, 338);
            this.expectedValue3.Name = "expectedValue3";
            this.expectedValue3.Size = new System.Drawing.Size(191, 140);
            this.expectedValue3.TabIndex = 25;
            this.expectedValue3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // expectedValue4
            // 
            this.expectedValue4.AutoSize = true;
            this.expectedValue4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expectedValue4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expectedValue4.Location = new System.Drawing.Point(204, 480);
            this.expectedValue4.Name = "expectedValue4";
            this.expectedValue4.Size = new System.Drawing.Size(191, 143);
            this.expectedValue4.TabIndex = 25;
            this.expectedValue4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusLabel1
            // 
            this.statusLabel1.AutoSize = true;
            this.statusLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel1.Location = new System.Drawing.Point(602, 54);
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(191, 140);
            this.statusLabel1.TabIndex = 27;
            this.statusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusLabel2
            // 
            this.statusLabel2.AutoSize = true;
            this.statusLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel2.Location = new System.Drawing.Point(602, 196);
            this.statusLabel2.Name = "statusLabel2";
            this.statusLabel2.Size = new System.Drawing.Size(191, 140);
            this.statusLabel2.TabIndex = 28;
            this.statusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusLabel3
            // 
            this.statusLabel3.AutoSize = true;
            this.statusLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel3.Location = new System.Drawing.Point(602, 338);
            this.statusLabel3.Name = "statusLabel3";
            this.statusLabel3.Size = new System.Drawing.Size(191, 140);
            this.statusLabel3.TabIndex = 29;
            this.statusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusLabel4
            // 
            this.statusLabel4.AutoSize = true;
            this.statusLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel4.Location = new System.Drawing.Point(602, 480);
            this.statusLabel4.Name = "statusLabel4";
            this.statusLabel4.Size = new System.Drawing.Size(191, 143);
            this.statusLabel4.TabIndex = 30;
            this.statusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infinityRadioButton
            // 
            this.infinityRadioButton.AutoSize = true;
            this.infinityRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infinityRadioButton.Location = new System.Drawing.Point(7, 57);
            this.infinityRadioButton.Name = "infinityRadioButton";
            this.infinityRadioButton.Size = new System.Drawing.Size(73, 24);
            this.infinityRadioButton.TabIndex = 5;
            this.infinityRadioButton.TabStop = true;
            this.infinityRadioButton.Text = "Infinity";
            this.infinityRadioButton.UseVisualStyleBackColor = true;
            this.infinityRadioButton.CheckedChanged += new System.EventHandler(this.notYetWorkingRadioButton_CheckedChanged);
            // 
            // zboxRadioButton
            // 
            this.zboxRadioButton.AutoSize = true;
            this.zboxRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zboxRadioButton.Location = new System.Drawing.Point(7, 92);
            this.zboxRadioButton.Name = "zboxRadioButton";
            this.zboxRadioButton.Size = new System.Drawing.Size(69, 24);
            this.zboxRadioButton.TabIndex = 6;
            this.zboxRadioButton.TabStop = true;
            this.zboxRadioButton.Text = "Z-Box";
            this.zboxRadioButton.UseVisualStyleBackColor = true;
            this.zboxRadioButton.CheckedChanged += new System.EventHandler(this.notYetWorkingRadioButton_CheckedChanged);
            // 
            // frontRadioButton
            // 
            this.frontRadioButton.AutoSize = true;
            this.frontRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frontRadioButton.Location = new System.Drawing.Point(7, 127);
            this.frontRadioButton.Name = "frontRadioButton";
            this.frontRadioButton.Size = new System.Drawing.Size(65, 24);
            this.frontRadioButton.TabIndex = 7;
            this.frontRadioButton.TabStop = true;
            this.frontRadioButton.Text = "Front";
            this.frontRadioButton.UseVisualStyleBackColor = true;
            // 
            // cancelScanButton
            // 
            this.cancelScanButton.Enabled = false;
            this.cancelScanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelScanButton.Location = new System.Drawing.Point(7, 214);
            this.cancelScanButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelScanButton.Name = "cancelScanButton";
            this.cancelScanButton.Size = new System.Drawing.Size(169, 40);
            this.cancelScanButton.TabIndex = 8;
            this.cancelScanButton.Text = "Cancel Scan";
            this.cancelScanButton.UseVisualStyleBackColor = true;
            this.cancelScanButton.Click += new System.EventHandler(this.cancelScanButton_Click);
            // 
            // scanProgressBar
            // 
            this.scanProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scanProgressBar.BackColor = System.Drawing.SystemColors.Control;
            this.scanProgressBar.Location = new System.Drawing.Point(12, 664);
            this.scanProgressBar.Name = "scanProgressBar";
            this.scanProgressBar.Size = new System.Drawing.Size(1146, 49);
            this.scanProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.scanProgressBar.TabIndex = 9;
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(989, 31);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(169, 61);
            this.exitButton.TabIndex = 10;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_click);
            // 
            // scanTimer
            // 
            this.scanTimer.Tick += new System.EventHandler(this.scanTimer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1170, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cameraToolStripMenuItem,
            this.arduinoInformationToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // cameraToolStripMenuItem
            // 
            this.cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
            this.cameraToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.cameraToolStripMenuItem.Text = "Camera Information";
            this.cameraToolStripMenuItem.Click += new System.EventHandler(this.cameraToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitButton_click);
            // 
            // takePicture_button
            // 
            this.takePicture_button.Location = new System.Drawing.Point(992, 614);
            this.takePicture_button.Name = "takePicture_button";
            this.takePicture_button.Size = new System.Drawing.Size(166, 38);
            this.takePicture_button.TabIndex = 14;
            this.takePicture_button.Text = "Take Picture";
            this.takePicture_button.UseVisualStyleBackColor = true;
            this.takePicture_button.Click += new System.EventHandler(this.takePicture_button_Click);
            // 
            // arduinoInformationToolStripMenuItem
            // 
            this.arduinoInformationToolStripMenuItem.Name = "arduinoInformationToolStripMenuItem";
            this.arduinoInformationToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.arduinoInformationToolStripMenuItem.Text = "Arduino Information";
            // 
            // Optocheck
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1170, 725);
            this.Controls.Add(this.takePicture_button);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.scanProgressBar);
            this.Controls.Add(this.cancelScanButton);
            this.Controls.Add(this.frontRadioButton);
            this.Controls.Add(this.zboxRadioButton);
            this.Controls.Add(this.infinityRadioButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.scanButton);
            this.Controls.Add(this.mirrorTypeLabel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Optocheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Optocheck";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Optocheck_FormClosing);
            this.Load += new System.EventHandler(this.Optocheck_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label mirrorTypeLabel;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton infinityRadioButton;
        private System.Windows.Forms.RadioButton zboxRadioButton;
        private System.Windows.Forms.RadioButton frontRadioButton;
        private System.Windows.Forms.Button cancelScanButton;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label expectedValueLabel;
        private System.Windows.Forms.Label measuredValueLabel;
        private System.Windows.Forms.Label passOrFailLabel;
        private System.Windows.Forms.ProgressBar scanProgressBar;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Timer scanTimer;
        private System.Windows.Forms.Label measuredValue1;
        private System.Windows.Forms.Label measuredValue2;
        private System.Windows.Forms.Label measuredValue3;
        private System.Windows.Forms.Label measuredValue4;
        private System.Windows.Forms.Label measurementName1;
        private System.Windows.Forms.Label measurementName2;
        private System.Windows.Forms.Label measurementName3;
        private System.Windows.Forms.Label measurementName4;
        private System.Windows.Forms.Label expectedValue1;
        private System.Windows.Forms.Label expectedValue2;
        private System.Windows.Forms.Label expectedValue3;
        private System.Windows.Forms.Label expectedValue4;
        private System.Windows.Forms.Label statusLabel1;
        private System.Windows.Forms.Label statusLabel2;
        private System.Windows.Forms.Label statusLabel3;
        private System.Windows.Forms.Label statusLabel4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button takePicture_button;
        private System.Windows.Forms.ToolStripMenuItem arduinoInformationToolStripMenuItem;
    }
}

