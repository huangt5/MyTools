#if DEBUG
using System;
using NUnit.Framework;

namespace SecurityCenter.Services {
    [TestFixture]
    public class SHA512Service_Test {
        public void TestHashResult() {
            SHA512Service service = new SHA512Service();
            Console.WriteLine(service.Encrypt("This is my password.", ""));
        }
    }
}
#endif