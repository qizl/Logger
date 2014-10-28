using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Logger
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
        #endregion

        #region Members

        private TripleDES _tripleDes = new TripleDES();

        public struct Default
        {
            public static string LogsFolder = Path.Combine(Environment.CurrentDirectory, "Logs");
            public static int Size = 1024 * 1024;
            public static bool IsEncrypt = false;
            public static bool IsRemoveLineBreak = true;
        }
        #endregion

        #region Structures
        public Logs()
        {
            this.LogsFolder = Default.LogsFolder;
            this.TempFolder = Path.Combine(this.LogsFolder, "Temp");

            this.Size = Default.Size;
            this.IsEncrypt = Default.IsEncrypt;
            this.IsRemoveLineBreak = Default.IsRemoveLineBreak;
        }

        /// <summary>
        /// </summary>
        /// <param name="logFilePath">日志文件路径</param>
        /// <param name="size">日志文件大小(byte)，0为不限制大小</param>
        public Logs(string logFilePath, int size)
            : this()
        {
            this.LogFilePath = logFilePath;
            this.Size = size;
        }

        /// <summary>
        /// </summary>
        /// <param name="folder">日志文件保存路径</param>
        public Logs(string folder)
            : this()
        {
            this.LogsFolder = folder;
            this.TempFolder = Path.Combine(this.LogsFolder, "Temp");
        }

        /// <summary>
        /// </summary>
        /// <param name="folder">日志文件保存路径</param>
        /// <param name="sign">日志类型标记</param>
        public Logs(string folder, string sign)
            : this(folder)
        {
            this.Sign = sign;
        }
        #endregion

        #region Methods - Writers
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

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="time"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public string WriteLine(DateTime time, string str)
        {
            if (!Directory.Exists(this.LogsFolder))
                Directory.CreateDirectory(this.LogsFolder);
            if (LogFilePath == null)
                LogFilePath = GetLogFileName();

            FileInfo f = new FileInfo(LogFilePath);
            if (File.Exists(LogFilePath))
                if (this.Size > 0 && f.Length >= this.Size)
                    LogFilePath = GetLogFileName();

            if (time != null && time != default(DateTime))
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
            {
                str = str.Replace(Environment.NewLine, "");
            }

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
            string status = e.InnerException == null ? e.Message : e.Message + ",InnerException:" + e.InnerException.Message;
            status = LogTypes.Error.ToString() + ":" + remark + "," + status + (!string.IsNullOrEmpty(e.StackTrace) ? ",StackTrace:" + e.StackTrace : "");
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
            foreach (var b in bs)
                s.Append("0x" + b.ToString("x2") + ",");
            string str = ASCIIEncoding.Default.GetString(bs);

            return this.WriteLine(remark + ",Bytes (" + bs.Length + "): " + s.ToString() + ",字符 (" + str.Length + "): " + str);
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
                            d.Append(strs[i]);
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
}
