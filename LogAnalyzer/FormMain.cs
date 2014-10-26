using LogAnalyzer.Models;
using Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogAnalyzer
{
    public partial class FormMain : Form
    {
        private string[] _logdFilesPath = null;
        private List<Log> _logs = new List<Log>();

        private List<Log> _logsResult = new List<Log>();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.initialize();
        }
        void initialize()
        {
            Common.Config = Config.Read(Common.ConfigPath);
            if (Common.Config == null)
                Common.Config = Common.DefaultConfig;
            Common.Config.UpdateTime = DateTime.Now;
            Config.Save(Common.Config, Common.ConfigPath);

            //this.dtpBeginTime.Value = Common.Config.BeginTime;
            //this.dtpEndTime.Value = Common.Config.EndTime;
            //this.txtKeywords.Text = Common.Config.Keywords;
            //this.cbxTypes.Text = Common.Config.Type.ToString();
        }

        private void btnOpenFiles_Click(object sender, EventArgs e)
        {
            string defaultFolder = Path.Combine(Environment.CurrentDirectory, "Logs");
            if (!Directory.Exists(defaultFolder))
                Directory.CreateDirectory(defaultFolder);

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = defaultFolder;
                dialog.Multiselect = true;
                dialog.Title = "请选择日志文件：";
                dialog.Filter = "日志文件(*.log)|*.log|文本文件(*.txt)|*.txt";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this._logdFilesPath = dialog.FileNames;

                    this.readLogs();
                    this.bindlingDatas();
                }
            }
        }
        void readLogs()
        {
            this._logs.Clear();
            Logs logDal = new Logs();
            foreach (var item in this._logdFilesPath)
            {
                if (File.Exists(item))
                {
                    List<Log> logs = logDal.Read(item);
                    this._logs.AddRange(logs);
                }
            }

            this._logsResult.Clear();
            this._logsResult.AddRange(this._logs);
        }
        void bindlingDatas()
        {
            int amounts = this._logdFilesPath == null ? 0 : this._logdFilesPath.Length;
            float size = 0;
            if (this._logdFilesPath != null && this._logdFilesPath.Length > 0)
                foreach (var item in this._logdFilesPath)
                {
                    FileInfo file = new FileInfo(item);
                    size += file.Length;
                }
            size = size / 1024f / 1024f;

            this.lblOpenFileDescribe.Text = "共打开" + amounts + "个文件，读取到日志数据" + this._logs.Count + "行，总字节大小" + size + "M";

            this.txtKeywords.ResetText();
            this.cbxTypes.SelectedIndex = 0;
            if (this._logs.Count != 0)
            {
                this._logs = this._logs.OrderBy(l => l.Time).ToList();
                this.dtpBeginTime.Value = this._logs.First().Time;
                this.dtpEndTime.Value = this._logs.Last().Time;
            }

            this.bindlingResult();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this._logdFilesPath = null;
            this._logs.Clear();
            this._logsResult.Clear();
            this.bindlingDatas();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.find();

            this.bindlingResult();
        }
        void find()
        {
            // 保存查询字段
            this.saveConfig();

            /*
             * 时间段检索
             */
            this._logsResult = this._logs.Where(l => l.Time >= this.dtpBeginTime.Value && l.Time <= this.dtpEndTime.Value).ToList();

            /*
             * 关键字检索
             */
            string[] keywords = this.txtKeywords.Text.Split(',');
            if (keywords.Length > 0)
            {
                foreach (var item in keywords)
                {
                    if (!string.IsNullOrEmpty(item))
                        this._logsResult = this._logsResult.Where(l => l.Describe.Contains(item)).ToList();
                }
            }
            if (this.cbxTypes.Text != LogTypes.All.ToString())
            {
                LogTypes type = (LogTypes)Enum.Parse(typeof(LogTypes), this.cbxTypes.Text);
                this._logsResult = this._logsResult.Where(l => l.Type == type).ToList();
            }

            /*
             * 高级检索
             */
        }
        void bindlingResult()
        {
            this.dgvResult.Rows.Clear();
            this.lblFindDescribe.Text = "共检索到数据" + this._logsResult.Count + "行";
            this.btnExport.Text = "导出";

            if (this._logsResult.Count == 0)
                return;

            this._logsResult = this._logsResult.OrderBy(l => l.Time).ToList();

            foreach (var item in this._logsResult)
                this.dgvResult.Rows.Add(string.Format("{0:D4}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2} {6:D3}", new object[] { item.Time.Year, item.Time.Month, item.Time.Day, item.Time.Hour, item.Time.Minute, item.Time.Second, item.Time.Millisecond }), item.Type, item.Describe);
        }
        void saveConfig()
        {
            Common.Config.BeginTime = this.dtpBeginTime.Value;
            Common.Config.EndTime = this.dtpEndTime.Value;
            Common.Config.Keywords = this.txtKeywords.Text;
            Common.Config.Type = (LogTypes)Enum.Parse(typeof(LogTypes), this.cbxTypes.Text);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this._logdFilesPath != null && this._logdFilesPath.Length > 0)
                if (this.btnExport.Text == "导出")
                    using (SaveFileDialog dialog = new SaveFileDialog())
                    {
                        dialog.Title = "请选择保存路径:";
                        dialog.Filter = "日志文件(*.log)|*.log|文本文件(*.txt)|*.txt";
                        dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        dialog.FileName = new FileInfo(this._logdFilesPath[0]).Name;
                        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            Logs log = new Logs(dialog.FileName, 0);
                            foreach (var item in this._logsResult)
                                log.WriteLine(item.Time, item.Type != LogTypes.All && item.Type != LogTypes.Normal ? item.Type.ToString() + ":" : "" + item.Describe);
                        }

                        this.btnExport.Text = "完成";
                    }
        }

        private void dgvResult_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(this.dgvResult.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString(
                (e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture),
                this.dgvResult.DefaultCellStyle.Font,
                b,
                e.RowBounds.Location.X + 10,
                e.RowBounds.Location.Y + 4);
        }
    }
}
