using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Security.Cryptography;

namespace Logger
{
    public class TripleDES
    {
        private byte[] _key = new byte[24];
        private byte[] _iv = new byte[8];
        private TripleDESCryptoServiceProvider _desCSP = new TripleDESCryptoServiceProvider();

        public TripleDES()
        {
            this._key = new byte[]
            {
                0x01,0x34,0x01,0x34,0x01,0xC4,0x01,0x34,
                0xFE,0x34,0xA1,0x34,0x01,0xB4,0x07,0x3D,
                0xAC,0x31,0xE1,0x34,0x01,0xA4,0x09,0xC4
            };

            this._iv = new byte[] 
            {
                0x01,0x34,0x01,0xA4,0xB1,0xC4,0xD1,0xE4
            };
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public byte[] Encrypt(byte[] datas)
        {
            byte[] d = null;
            string str = Convert.ToBase64String(datas);
            using (MemoryStream ms = new MemoryStream())
            {
                CryptoStream cryStream = new CryptoStream(ms, _desCSP.CreateEncryptor(this._key, this._iv), CryptoStreamMode.Write);
                StreamWriter sw = new StreamWriter(cryStream);
                sw.Write(str);
                sw.Close();

                d = ms.ToArray();
                cryStream.Close();
            }
            return d;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public byte[] Decrypt(byte[] datas)
        {
            byte[] d = null;
            using (MemoryStream ms = new MemoryStream(datas))
            {
                CryptoStream cryStream = new CryptoStream(ms, _desCSP.CreateDecryptor(this._key, this._iv), CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(cryStream);

                d = Convert.FromBase64String(sr.ReadToEnd());

                sr.Close();
                cryStream.Close();
            }
            return d;
        }
    }
}
