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

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public static Config Read(string path)
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

        public static bool Save(Config config, string path)
        {
            try
            {
                SharpSerializer serializer = new SharpSerializer();
                serializer.Serialize(config, path);
            }
            catch { return false; }
            return true;
        }
    }
}
