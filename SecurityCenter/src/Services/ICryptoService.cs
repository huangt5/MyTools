using System;

namespace SecurityCenter.Services {
    internal interface ICryptoService {
        /// <summary>
        /// Encrpt clear text.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="clearText"></param>
        /// <returns></returns>
        string Encrypt(string key, string clearText);

        /// <summary>
        /// Decrypt text to clear text.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="encryptedText"></param>
        /// <returns></returns>
        string Decrypt(string key, string encryptedText);
    }
}
