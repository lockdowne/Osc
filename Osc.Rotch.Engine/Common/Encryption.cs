using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Osc.Engine.Common
{
    public static class Encryption
    {
        private const string Key = "osc@!q)a#Z$";

        private const int KeySize = 256;
        private const int PasswordIterations = 1000;

        private static readonly byte[] vector = new byte[16]
        {
            181, 246, 130,  78,   0, 143,  63,  17,  52,  28, 232, 234,  25, 164,  33,  24, 
        };

        private static readonly byte[] salt = new byte[64]
        {
            213,  96,   2, 110,  87,  79, 249, 198,  86,  85,  11, 17,   85, 134,   1,  65,                                                              
            137, 134, 192, 162, 229, 172, 132,  38,  55, 162, 151, 191, 109, 192,  75,  29,                                                             
            235, 219,  60,  26,  62, 179,  95,  20, 112, 154, 146, 212,  58, 120, 118, 201,                                                            
            169,  97,  76,  88, 102, 134, 214, 117 , 95,  24, 175 ,107, 162, 168,  92 ,211,
        };

        public static string Decrypt(string encryptedText)
        {
            byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(Key);

            Rfc2898DeriveBytes aesKey = new Rfc2898DeriveBytes(passwordBytes, salt, PasswordIterations);
            byte[] keyBytes = aesKey.GetBytes(KeySize / 8);

            try
            {
                using (ICryptoTransform decryptor = new RijndaelManaged { Mode = CipherMode.CBC }.CreateDecryptor(keyBytes, vector))
                {
                    using (MemoryStream memoryStream = new MemoryStream(encryptedTextBytes))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            byte[] plainTextBytes = new byte[encryptedTextBytes.Length];

                            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

            return null;
        }

        public static async Task<string> DecryptAsync(string encryptedText)
        {
            byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(Key);

            Rfc2898DeriveBytes aesKey = new Rfc2898DeriveBytes(passwordBytes, salt, PasswordIterations);
            byte[] keyBytes = aesKey.GetBytes(KeySize / 8);

            try
            {
                using (ICryptoTransform decryptor = new RijndaelManaged { Mode = CipherMode.CBC }.CreateDecryptor(keyBytes, vector))
                {
                    using (MemoryStream memoryStream = new MemoryStream(encryptedTextBytes))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            byte[] plainTextBytes = new byte[encryptedTextBytes.Length];

                            int decryptedByteCount = await cryptoStream.ReadAsync(plainTextBytes, 0, plainTextBytes.Length);
                            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

            return null;
        }


        public static string Encrypt(string text)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(Key);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(text);

            Rfc2898DeriveBytes aesKey = new Rfc2898DeriveBytes(passwordBytes, salt, PasswordIterations);
            byte[] keyBytes = aesKey.GetBytes(KeySize / 8);

            try
            {
                using (ICryptoTransform encryptor = new RijndaelManaged { Mode = CipherMode.CBC }.CreateEncryptor(keyBytes, vector))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                            cryptoStream.FlushFinalBlock();

                            byte[] cipherTextBytes = memoryStream.ToArray();
                            return Convert.ToBase64String(cipherTextBytes);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

            return null;
        }

        public static async Task<string> EncryptAsync(string text)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(Key);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(text);

            Rfc2898DeriveBytes aesKey = new Rfc2898DeriveBytes(passwordBytes, salt, PasswordIterations);
            byte[] keyBytes = aesKey.GetBytes(KeySize / 8);

            try
            {
                using (ICryptoTransform encryptor = new RijndaelManaged { Mode = CipherMode.CBC }.CreateEncryptor(keyBytes, vector))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            await cryptoStream.WriteAsync(plainTextBytes, 0, plainTextBytes.Length);
                            cryptoStream.FlushFinalBlock();

                            byte[] cipherTextBytes = memoryStream.ToArray();
                            return Convert.ToBase64String(cipherTextBytes);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

            return null;
        }
    }
}
