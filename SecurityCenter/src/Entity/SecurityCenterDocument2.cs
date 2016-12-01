using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityCenter.Entity {
    [Serializable]
    public class SecurityCenterDocument2 {
        public SecurityCenterDocument2() {
            _schema = new Schema();
            _schema.Version = "2.0";
        }

        private List<Note2> _notes = new List<Note2>();

        private DateTime _lastUpdatedDate = DateTime.Now;
        public DateTime LastUpdatedDate {
            get { return _lastUpdatedDate; }
            set { _lastUpdatedDate = value; }
        }

        private Security _security = new Security();
        public Security Security {
            get { return _security; }
            set { _security = value; }
        }

        private Schema _schema;
        public Schema Schema {
            get { return _schema; }
            set { _schema = value; }
        }

        public Note2[] Notes {
            get { return _notes.ToArray(); }
            set { _notes.AddRange(value); }
        }

        public void AddNote(Note2 note2) {
            _notes.Add(note2);
        }

        public void RemoveNote(Note2 note) {
            _notes.Remove(note);
        }
    }
}
