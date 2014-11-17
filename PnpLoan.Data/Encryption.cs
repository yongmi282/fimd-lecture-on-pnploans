using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PnpLoan.Data
{
    public static class Encryption
    {
        public static string GetMD5Hash(string stringToEncrypt)
        {
            var md5 =new MD5CryptoServiceProvider();
            byte[] byteArray;

            byteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
            byteArray = md5.ComputeHash(byteArray);
            var hashBuilder = new StringBuilder();
            foreach (byte b in byteArray)
            {
                hashBuilder.Append(b.ToString("x2"));            
            }
            return hashBuilder.ToString().ToLower();
        }
    }

}
