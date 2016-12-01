using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SecurityCenter.Entity {
    [Serializable]
    [XmlInclude(typeof(Note))]
    [XmlInclude(typeof(NoteGroup))]
    public class BaseElement {
        private string _name = "";
        private NoteGroup _group;

        public BaseElement() {
            _name = "<default>";
        }

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        public NoteGroup GetParent() {
            return _group;
        }

        public void SetParent(NoteGroup group) {
            _group = group;
        }

        public override string ToString() {
            return Name;
        }

    }
}
