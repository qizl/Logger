using Logger;
using SharpSerializerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAnalyzer.Models
{
    public class Config
    {
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }

        public string Keywords { get; set; }
        public LogTypes Type { get; set; }
        /// <summary>
        /// 是否忽略大小写
        /// </summary>
        public bool IgnoreCase { get; set; }

        /// <summary>
        /// 启用临近检索  
        /// </summary>
        public bool EnabledNearFind { get; set; }
        public string NearFindKeywords { get; set; }
        public int NearFindRegion { get; set; }
        /// <summary>
        /// 临近检索结果是否包含使用关键字检索到的行
        /// </summary>
        public bool IncludeKeywords { get; set; }
        /// <summary>
        /// 临近检索结果是否包含使用临近关键字检索到的行
        /// </summary>
        public bool IncludeNearKeywords { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public static Config Load(string path)
        {
            Config config = null;
            try
            {
                SharpSerializer serializer = new SharpSerializer();
                config = serializer.Deserialize(path) as Config;
            }
            catch { }
            return config;
        }

        public bool Save(string path)
        {
            try
            {
                SharpSerializer serializer = new SharpSerializer();
                serializer.Serialize(this, path);
            }
            catch { return false; }
            return true;
        }
    }
}
