using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using SecurityCenter.Entity;
using SecurityCenter.Services;

namespace SecurityCenter.IO {
    class DocumentReader {
        private string _pwd;

        private ClearState _state;


        public DocumentReader(string pwd) {
            _pwd = pwd;
        }


        public ClearState State {
            get { return _state; }
        }

        public void Load() {
            string file = Environment.CurrentDirectory + "\\Security.dat";
            LoadFromFile(file);
        }

        public void LoadFromFile(string file) {
            SecurityCenterDocument doc;
            using (FileStream fs = new FileStream(file, FileMode.Open)) {
                XmlSerializer ser = new XmlSerializer(typeof(SecurityCenterDocument));
                doc = (SecurityCenterDocument)ser.Deserialize(fs);
            }

            ICryptoService hashService = CryptoFactory.Instance.GetPwdHashService();
            if (hashService.Encrypt(_pwd,"") != doc.Security.Hash) {
                throw new WrongPasswordException();
            }

            _state = new ClearState();
            _state.Doc = doc;
            _state.Password = _pwd;
            _state.ClearGroup = ClearState.ConvertNoteGroup(doc.DefaultGroup, _pwd, true);
            _state.ClearGroup.Name = "<default>";
        }
    }
}
