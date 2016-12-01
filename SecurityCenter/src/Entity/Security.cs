using System;

namespace SecurityCenter.Entity {
    [Serializable]
    public class Security {
        private string _hash;

        public string Hash {
            get { return _hash; }
            set { _hash = value; }
        }
    }
}
