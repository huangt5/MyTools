using System;

namespace SecurityCenter.Entity {
    [Serializable]
    public class Schema {
        private string _version;

        public Schema() {
        }

        public Schema(string version) {
            _version = version;
        }

        public string Version {
            get { return _version; }
            set { _version = value; }
        }

        public static readonly Schema CurrentSchema = new Schema("1.0");
    }
}
