using System;
using System.Windows.Forms;
using SecurityCenter.Entity;

namespace SecurityCenter {
    static class Program {
        public static string ThePassword;
        public static SecurityCenterDocument2 CurrentDoc;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrame());
        }
    }
}