using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using SecurityCenter.Entity;

namespace SecurityCenter.IO {
    class Doc2IO {
        public SecurityCenterDocument2 Load(string file, string password) {
            SecurityCenterDocument2 encryptedDoc2;
            using (FileStream fs = new FileStream(file, FileMode.Open)) {
                XmlSerializer ser = new XmlSerializer(typeof(SecurityCenterDocument2));
                encryptedDoc2 = ser.Deserialize(fs) as SecurityCenterDocument2;
            }
            if (encryptedDoc2 == null) {
                return null;
            }
            if (Hash(password) != encryptedDoc2.Security.Hash) {
                throw new WrongPasswordException();
            }
            SecurityCenterDocument2 doc2 = new SecurityCenterDocument2();
            doc2.LastUpdatedDate = encryptedDoc2.LastUpdatedDate;
            doc2.Schema = encryptedDoc2.Schema;
            foreach (Note2 encryptedNote in encryptedDoc2.Notes) {
                Note2 note = new Note2();
                note.Name = Decrypt(password, encryptedNote.Name);
                note.Notes = Decrypt(password, encryptedNote.Notes);
                note.Tags = Decrypt(password, encryptedNote.Tags);
                doc2.AddNote(note);
            }
            return doc2;
        }

        public void Save(SecurityCenterDocument2 doc2, string file, string password) {
            SecurityCenterDocument2 encryptedDoc2 = new SecurityCenterDocument2();
            encryptedDoc2.LastUpdatedDate = DateTime.Now;
            encryptedDoc2.Schema = doc2.Schema;
            encryptedDoc2.Security.Hash = Hash(password);
            foreach (Note2 note2 in doc2.Notes) {
                Note2 encryptedNote = new Note2();
                encryptedNote.Name = Encrypt(password, note2.Name);
                encryptedNote.Notes = Encrypt(password, note2.Notes);
                encryptedNote.Tags = Encrypt(password, note2.Tags);
                encryptedDoc2.AddNote(encryptedNote);
            }
            using (FileStream fs = new FileStream(file, FileMode.Create)) {
                XmlSerializer ser = new XmlSerializer(typeof (SecurityCenterDocument2));
                ser.Serialize(fs, encryptedDoc2);
            }
        }

        private string Hash(string clearText) {
            byte[] data = Encoding.UTF8.GetBytes(clearText);
            byte[] result;

            result = SHA512.Create().ComputeHash(data);
            return Convert.ToBase64String(result);
        }

        private string Encrypt(string pwd, string clearText) {
            byte[] keyBytes = GetPwdHash(pwd);
            byte[] ivBytes = GetIVFromKey(keyBytes);
            byte[] clearBytes = Encoding.UTF8.GetBytes(clearText);

            var encryptor = Aes.Create().CreateEncryptor(keyBytes, ivBytes);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);

            cs.Write(clearBytes, 0, clearBytes.Length);
            cs.FlushFinalBlock();

            return Convert.ToBase64String(ms.ToArray());
        }

        private byte[] GetIVFromKey(byte[] key) {
            byte[] ivBytes = SHA256.Create().ComputeHash(key);
            byte[] ret = new byte[16];
            Array.Copy(ivBytes, ret, 16);
            return ret;
        }

        private byte[] GetPwdHash(string pwd) {
            byte[] data = Encoding.UTF8.GetBytes(pwd);
            byte[] hash = SHA256.Create().ComputeHash(data);
            return hash;
        }

        private string Decrypt(string pwd, string encryptedText) {
            if (encryptedText == "") {
                return "";
            }
            byte[] keyBytes = GetPwdHash(pwd);
            byte[] ivBytes = GetIVFromKey(keyBytes);
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            var decryptor = Aes.Create().CreateDecryptor(keyBytes, ivBytes);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write);

            cs.Write(encryptedBytes, 0, encryptedBytes.Length);
            cs.FlushFinalBlock();

            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
}
