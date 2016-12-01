using System;
using System.Text;
using System.Windows.Forms;
using SecurityCenter.IO;

namespace SecurityCenter {
    public partial class PwdChangeForm : Form {
        public PwdChangeForm() {
            InitializeComponent();
        }

        public string NewPassword {
            get {
                return _txtPwd.Text;
            }
        }

        private void PwdChangeForm_FormClosing(object sender, FormClosingEventArgs e) {
            _ep.SetError(_txtPwd, "");
            _ep.SetError(_txtRepeat, "");

            if (DialogResult == DialogResult.OK) {
                if (_txtPwd.Text == "") {
                    _ep.SetError(_txtPwd, "Mandatory");
                    e.Cancel = true;
                }

                if (Encoding.UTF8.GetBytes(_txtPwd.Text).Length > AppConst.MAX_PWD_LENGTH) {
                    _ep.SetError(_txtPwd, string.Format("Password is too long. Should be less or equal than {0} Bytes.", AppConst.MAX_PWD_LENGTH));
                    e.Cancel = true;
                }

                if (_txtRepeat.Text != _txtPwd.Text) {
                    _ep.SetError(_txtRepeat, "Not Same");
                    e.Cancel = true;
                }
            }
        }
    }
}