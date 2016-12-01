using System;
using System.Collections;
using System.Collections.Generic;
using SecurityCenter.Comparers;

namespace SecurityCenter.Entity {
    [Serializable]
    public class NoteGroup : BaseElement {
        private List<BaseElement> _elements = new List<BaseElement>();

        public NoteGroup() {
            Name = "<group>";
        }

        public List<BaseElement> Elements {
            get { return _elements; }
            set {
                _elements = value;
                foreach (BaseElement e in _elements) {
                    e.SetParent(this);
                }
            }
        }

        public NoteGroup[] GetGroups() {
            ArrayList groups = new ArrayList();
            foreach (BaseElement e in _elements) {
                if (e is NoteGroup) {
                    groups.Add(e);
                }
            }
            groups.Sort(new NameComparer());
            return groups.ToArray(typeof(NoteGroup)) as NoteGroup[];
        }

        public Note[] GetNotes() {
            ArrayList notes = new ArrayList();
            foreach (BaseElement e in _elements) {
                if (e is Note) {
                    notes.Add(e);
                }
            }
            notes.Sort(new NameComparer());
            return notes.ToArray(typeof(Note)) as Note[];
        }
    }
}
