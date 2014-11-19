using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.EnjoyCodes.Logger
{
    /// <summary>
    /// 日志结构类
    /// </summary>
    public class Log
    {
        public DateTime Time { get; set; }
        public LogTypes Type { get; set; }
        public string Describe { get; set; }
    }
}
