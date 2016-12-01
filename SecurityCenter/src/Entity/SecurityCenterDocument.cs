using System;

namespace SecurityCenter.Entity {
    [Serializable]
    public class SecurityCenterDocument {
        private DateTime _lastUpdated;
        private Security _security;
        private Schema _schema;
        private NoteGroup _defaultGroup;

        public DateTime LastUpdated {
            get { return _lastUpdated; }
            set { _lastUpdated = value; }
        }

        public Schema Schema {
            get { return _schema; }
            set { _schema = value; }
        }

        public Security Security {
            get { return _security; }
            set { _security = value; }
        }

        public NoteGroup DefaultGroup {
            get { return _defaultGroup; }
            set { _defaultGroup = value; }
        }
    }
}
