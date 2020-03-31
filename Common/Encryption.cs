using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    
    public static class Encryption
    {
        /// <summary>
        /// 获取加密后的MD5字符串
        /// </summary>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public static string GetMD5Str(string passWord)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(passWord));
            StringBuilder sbBuilder = new StringBuilder();
            for(int i = 0; i < data.Length;i++)
            {
                sbBuilder.Append(data[i].ToString("xqb")+"8");
            }
            return sbBuilder.ToString();
        }
    }
}
