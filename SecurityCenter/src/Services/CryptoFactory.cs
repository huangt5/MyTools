using System;

namespace SecurityCenter.Services {
    class CryptoFactory {
        private static CryptoFactory s_instance;


        private CryptoFactory() {
        }

        public static CryptoFactory Instance {
            get {
                if (s_instance == null) {
                    s_instance = new CryptoFactory();
                }
                return s_instance;
            }
        }

        public ICryptoService GetMainService() {
            return new TripleDESService();
        }

        public ICryptoService GetPwdHashService() {
            return new SHA512Service();
        }
    }
}
