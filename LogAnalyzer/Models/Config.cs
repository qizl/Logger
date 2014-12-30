using Com.EnjoyCodes.Logger;
using SharpSerializerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.EnjoyCodes.LogAnalyzer.Models
{
    public class Config
    {
        #region 时间段检索属性
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        #endregion

        #region 关键字检索属性
        public string Keywords { get; set; }
        public LogTypes Type { get; set; }
        /// <summary>
        /// 是否忽略大小写
        /// </summary>
        public bool IgnoreCase { get; set; }
        #endregion

        #region 临近检索属性
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
        #endregion

        #region 日志监听属性
        /// <summary>
        /// 监听文件夹
        /// 默认使用第一个
        /// </summary>
        public List<string> LogsFolders { get; set; }
        /// <summary>
        /// 自动加载间隔
        /// ms
        /// </summary>
        public int LogChangeUpdateInterval { get; set; }
        #endregion

        #region 日志显示设置
        /// <summary>
        /// 日志列表每次显示数量
        /// -1，显示所有
        /// </summary>
        public int DisplayAmounts { get; set; }
        #endregion

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
