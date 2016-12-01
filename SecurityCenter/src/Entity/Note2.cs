using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityCenter.Entity {
    [Serializable]
    public class Note2 {
        private string _name = "";
        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        private string _notes = "";
        public string Notes {
            get { return _notes; }
            set { _notes = value; }
        }

        private string _tags = "";
        public string Tags {
            get { return _tags; }
            set { _tags = value; }
        }
    }
}
