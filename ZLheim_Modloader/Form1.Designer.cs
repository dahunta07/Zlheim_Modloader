namespace ZLheim_Modloader
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
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.materialRaisedButton4 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.BrowseFolderButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.LaunchStatus_Label = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.materialDivider2 = new MaterialSkin.Controls.MaterialDivider();
            this.ZLM_Lable = new MaterialSkin.Controls.MaterialLabel();
            this.ZLM_InstalledVersion_Label = new MaterialSkin.Controls.MaterialLabel();
            this.ZLM_LatestVersion_Label = new MaterialSkin.Controls.MaterialLabel();
            this.ZLM_Status_Label = new MaterialSkin.Controls.MaterialLabel();
            this.ZLM_Install_Button = new MaterialSkin.Controls.MaterialRaisedButton();
            this.ZLM_Uninstall_Button = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(104, 177);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(176, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Valheim Game Directory:";
            this.materialLabel2.Click += new System.EventHandler(this.materialLabel2_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(466, 308);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(52, 19);
            this.materialLabel3.TabIndex = 2;
            this.materialLabel3.Text = "Status";
            this.materialLabel3.Click += new System.EventHandler(this.materialLabel3_Click);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(104, 196);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(108, 19);
            this.materialLabel4.TabIndex = 3;
            this.materialLabel4.Text = "materialLabel4";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(444, 356);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(108, 19);
            this.materialLabel5.TabIndex = 4;
            this.materialLabel5.Text = "materialLabel5";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(129, 308);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(122, 19);
            this.materialLabel6.TabIndex = 5;
            this.materialLabel6.Text = "Installed Version";
            this.materialLabel6.Click += new System.EventHandler(this.materialLabel6_Click);
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(172, 356);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(108, 19);
            this.materialLabel7.TabIndex = 6;
            this.materialLabel7.Text = "materialLabel7";
            // 
            // materialRaisedButton4
            // 
            this.materialRaisedButton4.AutoSize = true;
            this.materialRaisedButton4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton4.Depth = 0;
            this.materialRaisedButton4.Icon = null;
            this.materialRaisedButton4.Location = new System.Drawing.Point(715, 348);
            this.materialRaisedButton4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton4.Name = "materialRaisedButton4";
            this.materialRaisedButton4.Primary = true;
            this.materialRaisedButton4.Size = new System.Drawing.Size(94, 36);
            this.materialRaisedButton4.TabIndex = 8;
            this.materialRaisedButton4.Text = "Uninstall";
            this.materialRaisedButton4.UseVisualStyleBackColor = true;
            this.materialRaisedButton4.Click += new System.EventHandler(this.materialRaisedButton4_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(289, 308);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(107, 19);
            this.materialLabel1.TabIndex = 10;
            this.materialLabel1.Text = "Latest Version";
            this.materialLabel1.Click += new System.EventHandler(this.materialLabel1_Click_1);
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.Location = new System.Drawing.Point(313, 356);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(108, 19);
            this.materialLabel9.TabIndex = 11;
            this.materialLabel9.Text = "materialLabel9";
            // 
            // materialProgressBar1
            // 
            this.materialProgressBar1.Depth = 0;
            this.materialProgressBar1.Location = new System.Drawing.Point(328, 759);
            this.materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialProgressBar1.Name = "materialProgressBar1";
            this.materialProgressBar1.Size = new System.Drawing.Size(304, 5);
            this.materialProgressBar1.TabIndex = 12;
            this.materialProgressBar1.Click += new System.EventHandler(this.materialProgressBar1_Click);
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.AutoSize = true;
            this.materialRaisedButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Icon = null;
            this.materialRaisedButton1.Location = new System.Drawing.Point(634, 348);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(75, 36);
            this.materialRaisedButton1.TabIndex = 13;
            this.materialRaisedButton1.Text = "Install";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.AutoSize = true;
            this.materialRaisedButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Icon = null;
            this.materialRaisedButton2.Location = new System.Drawing.Point(404, 779);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(144, 36);
            this.materialRaisedButton2.TabIndex = 14;
            this.materialRaisedButton2.Text = "Launch ZLalheim";
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            this.materialRaisedButton2.Click += new System.EventHandler(this.materialRaisedButton2_Click);
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(22, 356);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(97, 19);
            this.materialLabel8.TabIndex = 16;
            this.materialLabel8.Text = "Valheim Plus";
            this.materialLabel8.Click += new System.EventHandler(this.materialLabel8_Click_1);
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(12, 466);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(824, 237);
            this.materialDivider1.TabIndex = 18;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ZLheim_Modloader.Properties.Resources.Logo_ZLalheim_w300;
            this.pictureBox1.Location = new System.Drawing.Point(293, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(298, 98);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // BrowseFolderButton
            // 
            this.BrowseFolderButton.AutoSize = true;
            this.BrowseFolderButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BrowseFolderButton.Depth = 0;
            this.BrowseFolderButton.Icon = null;
            this.BrowseFolderButton.Location = new System.Drawing.Point(108, 218);
            this.BrowseFolderButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.BrowseFolderButton.Name = "BrowseFolderButton";
            this.BrowseFolderButton.Primary = true;
            this.BrowseFolderButton.Size = new System.Drawing.Size(76, 36);
            this.BrowseFolderButton.TabIndex = 19;
            this.BrowseFolderButton.Text = "Browse";
            this.BrowseFolderButton.UseVisualStyleBackColor = true;
            this.BrowseFolderButton.Click += new System.EventHandler(this.BrowseFolderButton_Click);
            // 
            // LaunchStatus_Label
            // 
            this.LaunchStatus_Label.AutoSize = true;
            this.LaunchStatus_Label.Depth = 0;
            this.LaunchStatus_Label.Font = new System.Drawing.Font("Roboto", 11F);
            this.LaunchStatus_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LaunchStatus_Label.Location = new System.Drawing.Point(398, 726);
            this.LaunchStatus_Label.MouseState = MaterialSkin.MouseState.HOVER;
            this.LaunchStatus_Label.Name = "LaunchStatus_Label";
            this.LaunchStatus_Label.Size = new System.Drawing.Size(143, 19);
            this.LaunchStatus_Label.TabIndex = 20;
            this.LaunchStatus_Label.Text = "LaunchStatus_Label";
            this.LaunchStatus_Label.Click += new System.EventHandler(this.LaunchStatus_Label_Click);
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel12.Location = new System.Drawing.Point(31, 813);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(36, 19);
            this.materialLabel12.TabIndex = 23;
            this.materialLabel12.Text = "v0.3";
            this.materialLabel12.Click += new System.EventHandler(this.materialLabel12_Click);
            // 
            // materialLabel13
            // 
            this.materialLabel13.AutoSize = true;
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel13.Location = new System.Drawing.Point(400, 147);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(85, 19);
            this.materialLabel13.TabIndex = 24;
            this.materialLabel13.Text = "ModLoader";
            // 
            // materialDivider2
            // 
            this.materialDivider2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider2.Depth = 0;
            this.materialDivider2.Location = new System.Drawing.Point(12, 279);
            this.materialDivider2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider2.Name = "materialDivider2";
            this.materialDivider2.Size = new System.Drawing.Size(824, 181);
            this.materialDivider2.TabIndex = 25;
            this.materialDivider2.Text = "materialDivider2";
            // 
            // ZLM_Lable
            // 
            this.ZLM_Lable.AutoSize = true;
            this.ZLM_Lable.Depth = 0;
            this.ZLM_Lable.Font = new System.Drawing.Font("Roboto", 11F);
            this.ZLM_Lable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ZLM_Lable.Location = new System.Drawing.Point(22, 522);
            this.ZLM_Lable.MouseState = MaterialSkin.MouseState.HOVER;
            this.ZLM_Lable.Name = "ZLM_Lable";
            this.ZLM_Lable.Size = new System.Drawing.Size(125, 19);
            this.ZLM_Lable.TabIndex = 26;
            this.ZLM_Lable.Text = "ZLhiem Modpack";
            this.ZLM_Lable.Click += new System.EventHandler(this.materialLabel10_Click_1);
            // 
            // ZLM_InstalledVersion_Label
            // 
            this.ZLM_InstalledVersion_Label.AutoSize = true;
            this.ZLM_InstalledVersion_Label.Depth = 0;
            this.ZLM_InstalledVersion_Label.Font = new System.Drawing.Font("Roboto", 11F);
            this.ZLM_InstalledVersion_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ZLM_InstalledVersion_Label.Location = new System.Drawing.Point(172, 522);
            this.ZLM_InstalledVersion_Label.MouseState = MaterialSkin.MouseState.HOVER;
            this.ZLM_InstalledVersion_Label.Name = "ZLM_InstalledVersion_Label";
            this.ZLM_InstalledVersion_Label.Size = new System.Drawing.Size(198, 19);
            this.ZLM_InstalledVersion_Label.TabIndex = 27;
            this.ZLM_InstalledVersion_Label.Text = "ZLM_InstalledVersion_Label";
            // 
            // ZLM_LatestVersion_Label
            // 
            this.ZLM_LatestVersion_Label.AutoSize = true;
            this.ZLM_LatestVersion_Label.Depth = 0;
            this.ZLM_LatestVersion_Label.Font = new System.Drawing.Font("Roboto", 11F);
            this.ZLM_LatestVersion_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ZLM_LatestVersion_Label.Location = new System.Drawing.Point(309, 522);
            this.ZLM_LatestVersion_Label.MouseState = MaterialSkin.MouseState.HOVER;
            this.ZLM_LatestVersion_Label.Name = "ZLM_LatestVersion_Label";
            this.ZLM_LatestVersion_Label.Size = new System.Drawing.Size(183, 19);
            this.ZLM_LatestVersion_Label.TabIndex = 28;
            this.ZLM_LatestVersion_Label.Text = "ZLM_LatestVersion_Label";
            // 
            // ZLM_Status_Label
            // 
            this.ZLM_Status_Label.AutoSize = true;
            this.ZLM_Status_Label.Depth = 0;
            this.ZLM_Status_Label.Font = new System.Drawing.Font("Roboto", 11F);
            this.ZLM_Status_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ZLM_Status_Label.Location = new System.Drawing.Point(444, 522);
            this.ZLM_Status_Label.MouseState = MaterialSkin.MouseState.HOVER;
            this.ZLM_Status_Label.Name = "ZLM_Status_Label";
            this.ZLM_Status_Label.Size = new System.Drawing.Size(132, 19);
            this.ZLM_Status_Label.TabIndex = 29;
            this.ZLM_Status_Label.Text = "ZLM_Status_Label";
            this.ZLM_Status_Label.Click += new System.EventHandler(this.EID_Status_Label_Click);
            // 
            // ZLM_Install_Button
            // 
            this.ZLM_Install_Button.AutoSize = true;
            this.ZLM_Install_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ZLM_Install_Button.Depth = 0;
            this.ZLM_Install_Button.Icon = null;
            this.ZLM_Install_Button.Location = new System.Drawing.Point(634, 505);
            this.ZLM_Install_Button.MouseState = MaterialSkin.MouseState.HOVER;
            this.ZLM_Install_Button.Name = "ZLM_Install_Button";
            this.ZLM_Install_Button.Primary = true;
            this.ZLM_Install_Button.Size = new System.Drawing.Size(75, 36);
            this.ZLM_Install_Button.TabIndex = 30;
            this.ZLM_Install_Button.Text = "Install";
            this.ZLM_Install_Button.UseVisualStyleBackColor = true;
            this.ZLM_Install_Button.Click += new System.EventHandler(this.ZLM_Install_Button_Click);
            // 
            // ZLM_Uninstall_Button
            // 
            this.ZLM_Uninstall_Button.AutoSize = true;
            this.ZLM_Uninstall_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ZLM_Uninstall_Button.Depth = 0;
            this.ZLM_Uninstall_Button.Icon = null;
            this.ZLM_Uninstall_Button.Location = new System.Drawing.Point(715, 505);
            this.ZLM_Uninstall_Button.MouseState = MaterialSkin.MouseState.HOVER;
            this.ZLM_Uninstall_Button.Name = "ZLM_Uninstall_Button";
            this.ZLM_Uninstall_Button.Primary = true;
            this.ZLM_Uninstall_Button.Size = new System.Drawing.Size(94, 36);
            this.ZLM_Uninstall_Button.TabIndex = 31;
            this.ZLM_Uninstall_Button.Text = "Uninstall";
            this.ZLM_Uninstall_Button.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(848, 841);
            this.Controls.Add(this.ZLM_Uninstall_Button);
            this.Controls.Add(this.ZLM_Install_Button);
            this.Controls.Add(this.ZLM_Status_Label);
            this.Controls.Add(this.ZLM_LatestVersion_Label);
            this.Controls.Add(this.ZLM_InstalledVersion_Label);
            this.Controls.Add(this.ZLM_Lable);
            this.Controls.Add(this.materialLabel13);
            this.Controls.Add(this.materialLabel12);
            this.Controls.Add(this.LaunchStatus_Label);
            this.Controls.Add(this.BrowseFolderButton);
            this.Controls.Add(this.materialLabel8);
            this.Controls.Add(this.materialRaisedButton2);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.materialProgressBar1);
            this.Controls.Add(this.materialLabel9);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialRaisedButton4);
            this.Controls.Add(this.materialLabel7);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.materialDivider2);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton4;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private MaterialSkin.Controls.MaterialRaisedButton BrowseFolderButton;
        private MaterialSkin.Controls.MaterialLabel LaunchStatus_Label;
        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private MaterialSkin.Controls.MaterialDivider materialDivider2;
        private MaterialSkin.Controls.MaterialLabel ZLM_Lable;
        private MaterialSkin.Controls.MaterialLabel ZLM_InstalledVersion_Label;
        private MaterialSkin.Controls.MaterialLabel ZLM_LatestVersion_Label;
        private MaterialSkin.Controls.MaterialLabel ZLM_Status_Label;
        private MaterialSkin.Controls.MaterialRaisedButton ZLM_Install_Button;
        private MaterialSkin.Controls.MaterialRaisedButton ZLM_Uninstall_Button;
    }
}

