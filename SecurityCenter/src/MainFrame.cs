using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SecurityCenter.Entity;
using SecurityCenter.IO;

namespace SecurityCenter {
    public partial class MainFrame : Form {
        private Timer _timerInfo = new Timer();
        private int _lockTimeout;
        private const int TIMEOUT = 60;

        public MainFrame() {
            InitializeComponent();

            FormAction.Instance.DocChanged += DocChanged;
            FormAction.Instance.DocSaved += DocSaved;
            FormAction.Instance.DocLoaded += DocLoaded;

            _timerInfo.Tick += InfoTick;
            _timerInfo.Interval = 1000;
            _timerInfo.Enabled = true;

            _txtKey.ImeMode = ImeMode.OnHalf;
            _txtName.ImeMode = ImeMode.OnHalf;
            _txtNotes.ImeMode = ImeMode.OnHalf;

            RefreshTimeout();
        }

        private void RefreshTimeout() {
            _lockTimeout = TIMEOUT;
        }

        private void InfoTick(object sender, EventArgs e) {
            _lockTimeout--;
            _lbInfo.Text = _lockTimeout.ToString();
            if (_lockTimeout <= 0) {
                Application.Exit();
            }
        }


        private void DocLoaded(SecurityCenterDocument2 doc2) {
            _txtPwd.Text = "";
            _panelLogin.Visible = false;

            RefreshTimeout();

            InitSummary();
            RefreshTree("");
        }

        private void RefreshTree(string key) {
            _tree.Nodes.Clear();
            List<Note2> notes = new List<Note2>();
            if (string.IsNullOrEmpty(key)) {
                notes.AddRange(Program.CurrentDoc.Notes);
            } else {
                notes.AddRange((from note in Program.CurrentDoc.Notes
                                where note.Name.ToLower().Contains(key.ToLower()) || note.Notes.ToLower().Contains(key.ToLower()) || note.Tags.ToLower().Contains(key.ToLower())
                                select note));
            }
            foreach (Note2 note in notes) {
                TreeNode node = new TreeNode(note.Name);
                node.Tag = note;
                _tree.Nodes.Add(node);
            }
        }

        private void DocSaved(object sender, EventArgs e) {
            _lbChanged.Visible = false;
            _lbLastUpdated.Text = Format.DateTime(DateTime.Now);
            _btnSave.Enabled = false;
        }

        private void DocChanged(object sender, EventArgs e) {
            _lbChanged.Visible = true;
            _btnSave.Enabled = true;
        }


        private void _btnLogin_Click(object sender, EventArgs e) {
            try {
                Program.ThePassword = _txtPwd.Text;
                FormAction.Instance.LoadDoc(_txtPwd.Text);
                _txtKey.Focus();
            } catch (IOException ex) {
                MessageBox.Show(string.Format("Failed to open data file. [{0}]", ex.Message));
                return;
            } catch (WrongPasswordException ex) {
                MessageBox.Show(ex.Message);
                _txtPwd.Text = "";
                _txtPwd.Focus();
                return;
            }
        }

        private void InitSummary() {
            _panelSummary.Visible = true;

            _lbLastUpdated.Text = Format.DateTime(Program.CurrentDoc.LastUpdatedDate);
            _lbSchema.Text = Program.CurrentDoc.Schema.Version;
        }

        private void MainFrame_Load(object sender, EventArgs e) {
            if (!File.Exists(AppConst.DataFile2)) {
                _btnLogin.Enabled = false;
                _btnInit.Visible = true;
            }

            _chkTop.Checked = TopMost;
        }

        private void _btnInit_Click(object sender, EventArgs e) {
            if (_txtPwd.Text == "") {
                MessageBox.Show("Root password is mandatory.");
                _txtPwd.Focus();
                return;
            }

            SecurityCenterDocument2 doc2 = new SecurityCenterDocument2();
            doc2.LastUpdatedDate = DateTime.Now;

            new Doc2IO().Save(doc2, AppConst.DataFile2, _txtPwd.Text);
            Program.CurrentDoc = doc2;
            Program.ThePassword = _txtPwd.Text;

            _btnInit.Visible = false;
            _btnLogin.Enabled = true;
            _txtPwd.Text = "";
        }

        private void _btnSave_Click(object sender, EventArgs e) {
            FormAction.Instance.SaveState();
            RefreshTimeout();
        }

