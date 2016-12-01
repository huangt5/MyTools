using System;
using System.Security.Cryptography;
using System.Text;

namespace SecurityCenter.Services {
    class SHA512Service : ICryptoService {
        /// <summary>
        /// Encrpt clear text.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="clearText">Ingored.</param>
        /// <returns></returns>
        public string Encrypt(string key, string clearText) {
            byte[] data = Encoding.UTF8.GetBytes(key);
            byte[] result;

            SHA512 shaM = new SHA512Managed();
            result = shaM.ComputeHash(data);

            return Convert.ToBase64String(result);
        }

        /// <summary>
        /// Decrypt text to clear text.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="encryptedText"></param>
        /// <returns></returns>
        public string Decrypt(string key, string encryptedText) {
            throw new NotImplementedException("Hash algorithm can't decrypt data.");
        }
    }
}
