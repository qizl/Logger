using Com.EnjoyCodes.Logger;
using Com.EnjoyCodes.LogAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Com.EnjoyCodes.LogAnalyzer
{
    public partial class FormMain : Form
    {
        #region Members
        private string[] _logdFilesPath;
        private List<Log> _logs = new List<Log>();

        private List<Log> _logsResult = new List<Log>();

        /// <summary>
        /// 日志监听器
        /// </summary>
        private FileSystemWatcher _watcher;
        private delegate void ArgsStrHandler(string str);
        /// <summary>
        /// 日志监听 - 上次加载日志的时间
        /// </summary>
        private DateTime _lastUpdateTime = DateTime.Now;
        #endregion

        #region Structures
        public FormMain()
        {
            InitializeComponent();
        }
        #endregion

        #region Formload
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.initialize();
        }
        void initialize()
        {
            Common.Config = Config.Load(Common.ConfigPath);
            if (Common.Config == null)
                Common.Config = Common.DefaultConfig;
            Common.Config.UpdateTime = DateTime.Now;
            Common.Config.Save(Common.ConfigPath);

            //this.dtpBeginTime.Value = Common.Config.BeginTime;
            //this.dtpEndTime.Value = Common.Config.EndTime;
            //this.txtKeywords.Text = Common.Config.Keywords;
            this.cbxTypes.Text = LogTypes.All.ToString();
            this.ckxIgnoreCase.Checked = Common.Config.IgnoreCase;
            this.ckxEnabledNearFind.Checked = false;
            this.txtNearFindKeywords.Text = Common.Config.NearFindKeywords;
            this.nudNearFindRegion.Value = Common.Config.NearFindRegion;
            this.ckxIncludeKeywords.Checked = Common.Config.IncludeKeywords;
            this.ckxIncludeNearKeywords.Checked = Common.Config.IncludeNearKeywords;

            if (Common.Config.LogsFolders == null)
                Common.Config.LogsFolders = new List<string>();

            this.cbxLogsFolders.Items.AddRange(Common.Config.LogsFolders.ToArray());
            this.cbxLogsFolders.SelectedIndex = Common.Config.LogsFolders.Count > 0 ? 0 : -1;
        }
        #endregion

        #region Methods Source Files Controls
        private void btnOpenFiles_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = true;
                dialog.InitialDirectory = Common.Config.LogsFolders[0];
                dialog.Title = "请选择日志文件：";
                dialog.Filter = "日志文件(*.log)|*.log|文本文件(*.txt)|*.txt";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this._logdFilesPath = dialog.FileNames;

                    this.readLogs();
                    this.bindingDatas();
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
        void bindingDatas()
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

            if (this._watcher != null && this._watcher.EnableRaisingEvents)
            {
                // 显示监听文件信息
                this.lblOpenFileDescribe.Text = "正在监听文件夹:" + this.cbxLogsFolders.Text + "...";
            }
            else
            {
                // 显示手动打开文件信息
                this.lblOpenFileDescribe.Text = "共打开" + amounts + "个文件，读取到日志数据" + this._logs.Count + "行，总字节大小" + size + "M";
            }

            this.txtKeywords.ResetText();
            this.cbxTypes.SelectedIndex = 0;
            if (this._logs.Count != 0)
            {
                this._logs = this._logs.OrderBy(l => l.Time).ToList();
                this.dtpBeginTime.Value = this._logs.First().Time;
                this.dtpEndTime.Value = this._logs.Last().Time;
            }

            this.ckxEnabledNearFind.Checked = false;

            this.bindingResult();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.close();
        }
        /// <summary>
        /// 清空检索缓存
        /// </summary>
        void close()
        {
            this._logdFilesPath = null;
            this._logs.Clear();
            this._logsResult.Clear();
            this.bindingDatas();
        }
        #endregion

        #region Methods Find
        /// <summary>
        /// 重置查询时间段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResetFindTime_Click(object sender, EventArgs e)
        {
            if (this._logs.Count != 0)
            {
                this._logs = this._logs.OrderBy(l => l.Time).ToList();
                this.dtpBeginTime.Value = this._logs.First().Time;
                this.dtpEndTime.Value = this._logs.Last().Time;
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

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.find();

            this.bindingResult();
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
                // 查询改为条件或
                foreach (var item in keywords)
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        if (this.ckxIgnoreCase.Checked)
                            this._logsResult = this._logsResult.Where(l => l.Describe.ToLower().Contains(item.ToLower())).ToList();
                        else
                            this._logsResult = this._logsResult.Where(l => l.Describe.Contains(item)).ToList();
                    }
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
            // 临近检索
            if (this.ckxEnabledNearFind.Checked)
            {
                string[] nearfindKeywords = this.txtNearFindKeywords.Text.Split(',');
                int nearfindRegion = (int)this.nudNearFindRegion.Value;

                List<Log> result = new List<Log>();
                foreach (var item in this._logsResult)
                {
                    int index = this._logs.IndexOf(item);
                    int startIndex = index - nearfindRegion < 0 ? 0 : index - nearfindRegion;
                    int count = startIndex + nearfindRegion * 2 > this._logs.Count - 1 ? this._logs.Count - 1 - (startIndex + nearfindRegion * 2) : nearfindRegion * 2;

                    if (this.ckxIncludeKeywords.Checked)
                        result.Add(this._logs[index]);

                    foreach (var nearfindKeyword in nearfindKeywords)
                        for (int i = startIndex; i < startIndex + count; i++)
                        {
                            int nIndex = this._logs.FindIndex(i, 1, l => l.Describe.ToLower().Contains(nearfindKeyword.ToLower()));
                            if (nIndex != index && nIndex != -1 && this.ckxIncludeNearKeywords.Checked)
                                result.Add(this._logs[nIndex]);
                        }
                }

                result = result.Distinct().ToList();

                this._logsResult.Clear();
                this._logsResult.AddRange(result);
            }
        }
        void bindingResult()
        {
            this.dgvResult.Rows.Clear();
            this.lblFindDescribe.Text = "共检索到数据" + this._logsResult.Count + "行";
            this.btnExport.Text = "导出";

            if (this._logsResult.Count == 0)
                return;

            this._logsResult = this._logsResult.OrderByDescending(l => l.Time).ToList();

            foreach (var item in this._logsResult)
                this.dgvResult.Rows.Add(string.Format("{0:D4}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2} {6:D3}", new object[] { item.Time.Year, item.Time.Month, item.Time.Day, item.Time.Hour, item.Time.Minute, item.Time.Second, item.Time.Millisecond }), item.Type, item.Describe);
        }
        void saveConfig()
        {
            Common.Config.BeginTime = this.dtpBeginTime.Value;
            Common.Config.EndTime = this.dtpEndTime.Value;
            Common.Config.Keywords = this.txtKeywords.Text;
            Common.Config.IgnoreCase = this.ckxIgnoreCase.Checked;
            Common.Config.Type = (LogTypes)Enum.Parse(typeof(LogTypes), this.cbxTypes.Text);
            Common.Config.EnabledNearFind = this.ckxEnabledNearFind.Checked;
            Common.Config.NearFindKeywords = this.txtNearFindKeywords.Text;
            Common.Config.NearFindRegion = (int)this.nudNearFindRegion.Value;
            Common.Config.IncludeKeywords = this.ckxIncludeKeywords.Checked;
            Common.Config.IncludeNearKeywords = this.ckxIncludeNearKeywords.Checked;
            Common.Config.Save(Common.ConfigPath);
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
                        dialog.FileName = "检索数据";
                        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            if (File.Exists(dialog.FileName))
                                File.Delete(dialog.FileName);
                            Logs log = new Logs(dialog.FileName, 0);
                            foreach (var item in this._logsResult)
                                log.WriteLine(item.Time, item.Type != LogTypes.All && item.Type != LogTypes.Normal ? item.Type.ToString() + ":" : "" + item.Describe);
                        }

                        this.btnExport.Text = "完成";
                    }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this._logsResult.Clear();
            this._logsResult.AddRange(this._logs);

            this.bindingDatas();
        }
        #endregion

        #region Methods Logs Listen
        private void btnChooseLogsFolder_Click(object sender, EventArgs e)
        {
            this.chooseLogsFolder();
        }

        private void chooseLogsFolder()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                this.cbxLogsFolders.Text = dialog.SelectedPath;
        }

        private void btnStartListen_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.cbxLogsFolders.Text))
                return;
            if (this._watcher == null)
                this._watcher = new FileSystemWatcher(this.cbxLogsFolders.Text);
            this._watcher.Path = this.cbxLogsFolders.Text;

            this.saveLogsFolders();

            if (!this._watcher.EnableRaisingEvents)
            {
                this._watcher.Changed += watcher_Changed;
                this._watcher.Created += watcher_Created;
                this._watcher.EnableRaisingEvents = true;
            }
            this.close();
        }
        void watcher_Created(object sender, FileSystemEventArgs e)
        {
            this.Invoke(new ArgsStrHandler(this.loadFile), e.FullPath);
        }
        void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            this.Invoke(new ArgsStrHandler(this.loadFile), e.FullPath);
        }
        void loadFile(string fileName)
        {
            int interval = (int)(DateTime.Now - this._lastUpdateTime).TotalMilliseconds;
            if (interval > Common.Config.LogChangeUpdateInterval && File.Exists(fileName))
            {
                this._lastUpdateTime = DateTime.Now;

                this._logdFilesPath = new string[] { fileName };

                this.readLogs();
                this.bindingDatas();
            }
        }

        private void saveLogsFolders()
        {
            /*
             * 删除Item说中与Text重复的项，并重新加入Items
             */
            string text = this.cbxLogsFolders.Text;
            if (this.cbxLogsFolders.Items.Contains(text))
                this.cbxLogsFolders.Items.Remove(text);

            /*
             * 获取Items集合
             */
            List<string> folders = new List<string>();
            folders.Add(text);
            foreach (var item in this.cbxLogsFolders.Items)
                if (!string.IsNullOrEmpty(item.ToString()))
                    folders.Add(item.ToString());

            this.cbxLogsFolders.Items.Add(text);


            /*
             * 保存文件夹
             * 只记录7条
             */
            Common.Config.LogsFolders = folders.Take(7).ToList();
            this.saveConfig();

            /*
             * 排序后的文件夹列表重新绑定到Items
             */
            this.cbxLogsFolders.Items.Clear();
            this.cbxLogsFolders.Items.AddRange(Common.Config.LogsFolders.ToArray());
            this.cbxLogsFolders.Text = text;
        }

        private void btnStopListen_Click(object sender, EventArgs e)
        {
            this.stopListen();
        }
        void stopListen()
        {
            if (this._watcher != null && this._watcher.EnableRaisingEvents)
            {
                this._watcher.EnableRaisingEvents = false;
                this._watcher.Changed -= watcher_Changed;
                this._watcher.Created -= watcher_Created;
            }
            this.lblOpenFileDescribe.Text = "共打开0个文件，读取到日志数据0行，总字节大小0M";
        }

        private void btnRefreshListen_Click(object sender, EventArgs e)
        {
            if (this._watcher != null && this._watcher.EnableRaisingEvents)
            {
                this._lastUpdateTime.AddSeconds(-Common.Config.LogChangeUpdateInterval);
                if (this._logdFilesPath != null && this._logdFilesPath.Length > 0)
                    this.loadFile(this._logdFilesPath[0]);
            }
        }
        #endregion

        #region Formclosing
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.stopListen();
        }
        #endregion
    }
}
