namespace Com.EnjoyCodes.LogAnalyzer
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.plHead = new System.Windows.Forms.Panel();
            this.lblOpenFileDescribe = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpenFiles = new System.Windows.Forms.Button();
            this.plBody = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabFinds = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnResetFindTime = new System.Windows.Forms.Button();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpBeginTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ckxIgnoreCase = new System.Windows.Forms.CheckBox();
            this.cbxTypes = new System.Windows.Forms.ComboBox();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabFindsAdvanced = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.ckxIncludeNearKeywords = new System.Windows.Forms.CheckBox();
            this.ckxIncludeKeywords = new System.Windows.Forms.CheckBox();
            this.nudNearFindRegion = new System.Windows.Forms.NumericUpDown();
            this.txtNearFindKeywords = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ckxEnabledNearFind = new System.Windows.Forms.CheckBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.cbxLogsFolders = new System.Windows.Forms.ComboBox();
            this.btnRefreshListen = new System.Windows.Forms.Button();
            this.btnStopListen = new System.Windows.Forms.Button();
            this.btnStartListen = new System.Windows.Forms.Button();
            this.btnChooseLogsFolder = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tabResultAnaylze = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.dgvResultclmTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvResultclmType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvResultclmDescribe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plFoot = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.lblFindDescribe = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.plHead.SuspendLayout();
            this.plBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabFinds.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabFindsAdvanced.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNearFindRegion)).BeginInit();
            this.tabPage9.SuspendLayout();
            this.tabResultAnaylze.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.plFoot.SuspendLayout();
            this.SuspendLayout();
            // 
            // plHead
            // 
            this.plHead.Controls.Add(this.lblOpenFileDescribe);
            this.plHead.Controls.Add(this.btnClose);
            this.plHead.Controls.Add(this.btnOpenFiles);
            this.plHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.plHead.Location = new System.Drawing.Point(0, 0);
            this.plHead.Name = "plHead";
            this.plHead.Size = new System.Drawing.Size(1084, 121);
            this.plHead.TabIndex = 0;
            // 
            // lblOpenFileDescribe
            // 
            this.lblOpenFileDescribe.AutoSize = true;
            this.lblOpenFileDescribe.Location = new System.Drawing.Point(45, 85);
            this.lblOpenFileDescribe.Name = "lblOpenFileDescribe";
            this.lblOpenFileDescribe.Size = new System.Drawing.Size(384, 18);
            this.lblOpenFileDescribe.TabIndex = 1;
            this.lblOpenFileDescribe.Text = "共打开0个文件，读取到日志数据0行，总字节大小0M";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(227, 22);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 43);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭文件";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpenFiles
            // 
            this.btnOpenFiles.Location = new System.Drawing.Point(45, 22);
            this.btnOpenFiles.Name = "btnOpenFiles";
            this.btnOpenFiles.Size = new System.Drawing.Size(119, 43);
            this.btnOpenFiles.TabIndex = 0;
            this.btnOpenFiles.Text = "打开文件";
            this.btnOpenFiles.UseVisualStyleBackColor = true;
            this.btnOpenFiles.Click += new System.EventHandler(this.btnOpenFiles_Click);
            // 
            // plBody
            // 
            this.plBody.Controls.Add(this.splitContainer1);
            this.plBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plBody.Location = new System.Drawing.Point(0, 121);
            this.plBody.Name = "plBody";
            this.plBody.Size = new System.Drawing.Size(1084, 629);
            this.plBody.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabFinds);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabResultAnaylze);
            this.splitContainer1.Size = new System.Drawing.Size(1084, 629);
            this.splitContainer1.SplitterDistance = 155;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabFinds
            // 
            this.tabFinds.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabFinds.Controls.Add(this.tabPage1);
            this.tabFinds.Controls.Add(this.tabPage2);
            this.tabFinds.Controls.Add(this.tabPage3);
            this.tabFinds.Controls.Add(this.tabPage9);
            this.tabFinds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFinds.Location = new System.Drawing.Point(0, 0);
            this.tabFinds.Name = "tabFinds";
            this.tabFinds.SelectedIndex = 0;
            this.tabFinds.Size = new System.Drawing.Size(1084, 155);
            this.tabFinds.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnResetFindTime);
            this.tabPage1.Controls.Add(this.dtpEndTime);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dtpBeginTime);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1076, 121);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "时间段检索";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnResetFindTime
            // 
            this.btnResetFindTime.Font = new System.Drawing.Font("Arial", 10F);
            this.btnResetFindTime.Location = new System.Drawing.Point(139, 90);
            this.btnResetFindTime.Name = "btnResetFindTime";
            this.btnResetFindTime.Size = new System.Drawing.Size(75, 26);
            this.btnResetFindTime.TabIndex = 5;
            this.btnResetFindTime.Text = "重置";
            this.btnResetFindTime.UseVisualStyleBackColor = true;
            this.btnResetFindTime.Click += new System.EventHandler(this.btnResetFindTime_Click);
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(139, 60);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(207, 26);
            this.dtpEndTime.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "终止时间：";
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBeginTime.Location = new System.Drawing.Point(139, 18);
            this.dtpBeginTime.Name = "dtpBeginTime";
            this.dtpBeginTime.Size = new System.Drawing.Size(207, 26);
            this.dtpBeginTime.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "起始时间：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ckxIgnoreCase);
            this.tabPage2.Controls.Add(this.cbxTypes);
            this.tabPage2.Controls.Add(this.txtKeywords);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1076, 216);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "关键字检索";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ckxIgnoreCase
            // 
            this.ckxIgnoreCase.AutoSize = true;
            this.ckxIgnoreCase.Checked = true;
            this.ckxIgnoreCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckxIgnoreCase.Location = new System.Drawing.Point(139, 101);
            this.ckxIgnoreCase.Name = "ckxIgnoreCase";
            this.ckxIgnoreCase.Size = new System.Drawing.Size(107, 22);
            this.ckxIgnoreCase.TabIndex = 7;
            this.ckxIgnoreCase.Text = "忽略大小写";
            this.ckxIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // cbxTypes
            // 
            this.cbxTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTypes.FormattingEnabled = true;
            this.cbxTypes.Items.AddRange(new object[] {
            "All",
            "Normal",
            "Error"});
            this.cbxTypes.Location = new System.Drawing.Point(139, 128);
            this.cbxTypes.Name = "cbxTypes";
            this.cbxTypes.Size = new System.Drawing.Size(121, 26);
            this.cbxTypes.TabIndex = 6;
            // 
            // txtKeywords
            // 
            this.txtKeywords.Location = new System.Drawing.Point(139, 18);
            this.txtKeywords.Multiline = true;
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.Size = new System.Drawing.Size(640, 76);
            this.txtKeywords.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(785, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "* 使用逗号分隔关键字";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "关键字：";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tabFindsAdvanced);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1076, 216);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "高级检索";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabFindsAdvanced
            // 
            this.tabFindsAdvanced.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabFindsAdvanced.Controls.Add(this.tabPage6);
            this.tabFindsAdvanced.Controls.Add(this.tabPage8);
            this.tabFindsAdvanced.Controls.Add(this.tabPage7);
            this.tabFindsAdvanced.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFindsAdvanced.Location = new System.Drawing.Point(0, 0);
            this.tabFindsAdvanced.Name = "tabFindsAdvanced";
            this.tabFindsAdvanced.SelectedIndex = 0;
            this.tabFindsAdvanced.Size = new System.Drawing.Size(1076, 216);
            this.tabFindsAdvanced.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.ckxIncludeNearKeywords);
            this.tabPage6.Controls.Add(this.ckxIncludeKeywords);
            this.tabPage6.Controls.Add(this.nudNearFindRegion);
            this.tabPage6.Controls.Add(this.txtNearFindKeywords);
            this.tabPage6.Controls.Add(this.label7);
            this.tabPage6.Controls.Add(this.label8);
            this.tabPage6.Controls.Add(this.label9);
            this.tabPage6.Controls.Add(this.label6);
            this.tabPage6.Controls.Add(this.ckxEnabledNearFind);
            this.tabPage6.Location = new System.Drawing.Point(4, 30);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1068, 182);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "临近检索";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // ckxIncludeNearKeywords
            // 
            this.ckxIncludeNearKeywords.AutoSize = true;
            this.ckxIncludeNearKeywords.Checked = true;
            this.ckxIncludeNearKeywords.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckxIncludeNearKeywords.Location = new System.Drawing.Point(427, 144);
            this.ckxIncludeNearKeywords.Name = "ckxIncludeNearKeywords";
            this.ckxIncludeNearKeywords.Size = new System.Drawing.Size(139, 22);
            this.ckxIncludeNearKeywords.TabIndex = 14;
            this.ckxIncludeNearKeywords.Text = "包含临近关键字";
            this.ckxIncludeNearKeywords.UseVisualStyleBackColor = true;
            // 
            // ckxIncludeKeywords
            // 
            this.ckxIncludeKeywords.AutoSize = true;
            this.ckxIncludeKeywords.Checked = true;
            this.ckxIncludeKeywords.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckxIncludeKeywords.Location = new System.Drawing.Point(317, 144);
            this.ckxIncludeKeywords.Name = "ckxIncludeKeywords";
            this.ckxIncludeKeywords.Size = new System.Drawing.Size(107, 22);
            this.ckxIncludeKeywords.TabIndex = 14;
            this.ckxIncludeKeywords.Text = "包含关键字";
            this.ckxIncludeKeywords.UseVisualStyleBackColor = true;
            // 
            // nudNearFindRegion
            // 
            this.nudNearFindRegion.Location = new System.Drawing.Point(139, 142);
            this.nudNearFindRegion.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNearFindRegion.Name = "nudNearFindRegion";
            this.nudNearFindRegion.Size = new System.Drawing.Size(120, 26);
            this.nudNearFindRegion.TabIndex = 13;
            // 
            // txtNearFindKeywords
            // 
            this.txtNearFindKeywords.Location = new System.Drawing.Point(139, 52);
            this.txtNearFindKeywords.Multiline = true;
            this.txtNearFindKeywords.Name = "txtNearFindKeywords";
            this.txtNearFindKeywords.Size = new System.Drawing.Size(640, 76);
            this.txtNearFindKeywords.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(785, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 18);
            this.label7.TabIndex = 10;
            this.label7.Text = "* 使用逗号分隔关键字";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 18);
            this.label8.TabIndex = 11;
            this.label8.Text = "临近关键字：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(259, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 18);
            this.label9.TabIndex = 9;
            this.label9.Text = "行";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "范围：";
            // 
            // ckxEnabledNearFind
            // 
            this.ckxEnabledNearFind.AutoSize = true;
            this.ckxEnabledNearFind.Location = new System.Drawing.Point(45, 22);
            this.ckxEnabledNearFind.Name = "ckxEnabledNearFind";
            this.ckxEnabledNearFind.Size = new System.Drawing.Size(459, 22);
            this.ckxEnabledNearFind.TabIndex = 8;
            this.ckxEnabledNearFind.Text = "启用（在关键字检索所设定的关键字查询结果附近进行检索）";
            this.ckxEnabledNearFind.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 25);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1068, 192);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "正则匹配";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 25);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1068, 192);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "插件处理";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.cbxLogsFolders);
            this.tabPage9.Controls.Add(this.btnRefreshListen);
            this.tabPage9.Controls.Add(this.btnStopListen);
            this.tabPage9.Controls.Add(this.btnStartListen);
            this.tabPage9.Controls.Add(this.btnChooseLogsFolder);
            this.tabPage9.Controls.Add(this.label10);
            this.tabPage9.Location = new System.Drawing.Point(4, 30);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(1076, 121);
            this.tabPage9.TabIndex = 3;
            this.tabPage9.Text = "日志监听";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // cbxLogsFolders
            // 
            this.cbxLogsFolders.FormattingEnabled = true;
            this.cbxLogsFolders.Location = new System.Drawing.Point(139, 18);
            this.cbxLogsFolders.Name = "cbxLogsFolders";
            this.cbxLogsFolders.Size = new System.Drawing.Size(640, 26);
            this.cbxLogsFolders.TabIndex = 3;
            // 
            // btnRefreshListen
            // 
            this.btnRefreshListen.Font = new System.Drawing.Font("Arial", 10F);
            this.btnRefreshListen.Location = new System.Drawing.Point(213, 90);
            this.btnRefreshListen.Name = "btnRefreshListen";
            this.btnRefreshListen.Size = new System.Drawing.Size(75, 26);
            this.btnRefreshListen.TabIndex = 7;
            this.btnRefreshListen.Text = "刷新";
            this.btnRefreshListen.UseVisualStyleBackColor = true;
            this.btnRefreshListen.Click += new System.EventHandler(this.btnRefreshListen_Click);
            // 
            // btnStopListen
            // 
            this.btnStopListen.Font = new System.Drawing.Font("Arial", 10F);
            this.btnStopListen.Location = new System.Drawing.Point(132, 90);
            this.btnStopListen.Name = "btnStopListen";
            this.btnStopListen.Size = new System.Drawing.Size(75, 26);
            this.btnStopListen.TabIndex = 7;
            this.btnStopListen.Text = "停止";
            this.btnStopListen.UseVisualStyleBackColor = true;
            this.btnStopListen.Click += new System.EventHandler(this.btnStopListen_Click);
            // 
            // btnStartListen
            // 
            this.btnStartListen.Font = new System.Drawing.Font("Arial", 10F);
            this.btnStartListen.Location = new System.Drawing.Point(51, 90);
            this.btnStartListen.Name = "btnStartListen";
            this.btnStartListen.Size = new System.Drawing.Size(75, 26);
            this.btnStartListen.TabIndex = 7;
            this.btnStartListen.Text = "启动";
            this.btnStartListen.UseVisualStyleBackColor = true;
            this.btnStartListen.Click += new System.EventHandler(this.btnStartListen_Click);
            // 
            // btnChooseLogsFolder
            // 
            this.btnChooseLogsFolder.Font = new System.Drawing.Font("Arial", 10F);
            this.btnChooseLogsFolder.Location = new System.Drawing.Point(139, 50);
            this.btnChooseLogsFolder.Name = "btnChooseLogsFolder";
            this.btnChooseLogsFolder.Size = new System.Drawing.Size(75, 26);
            this.btnChooseLogsFolder.TabIndex = 6;
            this.btnChooseLogsFolder.Text = "浏览...";
            this.btnChooseLogsFolder.UseVisualStyleBackColor = true;
            this.btnChooseLogsFolder.Click += new System.EventHandler(this.btnChooseLogsFolder_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(45, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 18);
            this.label10.TabIndex = 2;
            this.label10.Text = "日志目录：";
            // 
            // tabResultAnaylze
            // 
            this.tabResultAnaylze.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabResultAnaylze.Controls.Add(this.tabPage4);
            this.tabResultAnaylze.Controls.Add(this.tabPage5);
            this.tabResultAnaylze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResultAnaylze.Location = new System.Drawing.Point(0, 0);
            this.tabResultAnaylze.Name = "tabResultAnaylze";
            this.tabResultAnaylze.SelectedIndex = 0;
            this.tabResultAnaylze.Size = new System.Drawing.Size(1084, 470);
            this.tabResultAnaylze.TabIndex = 6;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvResult);
            this.tabPage4.Controls.Add(this.plFoot);
            this.tabPage4.Location = new System.Drawing.Point(4, 30);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1076, 436);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "检索结果";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvResultclmTime,
            this.dgvResultclmType,
            this.dgvResultclmDescribe});
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(3, 3);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowHeadersWidth = 50;
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.Size = new System.Drawing.Size(1070, 309);
            this.dgvResult.TabIndex = 7;
            this.dgvResult.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvResult_RowPostPaint);
            // 
            // dgvResultclmTime
            // 
            this.dgvResultclmTime.HeaderText = "时间";
            this.dgvResultclmTime.Name = "dgvResultclmTime";
            this.dgvResultclmTime.Width = 200;
            // 
            // dgvResultclmType
            // 
            this.dgvResultclmType.HeaderText = "类型";
            this.dgvResultclmType.Name = "dgvResultclmType";
            // 
            // dgvResultclmDescribe
            // 
            this.dgvResultclmDescribe.HeaderText = "描述";
            this.dgvResultclmDescribe.Name = "dgvResultclmDescribe";
            this.dgvResultclmDescribe.Width = 800;
            // 
            // plFoot
            // 
            this.plFoot.Controls.Add(this.btnHelp);
            this.plFoot.Controls.Add(this.lblFindDescribe);
            this.plFoot.Controls.Add(this.btnReset);
            this.plFoot.Controls.Add(this.btnExport);
            this.plFoot.Controls.Add(this.btnFind);
            this.plFoot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plFoot.Location = new System.Drawing.Point(3, 312);
            this.plFoot.Name = "plFoot";
            this.plFoot.Size = new System.Drawing.Size(1070, 121);
            this.plFoot.TabIndex = 0;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(591, 22);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(119, 43);
            this.btnHelp.TabIndex = 11;
            this.btnHelp.Text = "帮助";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // lblFindDescribe
            // 
            this.lblFindDescribe.AutoSize = true;
            this.lblFindDescribe.Location = new System.Drawing.Point(45, 85);
            this.lblFindDescribe.Name = "lblFindDescribe";
            this.lblFindDescribe.Size = new System.Drawing.Size(161, 18);
            this.lblFindDescribe.TabIndex = 10;
            this.lblFindDescribe.Text = "共检索到日志数据0行";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(409, 22);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(119, 43);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(227, 22);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(119, 43);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(45, 22);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(119, 43);
            this.btnFind.TabIndex = 8;
            this.btnFind.Text = "检索";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1076, 346);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "数据分析";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 750);
            this.Controls.Add(this.plBody);
            this.Controls.Add(this.plHead);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "日志分析器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.plHead.ResumeLayout(false);
            this.plHead.PerformLayout();
            this.plBody.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabFinds.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabFindsAdvanced.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNearFindRegion)).EndInit();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.tabResultAnaylze.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.plFoot.ResumeLayout(false);
            this.plFoot.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plHead;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpenFiles;
        private System.Windows.Forms.Label lblOpenFileDescribe;
        private System.Windows.Forms.Panel plBody;
        private System.Windows.Forms.TabControl tabFinds;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabResultAnaylze;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel plFoot;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpBeginTime;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxTypes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFindDescribe;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvResultclmTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvResultclmType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvResultclmDescribe;
        private System.Windows.Forms.CheckBox ckxIgnoreCase;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabControl tabFindsAdvanced;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.CheckBox ckxEnabledNearFind;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.NumericUpDown nudNearFindRegion;
        private System.Windows.Forms.TextBox txtNearFindKeywords;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnResetFindTime;
        private System.Windows.Forms.CheckBox ckxIncludeNearKeywords;
        private System.Windows.Forms.CheckBox ckxIncludeKeywords;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.Button btnChooseLogsFolder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnStopListen;
        private System.Windows.Forms.Button btnStartListen;
        private System.Windows.Forms.Button btnRefreshListen;
        private System.Windows.Forms.ComboBox cbxLogsFolders;
        private System.Windows.Forms.Button btnHelp;
    }
}

