using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SecurityCenter.Services {
    class TripleDESService : ICryptoService {

        /// <summary>
        /// Encrpt clear text.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="clearText"></param>
        /// <returns></returns>
        public string Encrypt(string key, string clearText) {
            byte[] keyBytes = GetKeyBytes(key);
            byte[] clearBytes = Encoding.UTF8.GetBytes(clearText);

            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
            provider.Key = keyBytes;
            provider.IV = GetIVBytes(keyBytes);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, provider.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(clearBytes, 0, clearBytes.Length);
            cs.FlushFinalBlock();

            return Convert.ToBase64String(ms.ToArray());
        }

        /// <summary>
        /// Decrypt text to clear text.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="encryptedText"></param>
        /// <returns></returns>
        public string Decrypt(string key, string encryptedText) {
            if (encryptedText == "") {
                return "";
            }
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = GetKeyBytes(key);

            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
            provider.Key = keyBytes;
            provider.IV = GetIVBytes(keyBytes);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, provider.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(encryptedBytes, 0, encryptedBytes.Length);
            cs.FlushFinalBlock();

            return Encoding.UTF8.GetString(ms.ToArray());
        }

        /// <summary>
        /// Gets bytes of key in 128bit or 192bit.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private byte[] GetKeyBytes(string key) {
            byte[] bytes = Encoding.UTF8.GetBytes(key);
            byte[] keyBytes;
            if (bytes.Length <= 128 / 8) {
                keyBytes = new byte[128/8];
            } else if (bytes.Length <= 192 / 8) {
                keyBytes = new byte[192/8];
            } else {
                throw new Exception("The key is too long. Should be less or equal than 24Byte.");
            }
            Array.Copy(bytes, keyBytes, bytes.Length);
            return keyBytes;
        }

        private byte[] GetIVBytes(byte[] keyBytes) {
            byte[] ivBytes = new byte[8];
            Array.Copy(keyBytes, ivBytes, 8);
            return ivBytes;
        }
    }
}
