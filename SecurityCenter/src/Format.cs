using System;

namespace SecurityCenter {
    class Format {
        public static string DateTime(DateTime date) {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
