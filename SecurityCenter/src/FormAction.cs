using System;
using System.Windows.Forms;
using SecurityCenter.Entity;
using SecurityCenter.IO;

namespace SecurityCenter {
    class FormAction {
        private static FormAction s_instance;

        public delegate void StateLoadedHandler(SecurityCenterDocument2 state);

        public delegate void ElementHandler(BaseElement element);

        public event EventHandler DocChanged;
        public event EventHandler DocSaved;
        public event StateLoadedHandler DocLoaded;

        public event ElementHandler ElementAdded;
        public event ElementHandler ElementChanged;
        public event ElementHandler ElementDeleted;

        private FormAction() {
        }

        public static FormAction Instance {
            get {
                if (s_instance == null) {
                    s_instance = new FormAction();
                }
                return s_instance;
            }
        }

        private void OnElementAdded(BaseElement element) {
            if (ElementAdded != null) {
                ElementAdded(element);
            }
            OnStateChanged();
        }

        private void OnElementChanged(BaseElement element) {
            if (ElementChanged != null) {
                ElementChanged(element);
            }
            OnStateChanged();
        }

        private void OnElementDeleted(BaseElement element) {
            if (ElementDeleted != null) {
                ElementDeleted(element);
            }
            OnStateChanged();
        }

        public void OnStateChanged() {
            if (DocChanged != null) {
                DocChanged(this, EventArgs.Empty);
            }
        }

        public void OnDocSaved() {
            if (DocSaved != null) {
                DocSaved(this, EventArgs.Empty);
            }
        }

        public void OnDocLoaded(SecurityCenterDocument2 doc) {
            if (DocLoaded != null) {
                DocLoaded(doc);
            }
        }

        public void SaveState() {
            new Doc2IO().Save(Program.CurrentDoc, AppConst.DataFile2, Program.ThePassword);

            OnDocSaved();
        }

        public void LoadDoc(string password) {
            Program.CurrentDoc = new Doc2IO().Load(AppConst.DataFile2, password);
            if (Program.CurrentDoc == null) {
                Program.CurrentDoc = new SecurityCenterDocument2();
            }
            OnDocLoaded(Program.CurrentDoc);
        }

        public void ChangePassword() {
            PwdChangeForm form = new PwdChangeForm();
            if (form.ShowDialog() == DialogResult.OK) {
                Program.ThePassword = form.NewPassword;
                OnStateChanged();
            }
        }


        public void AddNewNote(NoteGroup group) {
            Note newNote = new Note();
            group.Elements.Add(newNote);
            newNote.SetParent(group);
            OnElementAdded(newNote);
        }

        public void AddNewGroup(NoteGroup group) {
            NoteGroup newGroup = new NoteGroup();
            group.Elements.Add(newGroup);
            newGroup.SetParent(group);
            OnElementAdded(newGroup);
        }

        public void UpdateNote(Note note, string name, string text) {
            if (note == null) {
                return;
            }

            note.Name = name;
            note.Text = text;
            OnElementChanged(note);
        }

        public void UpdateGroup(NoteGroup group, string name) {
            if (group == null) {
                return;
            }
            group.Name = name;
            OnElementChanged(group);
        }

        public void DeleteElement(BaseElement element) {
            element.GetParent().Elements.Remove(element);
            OnElementDeleted(element);
        }


    }
}
