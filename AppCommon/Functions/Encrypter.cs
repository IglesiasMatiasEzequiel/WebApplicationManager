using System;
using System.Security.Cryptography;
using System.Text;

namespace AppCommon.Functions
{
    public static class Encrypter
    {
        private static readonly byte[] KeyForConnections = {
                                                           0x51, 0xc9, 0x13, 0xc8, 0xbe, 0xc3, 0xca, 0x15, 
                                                           0xbd, 0x33, 0x7, 0xaf,0x29, 0x82, 0x57, 0x43, 
                                                           0xd6, 0xd8, 0xf8,0x97, 0xcb, 0x71, 0x99, 0x95
                                                           };

        public static string Encrypt(string data)
        {
            TripleDESCryptoServiceProvider td = new TripleDESCryptoServiceProvider {Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7, Key = KeyForConnections};
            
            byte[] bytesToEncrypt = Encoding.UTF8.GetBytes(data);

            return Convert.ToBase64String(td.CreateEncryptor().TransformFinalBlock(bytesToEncrypt, 0, bytesToEncrypt.Length));
        }

        public static string Decrypt(string data)
        {
            TripleDESCryptoServiceProvider td = new TripleDESCryptoServiceProvider {Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7, Key = KeyForConnections};
            
            byte[] dataToDecrypt = Convert.FromBase64String(data);

            return Encoding.UTF8.GetString(td.CreateDecryptor().TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length));
        }

        public static string EncryptNotNullOrEmpty(string data)
        {
            return string.IsNullOrEmpty(data)? data : Encrypt(data);
        }

        public static string DecryptNotNullOrEmpty(string data)
        {
            return string.IsNullOrEmpty(data) ? data : Decrypt(data);
        }
    }
}