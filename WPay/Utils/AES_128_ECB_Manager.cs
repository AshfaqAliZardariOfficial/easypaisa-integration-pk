using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;

namespace WPay.Utils
{
    public class AES_128_ECB_Manager
    {
        public string Encrypt(string text, string text_key)
        {
            byte[] src = Encoding.UTF8.GetBytes(text);
            byte[] key = Encoding.ASCII.GetBytes(text_key);
            RijndaelManaged aes = new RijndaelManaged();
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 128;
            using (ICryptoTransform encrypt = aes.CreateEncryptor(key, null))
            {
                byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);
                encrypt.Dispose();
                return Convert.ToBase64String(dest);
            }
        }

        public string Decrypt(string text, string text_key)
        {
            byte[] src = Convert.FromBase64String(text);
            RijndaelManaged aes = new RijndaelManaged();
            byte[] key = Encoding.ASCII.GetBytes(text_key);
            aes.KeySize = 128;
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.ECB;
            using (ICryptoTransform decrypt = aes.CreateDecryptor(key, null))
            {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                decrypt.Dispose();
                return Encoding.UTF8.GetString(dest);
            }
        }
    }
}