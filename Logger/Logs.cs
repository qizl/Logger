﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace Com.EnjoyCodes.Logger
{
    public class Logs
    {
        #region Properties
        /// <summary>
        /// 日志文件大小
        /// </summary>
        public int Size { get; private set; }

        public string LogsFolder { get; private set; }

        /// <summary>
        /// 当前日志文件
        /// </summary>
        public string LogFilePath { get; private set; }

        /// <summary>
        /// 日志文件标记
        /// 区分驱动、主程序等日志
        /// </summary>
        public string Sign { get; private set; }

        /// <summary>
        /// 是否加密日志
        /// </summary>
        public bool IsEncrypt { get; set; }

        /// <summary>
        /// 缓存路径
        /// </summary>
        public string TempFolder { get; private set; }

        /// <summary>
        /// 是否替移除换行符
        /// </summary>
        public bool IsRemoveLineBreak { get; set; }

        /// <summary>
        /// 日志文件保存位置
        /// </summary>
        public DbTypes DbTypes { get; set; }
        public string ServerUrl { get; set; }
        public int ServerSendInterval { get; set; }
        public int SinglePackageCount { get; set; }
        /// <summary>
        /// 日志调用者（App）名称
        /// </summary>
        public string AppName { get; set; }
        #endregion

        #region Members
        private TripleDES _tripleDes = new TripleDES();

        private static object logLocker = new object();
        private List<LogCommand> _logs = new List<LogCommand>();

        private Thread _tdMain;

        public struct Default
        {
            public static string LogsFolder = Path.Combine(Environment.CurrentDirectory, "Logs");
            public static int Size = 1024 * 1024;
            public static bool IsEncrypt = false;
            public static bool IsRemoveLineBreak = true;
            public static DbTypes DbTypes = DbTypes.LocalTxt;
            public static string ServerUrl = "http://192.168.6.99:8083/api/logs";
            /// <summary>
            /// 服务端日志发送间隔
            /// </summary>
            public static int ServerSendInterval = 1000;
            /// <summary>
            /// 服务端日志每包发送数量
            /// </summary>
            public static int SinglePackageCount = 100;
            public static string AppName = "API";
        }
        #endregion

        #region Constructors
        public Logs()
        {
            this.LogsFolder = Default.LogsFolder;
            this.TempFolder = Path.Combine(this.LogsFolder, "Temp");

            this.Size = Default.Size;
            this.IsEncrypt = Default.IsEncrypt;
            this.IsRemoveLineBreak = Default.IsRemoveLineBreak;

            this.DbTypes = Default.DbTypes;
            this.ServerUrl = Default.ServerUrl;
            this.ServerSendInterval = Default.ServerSendInterval;
            this.SinglePackageCount = Default.SinglePackageCount;
            this.AppName = Default.AppName;
        }

        /// <summary/>
        /// <param name="logFilePath">日志文件路径</param>
        /// <param name="size">日志文件大小(byte)，0为不限制大小</param>
        public Logs(string logFilePath, int size)
            : this()
        {
            this.LogFilePath = logFilePath;
            this.Size = size;
        }

        /// <summary/>
        /// <param name="folder">日志文件保存路径</param>
        public Logs(string folder)
            : this()
        {
            this.LogsFolder = folder;
            this.TempFolder = Path.Combine(this.LogsFolder, "Temp");
        }

        /// <summary/>
        /// <param name="folder">日志文件保存路径</param>
        /// <param name="sign">日志类型标记</param>
        public Logs(string folder, string sign)
            : this(folder)
        {
            this.Sign = sign;
        }
        #endregion

        #region Methods - Writers
        private void mainThread()
        {
            while (this._logs.Count > 0)
            {
                if (this.DbTypes == DbTypes.LocalTxt)
                {
                    LogCommand log = null;
                    lock (Logs.logLocker)
                    {
                        log = this._logs.OrderBy(l => l.Time).First();
                        this._logs.Remove(log);
                    }
                    this.writeLine(log.Time, log.Logs);
                    Thread.Sleep(2);
                }
                else if (this.DbTypes == DbTypes.Server)
                {
                    var logs = new List<LogSvr>();
                    lock (Logs.logLocker)
                    {
                        logs.AddRange(this._logs.Select(m => m.Logs is LogSvr ? (LogSvr)m.Logs : new LogSvr()
                        {
                            AppName = this.AppName,
                            Content = m.Logs.ToString(),
                            CreateTime = m.Time,
                            Type = "Normal"
                        }).Take(this.SinglePackageCount));
                        this._logs.RemoveRange(0, this._logs.Count > this.SinglePackageCount ? this.SinglePackageCount : this._logs.Count);
                    }
                    this.writeLine(logs[0].CreateTime, logs);
                    Thread.Sleep(this.ServerSendInterval);
                }
            }
            this._tdMain = null;
        }

        public string GetLogFileName()
        {
            string name = this.Sign + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log";
            name = Path.Combine(LogsFolder, name);

            return name;
        }

        public string GetTimeString(DateTime now)
        {
            string time = string.Format("{0:D4}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2} {6:D3}", new object[] { now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, now.Millisecond });
            //time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            return time;
        }

        private void addLogs(DateTime time, object log)
        {
            lock (Logs.logLocker)
            {
                this._logs.Add(new LogCommand() { Time = time, Logs = log });
            }

            if (this._tdMain == null)
            {
                this._tdMain = new Thread(this.mainThread);
                this._tdMain.Start();
            }
        }

        private void writeLine(DateTime time, object log)
        {
            switch (this.DbTypes)
            {
            case DbTypes.Server: this.writeToServer(log); break;
            case DbTypes.LocalTxt:
            default: this.writeToLocalTxt(time, log is LogSvr ? JsonConvert.SerializeObject(log) : log.ToString()); break;
            }
        }
        private void writeToLocalTxt(DateTime time, string str)
        {
            if (!Directory.Exists(this.LogsFolder))
                Directory.CreateDirectory(this.LogsFolder);
            if (LogFilePath == null)
                LogFilePath = GetLogFileName();

            FileInfo f = new FileInfo(LogFilePath);
            if (File.Exists(LogFilePath))
                if (this.Size > 0 && f.Length >= this.Size)
                    LogFilePath = GetLogFileName();

            if (time != default(DateTime))
                str = this.GetTimeString(time) + " " + str;

            // 判断是否需要加密字符串
            if (this.IsEncrypt)
            {
                byte[] sources = Encoding.Default.GetBytes(str);
                byte[] output = this._tripleDes.Encrypt(sources);
                str = Convert.ToBase64String(output);
            }

            // 判断是否需要移除换行符
            if (this.IsRemoveLineBreak)
                str = str.Replace(Environment.NewLine, "");

            try
            {
                using (StreamWriter stream = new StreamWriter(this.LogFilePath, true))
                {
                    stream.WriteLine(str);
                    stream.Flush();
                    stream.Close();
                }
            }
            catch { str = "写日志失败！"; }
        }
        private void writeToServer(object logs)
        {
            try
            {
                var c = new Dictionary<string, string>();
                c.Add("Logs", Compression.CompressString(JsonConvert.SerializeObject(logs)));

                var handler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip };
                using (var http = new HttpClient(handler))
                {
                    var content = new FormUrlEncodedContent(c);
                    var response = http.PostAsync(this.ServerUrl, content).Result;
                }
            }
            catch (Exception ex) { }
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="time"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public string WriteLine(DateTime time, string str)
        {
            this.addLogs(time, str);

            return str;
        }

        /// <summary>
        /// 写日志
        /// 自动添加时间
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string WriteLine(string str)
        {
            return this.WriteLine(DateTime.Now, str);
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="e"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public string WriteLine(Exception e, string remark)
        {
            string status = e != null ? (e.InnerException == null ? e.Message : e.Message + ",InnerException:" + e.InnerException.Message) : string.Empty;
            status = LogTypes.Error.ToString() + ":" + remark + "," + status + ((e != null && !string.IsNullOrEmpty(e.StackTrace)) ? ",StackTrace:" + e.StackTrace : string.Empty);
            return this.WriteLine(status);
        }

        /// <summary>
        /// 写日志
        /// 写字节与ASCII字符串
        /// </summary>
        /// <param name="bs"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public string WriteLine(byte[] bs, string remark)
        {
            StringBuilder s = new StringBuilder();

            if (bs != null)
                foreach (var b in bs)
                    s.Append("0x" + b.ToString("x2") + ",");
            string str = bs == null ? string.Empty : ASCIIEncoding.Default.GetString(bs);

            return this.WriteLine(remark + ",Bytes (" + (bs == null ? 0 : bs.Length) + "): " + s.ToString() + ",字符 (" + str.Length + "): " + str);
        }

        /// <summary>
        /// 写日志
        /// 写字符串集合
        /// </summary>
        /// <param name="strs"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public string WriteLine(List<string> strs, string remark)
        {
            StringBuilder s = new StringBuilder();
            foreach (var b in strs)
                s.Append(b + ",");
            return this.WriteLine(remark + ", " + s.ToString());
        }

        public void WriteLine(LogSvr log)
        {
            if (string.IsNullOrEmpty(log.AppName)) log.AppName = this.AppName;
            this.addLogs(DateTime.Now, log);
        }
        #endregion

        #region Methods - Readers
        /// <summary>
        /// 字符串解密
        /// </summary>
        /// <param name="encryptString"></param>
        /// <returns></returns>
        public string EncryptLine(string encryptString)
        {
            string strOutput = string.Empty;

            try
            {
                byte[] bs = Convert.FromBase64String(encryptString);
                byte[] bs1 = this._tripleDes.Decrypt(bs);
                strOutput = Encoding.Default.GetString(bs1);
            }
            catch { }

            return strOutput;
        }

        /// <summary>
        /// 读取日志文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns>日志对象集合，一个日志对象对应一行数据（一个时间点）</returns>
        public List<Log> Read(string path)
        {
            List<Log> logs = new List<Log>();

            if (!File.Exists(path))
                return logs;

            if (!Directory.Exists(this.TempFolder))
                Directory.CreateDirectory(this.TempFolder);
            string fileName = new FileInfo(path).Name;
            string newFilePath = Path.Combine(this.TempFolder, fileName);
            File.Copy(path, newFilePath, true);

            using (StreamReader stream = new StreamReader(newFilePath, true))
            {
                string str = stream.ReadLine();
                while (str != null)
                {
                    Log log = this.ReadLine(str);
                    if (log != null)
                        logs.Add(log);

                    str = stream.ReadLine();
                }
            }

            File.Delete(newFilePath);

            return logs;
        }

        /// <summary>
        /// 日志字符串转化为日志对象
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public Log ReadLine(string str)
        {
            Log log = new Log();

            str = this.IsLogStringEncrypt(str) ? this.EncryptLine(str) : str; // 判断是否需要解密，并解密
            try
            {
                /*
                 * 1.截取日志时间
                 */
                int timeStringLength = this.GetTimeString(DateTime.Now).Length;
                string timeStr0 = str.Substring(0, timeStringLength - 4);
                int timeStrMs = Convert.ToInt32(str.Substring(timeStringLength - 3, 3));
                log.Time = Convert.ToDateTime(timeStr0).AddMilliseconds(timeStrMs);

                string typeDescribeString = str.Substring(timeStringLength + 1, str.Length - timeStringLength - 1); // 日志类型与描述字符串
                string describeString = typeDescribeString; // 日志描述字符串

                /*
                 * 2.截取日志类型
                 */
                log.Type = LogTypes.Normal;
                string[] strs = typeDescribeString.Split(':');
                if (strs.Length > 1)
                {
                    // 获取日志类型
                    log.Type = this.getLogType(strs[0]);

                    // 非类型字符串拼接为日志描述
                    if (log.Type != LogTypes.Normal)
                    {
                        StringBuilder d = new StringBuilder();
                        for (int i = 1; i < strs.Length; i++)
                            d.Append((i > 1 ? ":" : string.Empty) + strs[i]);
                        describeString = d.ToString();
                    }
                }

                /*
                 * 3.截取日志描述
                 */
                log.Describe = describeString;
            }
            catch { log = null; }

            return log;
        }

        private LogTypes getLogType(string typeStr)
        {
            LogTypes type;

            bool b = Enum.TryParse<LogTypes>(typeStr, out type);
            if (!b)
                type = LogTypes.Normal;
            if (type != LogTypes.Error)
                type = LogTypes.Normal;

            return type;
        }

        /// <summary>
        /// 判断日志是否加密
        ///     截取指定长度的字符串（从0开始取this.GetLogFileName().Length个），判断是否能转换成时间，是则未加密
        /// </summary>
        /// <param name="str">日志中的一行数据</param>
        /// <returns></returns>
        public bool IsLogStringEncrypt(string str)
        {
            bool b = false;
            try
            {
                int timeStringLength = this.GetTimeString(DateTime.Now).Length;
                string timeStr = str.Substring(0, timeStringLength - 4);

                DateTime time;
                b = !DateTime.TryParse(timeStr, out time);
            }
            catch { }

            return b;
        }
        #endregion
    }

    public enum DbTypes
    {
        /// <summary>
        /// 本地txt文件
        /// </summary>
        LocalTxt,
        /// <summary>
        /// 服务端存储
        /// </summary>
        Server
    }
}
