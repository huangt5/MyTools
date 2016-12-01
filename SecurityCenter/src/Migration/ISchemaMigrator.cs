using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityCenter.Migration {
    interface ISchemaMigrator {
        string MigratedVersion { get;
        }
        object Migrate(object originDoc);
    }
}
