using System;
using System.Collections.Generic;
using SecurityCenter.Entity;
using SecurityCenter.Services;

namespace SecurityCenter {
    class ClearState {
        private string _password;
        private SecurityCenterDocument _doc = new SecurityCenterDocument();
        private NoteGroup _clearGroup = new NoteGroup();

        public string Password {
            get { return _password; }
            set { _password = value; }
        }

        public SecurityCenterDocument Doc {
            get { return _doc; }
            set { _doc = value; }
        }

        public NoteGroup ClearGroup {
            get { return _clearGroup; }
            set { _clearGroup = value; }
        }

        public static NoteGroup ConvertNoteGroup(NoteGroup srcGroup, string password, bool decrypt) {
            ICryptoService _crypto = CryptoFactory.Instance.GetMainService();
            NoteGroup targetGroup = new NoteGroup();
            if (decrypt) {
                targetGroup.Name = _crypto.Decrypt(password, srcGroup.Name);
            } else {
                targetGroup.Name = _crypto.Encrypt(password, srcGroup.Name);
            }
            foreach (Note srcNote in srcGroup.GetNotes()) {
                Note targetNote = new Note();
                if (decrypt) {
                    targetNote.Name = _crypto.Decrypt(password, srcNote.Name);
                    targetNote.Text = _crypto.Decrypt(password, srcNote.Text);
                } else {
                    targetNote.Name = _crypto.Encrypt(password, srcNote.Name);
                    targetNote.Text = _crypto.Encrypt(password, srcNote.Text);
                }
                targetGroup.Elements.Add(targetNote);
                targetNote.SetParent(targetGroup);
            }

            foreach (NoteGroup subSrcGroup in srcGroup.GetGroups()) {
                NoteGroup subTargetGroup = ConvertNoteGroup(subSrcGroup, password, decrypt);
                targetGroup.Elements.Add(subTargetGroup);
                subTargetGroup.SetParent(targetGroup);
            }

            return targetGroup;
        }
    }
}
