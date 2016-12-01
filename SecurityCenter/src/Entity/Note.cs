using System;

namespace SecurityCenter.Entity {
    [Serializable]
    public class Note : BaseElement {
        private string _text = "";

        public Note() {
            Name = "<note>";
        }

        public string Text {
            get { return _text; }
            set { _text = value; }
        }

    }
}
