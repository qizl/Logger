namespace LogAnalyzer
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
            this.plHead = new System.Windows.Forms.Panel();
            this.lblOpenFileDescribe = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpenFiles = new System.Windows.Forms.Button();
            this.plBody = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabFinds = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpBeginTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbxTypes = new System.Windows.Forms.ComboBox();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabResultAnaylze = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.plFoot = new System.Windows.Forms.Panel();
            this.lblFindDescribe = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgvResultclmTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvResultclmType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvResultclmDescribe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plHead.SuspendLayout();
            this.plBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabFinds.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.plHead.Size = new System.Drawing.Size(1046, 121);
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
            this.btnClose.Location = new System.Drawing.Point(231, 22);
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
            this.plBody.Size = new System.Drawing.Size(1046, 509);
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
            this.splitContainer1.Size = new System.Drawing.Size(1046, 509);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabFinds
            // 
            this.tabFinds.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabFinds.Controls.Add(this.tabPage1);
            this.tabFinds.Controls.Add(this.tabPage2);
            this.tabFinds.Controls.Add(this.tabPage3);
            this.tabFinds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFinds.Location = new System.Drawing.Point(0, 0);
            this.tabFinds.Name = "tabFinds";
            this.tabFinds.SelectedIndex = 0;
            this.tabFinds.Size = new System.Drawing.Size(1046, 200);
            this.tabFinds.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtpEndTime);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dtpBeginTime);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1038, 166);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "时间段检索";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.tabPage2.Controls.Add(this.cbxTypes);
            this.tabPage2.Controls.Add(this.txtKeywords);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1038, 171);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "关键字检索";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbxTypes
            // 
            this.cbxTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTypes.FormattingEnabled = true;
            this.cbxTypes.Items.AddRange(new object[] {
            "All",
            "Normal",
            "Error"});
            this.cbxTypes.Location = new System.Drawing.Point(139, 107);
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
            this.label5.Location = new System.Drawing.Point(45, 111);
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
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1038, 171);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "高级检索";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            this.tabResultAnaylze.Size = new System.Drawing.Size(1046, 305);
            this.tabResultAnaylze.TabIndex = 6;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvResult);
            this.tabPage4.Controls.Add(this.plFoot);
            this.tabPage4.Location = new System.Drawing.Point(4, 30);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1038, 271);
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
            this.dgvResult.Size = new System.Drawing.Size(1032, 144);
            this.dgvResult.TabIndex = 7;
            this.dgvResult.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvResult_RowPostPaint);
            // 
            // plFoot
            // 
            this.plFoot.Controls.Add(this.lblFindDescribe);
            this.plFoot.Controls.Add(this.btnExport);
            this.plFoot.Controls.Add(this.btnFind);
            this.plFoot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plFoot.Location = new System.Drawing.Point(3, 147);
            this.plFoot.Name = "plFoot";
            this.plFoot.Size = new System.Drawing.Size(1032, 121);
            this.plFoot.TabIndex = 0;
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
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(224, 22);
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
            this.tabPage5.Size = new System.Drawing.Size(1038, 276);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "数据分析";
            this.tabPage5.UseVisualStyleBackColor = true;
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 630);
            this.Controls.Add(this.plBody);
            this.Controls.Add(this.plHead);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "日志分析器";
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
        private System.Windows.Forms.TabPage tabPage3;
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
    }
}

