using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Com.EnjoyCodes.LogAnalyzer.Models
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

        /// <summary>
        /// 释放内存
        /// </summary>
        [System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
        }
    }
}
