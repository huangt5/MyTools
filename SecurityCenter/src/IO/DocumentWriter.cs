using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using SecurityCenter.Entity;
using SecurityCenter.Services;

namespace SecurityCenter.IO {
    class DocumentWriter {
        private ClearState _state;

        public DocumentWriter(ClearState state) {
            _state = state;
        }

        public void Write() {
            SecurityCenterDocument doc = _state.Doc;
            doc.DefaultGroup = ClearState.ConvertNoteGroup(_state.ClearGroup, _state.Password, false);
            doc.LastUpdated = DateTime.Now;
            doc.Schema = Schema.CurrentSchema;
            doc.Security = new Security();
            doc.Security.Hash = CryptoFactory.Instance.GetPwdHashService().Encrypt(_state.Password, "");

            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Security.dat", FileMode.Create)) {
                XmlSerializer xs = new XmlSerializer(typeof(SecurityCenterDocument));
                xs.Serialize(fs, doc);
            }
        }

    }
}
