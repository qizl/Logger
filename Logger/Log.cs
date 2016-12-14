using System;

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

    /// <summary>
    /// 服务端日志模型
    /// </summary>
    [Serializable]
    public class LogSvr
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 运行时间
        /// </summary>
        public double Duration { get; set; }
        /// <summary>
        /// 客户端IP
        /// </summary>
        public string ClientIP { get; set; }
        /// <summary>
        /// 服务端IP
        /// </summary>
        public string ServerIP { get; set; }
        /// <summary>
        /// 生成日志的App名称
        /// </summary>
        public string AppName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
