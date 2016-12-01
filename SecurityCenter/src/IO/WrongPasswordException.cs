using System;

namespace SecurityCenter.IO {
    class WrongPasswordException : Exception {
        public WrongPasswordException()
            : base("Wrong password. Can not load safe data.") {
        }
    }
}
