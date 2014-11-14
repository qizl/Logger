using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LogAnalyzer.Models
{
    public class Common
    {
        public static string ConfigPath = Path.Combine(Environment.CurrentDirectory, "Config.xml");
        public static Config Config { get; set; }

        public static Config DefaultConfig = new Config()
        {
            BeginTime = DateTime.Now,
            EndTime = DateTime.Now,
            Keywords = string.Empty,
            IgnoreCase = true,
            Type = Logger.LogTypes.Normal,
            NearFindRegion = 5,
            IncludeKeywords = true,
            IncludeNearKeywords = true,
            LogChangeUpdateInterval = 500,
            LogsFolders = new List<string>(),
            CreateTime = DateTime.Now,
            UpdateTime = DateTime.Now
        };
    }
}
