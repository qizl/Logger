using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logger;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace LoggerTests
{
    [TestClass]
    public class UnitTestLogs
    {
        /// <summary>
        /// 加密解密测试
        /// </summary>
        [TestMethod]
        public void TestEncrypt()
        {
            Logs log = new Logs(Path.Combine(Environment.CurrentDirectory, "Logs"));
            log.IsEncrypt = true;

            string testStr = "日志加密测试";

            string strOutput = log.WriteLine(testStr);
            string strDes = log.EncryptLine(strOutput);
            strDes = strDes.Substring(strDes.Length - testStr.Length, testStr.Length);

            Assert.AreEqual(testStr, strDes);
        }

        /// <summary>
        /// 写字节数组测试
        /// </summary>
        [TestMethod]
        public void TestWriteLine()
       { 
            Logs log = new Logs(Path.Combine(Environment.CurrentDirectory, "Logs"));

            int i = 10000;
            byte[] bs = new byte[] { 1, 2, 3, 4, 5, 6 };
            while (i-- > 0)
            {
                log.WriteLine(bs, "字节数组测试");
            }
            Thread.Sleep(1000000);
        }

        [TestMethod]
        public void TestReadLine()
        {
            string log = "2014-10-25 08:34:50 886 Error:日志加密测试,异常测试";
            string logEncrypt = "Sci3lqTkws1mnaAgMGM3k67KFandKIrO+JVC9NWhBEMJ0hPnMOlstBNF1VosP+xFLvraiQXDHd0=";

            Logs logDal = new Logs("");
            Log l = logDal.ReadLine(log);
            Assert.IsTrue(log.Contains(l.Describe));

            Log l1 = logDal.ReadLine(logEncrypt);
            Assert.IsTrue(l1.Describe.Contains("日志加密测试"));
        }

        [TestMethod]
        public void TestRead()
        {
            Logs log = new Logs();
            log.IsEncrypt = true;
            for (int i = 0; i < 1000; i++)
                log.WriteLine("日志读取测试" + i);
            string path = log.LogFilePath;

            List<Log> logs = log.Read(path);
        }

        [TestMethod]
        public void TestWriteLineRemoveLineBreak()
        {
            Logs log = new Logs(Path.Combine(Environment.CurrentDirectory, "Logs"));
            log.IsRemoveLineBreak = true;
            string str = "123" + Environment.NewLine + "newline";
            string strResult = log.WriteLine(str);

            Assert.IsFalse(strResult.Contains(Environment.NewLine));
        }

        [TestMethod]
        public void TestWriterLineException()
        {
            Logs log = new Logs();
            try
            {
                int i = 0;
                int j = 1 / i;
            }
            catch (Exception ex)
            {
                log.WriteLine(ex, "Test");
            }
        }
    }
}
