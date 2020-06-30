using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CoreWebApiOrnek.Helper
{
    public static class Converter
    {
        public static string ToHashMd5(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }
            return str.ToString();
        }
    }
}