        private void MainFrame_FormClosing(object sender, FormClosingEventArgs e) {
            if (_lbChanged.Visible) {
                if (MessageBox.Show("Do you want to discard all changes?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No) {
                    e.Cancel = true;
                }
            }
        }

        private void _btnChangePwd_Click(object sender, EventArgs e) {
            FormAction.Instance.ChangePassword();
        }


        ///<summary>
        ///Processes a dialog key. 
        ///</summary>
        ///
        ///<returns>
        ///true if the keystroke was processed and consumed by the control; otherwise, false to allow further processing.
        ///</returns>
        ///
        ///<param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"></see> values that represents the key to process. </param>
        protected override bool ProcessDialogKey(Keys keyData) {
            if (_txtPwd.Focused && keyData == Keys.Enter) {
                _btnLogin_Click(this, EventArgs.Empty);
                return true;
            }
            if (_txtKey.Focused && keyData == Keys.Enter) {
                _btnSearch_Click(this, EventArgs.Empty);
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void _chkTop_CheckedChanged(object sender, EventArgs e) {
            TopMost = _chkTop.Checked;
            _timerInfo.Enabled = !_chkTop.Checked;
        }

        private void _tree_AfterSelect(object sender, TreeViewEventArgs e) {
            _txtName.TextChanged -= OnTextChanged;
            _txtNotes.TextChanged -= OnTextChanged;
            _txtTags.TextChanged -= OnTextChanged;

            Note2 note = e.Node.Tag as Note2;
            if (note == null) {
                return;
            }
            _bindingNote.DataSource = note;

            _txtName.TextChanged += OnTextChanged;
            _txtNotes.TextChanged += OnTextChanged;
            _txtTags.TextChanged += OnTextChanged;
        }

        private void _ctxAddNote_Click(object sender, EventArgs e) {
            Note2 note = new Note2();
            note.Name = "<ÐÂ½¨>";
            Program.CurrentDoc.AddNote(note);
            RefreshTree("");
            SelectTreeNodeByNote(note);
            FormAction.Instance.OnStateChanged();
        }

        private void SelectTreeNodeByNote(Note2 note) {
            foreach (TreeNode node in _tree.Nodes) {
                if (node.Tag == note) {
                    _tree.SelectedNode = node;
                    return;
                }
            }
        }

        private void _ctxDelete_Click(object sender, EventArgs e) {
            if (_tree.SelectedNode != null) {
                Note2 note = _tree.SelectedNode.Tag as Note2;
                if (note != null) {
                    Program.CurrentDoc.RemoveNote(note);
                    FormAction.Instance.OnStateChanged();
                    RefreshTree("");
                    _txtName.Text = "";
                    _txtNotes.Text = "";
                    _txtTags.Text = "";
                }
            }
        }

        private void _btnRefreshTimeout_Click(object sender, EventArgs e) {
            RefreshTimeout();
        }

        private void OnTextChanged(object sender, EventArgs e) {
            RefreshTimeout();
            FormAction.Instance.OnStateChanged();
            if (_tree.SelectedNode != null) {
                _tree.SelectedNode.Text = _txtName.Text;
            }
        }


        private void _tree_MouseDown(object sender, MouseEventArgs e) {
            RefreshTimeout();
        }

        private void IterateDoc1Group(SecurityCenterDocument2 doc2, NoteGroup clearGroup) {
            foreach (Note note in clearGroup.GetNotes()) {
                Note2 note2 = new Note2();
                note2.Name = note.Name;
                note2.Notes = note.Text;
                note2.Tags = clearGroup.Name == "<default>" ? "" : clearGroup.Name;
                doc2.AddNote(note2);
            }
            foreach (NoteGroup subGroup in clearGroup.GetGroups()) {
                IterateDoc1Group(doc2, subGroup);
            }
        }

        private void _btnImport1_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK) {
                DocumentReader reader = new DocumentReader(_txtPwd.Text);
                reader.LoadFromFile(dialog.FileName);

                ClearState state = reader.State;

                SecurityCenterDocument2 doc2 = new SecurityCenterDocument2();
                IterateDoc1Group(doc2, state.ClearGroup);

                Program.ThePassword = _txtPwd.Text;
                Program.CurrentDoc = doc2;
                FormAction.Instance.OnDocLoaded(doc2);
                FormAction.Instance.OnStateChanged();
            }
        }

        private void _btnSearch_Click(object sender, EventArgs e) {
            RefreshTree(_txtKey.Text);
            RefreshTimeout();
        }

        private void _btnClearSearch_Click(object sender, EventArgs e) {
            _txtKey.Text = "";
            RefreshTree("");
            RefreshTimeout();
        }

        private void _txtKey_TextChanged(object sender, EventArgs e) {
            RefreshTimeout();
        }
    }
}