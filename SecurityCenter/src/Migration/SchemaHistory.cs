using System;
using System.Collections.Generic;
using System.Text;
using SecurityCenter.Entity;

namespace SecurityCenter.Migration {
    class SchemaHistory {
        private static SchemaHistory s_instance;
        private List<ISchemaMigrator> _all;

        public static SchemaHistory Instance {
            get {
                if (s_instance == null) {
                    s_instance = new SchemaHistory();
                }
                return s_instance;
            }
        }

        private ISchemaMigrator[] GetMigrations(string schemaVersion) {
            if (schemaVersion == "1.0") {
                return AllMigrators;
            }

            ISchemaMigrator[] all = AllMigrators;
            int startIndex = -1;
            for (int i = 0; i < all.Length; i++) {
                if (all[i].MigratedVersion == schemaVersion) {
                    startIndex = i + 1;
                    break;
                }
            }

            ISchemaMigrator[] ret = new ISchemaMigrator[all.Length - startIndex];
            all.CopyTo(ret, startIndex);
            return ret;
        }

        private ISchemaMigrator[] AllMigrators {
            get {
                if (_all == null) {
                    _all = new List<ISchemaMigrator>();
                }
                return _all.ToArray();
            }
        }

        public string LatestVersion {
            get {
                return AllMigrators[AllMigrators.Length - 1].MigratedVersion;
            }
        }

    }
}
