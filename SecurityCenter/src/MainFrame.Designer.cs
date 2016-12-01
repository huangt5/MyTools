namespace SecurityCenter {
    partial class MainFrame {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
            this._panelLogin = new System.Windows.Forms.Panel();
            this._btnImport1 = new System.Windows.Forms.Button();
            this._btnInit = new System.Windows.Forms.Button();
            this._btnLogin = new System.Windows.Forms.Button();
            this._txtPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._splitMain = new System.Windows.Forms.SplitContainer();
            this._btnClearSearch = new System.Windows.Forms.Button();
            this._btnSearch = new System.Windows.Forms.Button();
            this._txtKey = new System.Windows.Forms.TextBox();
            this._tree = new System.Windows.Forms.TreeView();
            this._ctxNotes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._ctxAddNote = new System.Windows.Forms.ToolStripMenuItem();
            this._ctxDelete = new System.Windows.Forms.ToolStripMenuItem();
            this._treeImages = new System.Windows.Forms.ImageList(this.components);
            this._txtTags = new System.Windows.Forms.TextBox();
            this._bindingNote = new System.Windows.Forms.BindingSource(this.components);
            this._txtNotes = new System.Windows.Forms.TextBox();
            this._txtName = new System.Windows.Forms.TextBox();
            this._panelSummary = new System.Windows.Forms.Panel();
            this._btnRefreshTimeout = new System.Windows.Forms.Button();
            this._chkTop = new System.Windows.Forms.CheckBox();
            this._btnSave = new System.Windows.Forms.Button();
            this._lbChanged = new System.Windows.Forms.Label();
            this._btnChangePwd = new System.Windows.Forms.Button();
            this._lbSchema = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._lbLastUpdated = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._lbInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this._panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitMain)).BeginInit();
            this._splitMain.Panel1.SuspendLayout();
            this._splitMain.Panel2.SuspendLayout();
            this._splitMain.SuspendLayout();
            this._ctxNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._bindingNote)).BeginInit();
            this._panelSummary.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panelLogin
            // 
            this._panelLogin.Controls.Add(this._btnImport1);
            this._panelLogin.Controls.Add(this._btnInit);
            this._panelLogin.Controls.Add(this._btnLogin);
            this._panelLogin.Controls.Add(this._txtPwd);
            this._panelLogin.Controls.Add(this.label1);
            this._panelLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelLogin.Location = new System.Drawing.Point(0, 0);
            this._panelLogin.Name = "_panelLogin";
            this._panelLogin.Size = new System.Drawing.Size(825, 32);
            this._panelLogin.TabIndex = 0;
            // 
            // _btnImport1
            // 
            this._btnImport1.Location = new System.Drawing.Point(408, 4);
            this._btnImport1.Name = "_btnImport1";
            this._btnImport1.Size = new System.Drawing.Size(75, 23);
            this._btnImport1.TabIndex = 3;
            this._btnImport1.Text = "Import v1.0";
            this._btnImport1.UseVisualStyleBackColor = true;
            this._btnImport1.Click += new System.EventHandler(this._btnImport1_Click);
            // 
            // _btnInit
            // 
            this._btnInit.Location = new System.Drawing.Point(327, 4);
            this._btnInit.Name = "_btnInit";
            this._btnInit.Size = new System.Drawing.Size(75, 23);
            this._btnInit.TabIndex = 2;
            this._btnInit.Text = "Initialize";
            this._btnInit.UseVisualStyleBackColor = true;
            this._btnInit.Visible = false;
            this._btnInit.Click += new System.EventHandler(this._btnInit_Click);
            // 
            // _btnLogin
            // 
            this._btnLogin.Location = new System.Drawing.Point(246, 4);
            this._btnLogin.Name = "_btnLogin";
            this._btnLogin.Size = new System.Drawing.Size(75, 23);
            this._btnLogin.TabIndex = 1;
            this._btnLogin.Text = "Login";
            this._btnLogin.UseVisualStyleBackColor = true;
            this._btnLogin.Click += new System.EventHandler(this._btnLogin_Click);
            // 
            // _txtPwd
            // 
            this._txtPwd.Location = new System.Drawing.Point(100, 6);
            this._txtPwd.Name = "_txtPwd";
            this._txtPwd.PasswordChar = '*';
            this._txtPwd.Size = new System.Drawing.Size(140, 20);
            this._txtPwd.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Root Password:";
            // 
            // _splitMain
            // 
            this._splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitMain.Location = new System.Drawing.Point(0, 64);
            this._splitMain.Name = "_splitMain";
            // 
            // _splitMain.Panel1
            // 
            this._splitMain.Panel1.Controls.Add(this._btnClearSearch);
            this._splitMain.Panel1.Controls.Add(this._btnSearch);
            this._splitMain.Panel1.Controls.Add(this._txtKey);
            this._splitMain.Panel1.Controls.Add(this._tree);
            // 
            // _splitMain.Panel2
            // 
            this._splitMain.Panel2.Controls.Add(this._txtTags);
            this._splitMain.Panel2.Controls.Add(this._txtNotes);
            this._splitMain.Panel2.Controls.Add(this._txtName);
            this._splitMain.Size = new System.Drawing.Size(825, 371);
            this._splitMain.SplitterDistance = 204;
            this._splitMain.TabIndex = 2;
            // 
            // _btnClearSearch
            // 
            this._btnClearSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnClearSearch.Location = new System.Drawing.Point(178, 4);
            this._btnClearSearch.Name = "_btnClearSearch";
            this._btnClearSearch.Size = new System.Drawing.Size(23, 23);
            this._btnClearSearch.TabIndex = 3;
            this._btnClearSearch.Text = "¡Á";
            this._btnClearSearch.UseVisualStyleBackColor = true;
            this._btnClearSearch.Click += new System.EventHandler(this._btnClearSearch_Click);
            // 
            // _btnSearch
            // 
            this._btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSearch.Location = new System.Drawing.Point(149, 4);
            this._btnSearch.Name = "_btnSearch";
            this._btnSearch.Size = new System.Drawing.Size(23, 23);
            this._btnSearch.TabIndex = 2;
            this._btnSearch.Text = ">";
            this._btnSearch.UseVisualStyleBackColor = true;
            this._btnSearch.Click += new System.EventHandler(this._btnSearch_Click);
            // 
            // _txtKey
            // 
            this._txtKey.ImeMode = System.Windows.Forms.ImeMode.On;
            this._txtKey.Location = new System.Drawing.Point(12, 6);
            this._txtKey.Name = "_txtKey";
            this._txtKey.Size = new System.Drawing.Size(131, 20);
            this._txtKey.TabIndex = 1;
            this._txtKey.TextChanged += new System.EventHandler(this._txtKey_TextChanged);
            // 
            // _tree
            // 
            this._tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tree.ContextMenuStrip = this._ctxNotes;
            this._tree.FullRowSelect = true;
            this._tree.HideSelection = false;
            this._tree.ImageIndex = 0;
            this._tree.ImageList = this._treeImages;
            this._tree.Location = new System.Drawing.Point(12, 35);
            this._tree.Name = "_tree";
            this._tree.SelectedImageIndex = 0;
            this._tree.Size = new System.Drawing.Size(189, 324);
            this._tree.TabIndex = 0;
            this._tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this._tree_AfterSelect);
            this._tree.MouseDown += new System.Windows.Forms.MouseEventHandler(this._tree_MouseDown);
            // 
            // _ctxNotes
            // 
            this._ctxNotes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ctxAddNote,
            this._ctxDelete});
            this._ctxNotes.Name = "_ctxNotes";
            this._ctxNotes.Size = new System.Drawing.Size(120, 48);
            // 
            // _ctxAddNote
            // 
            this._ctxAddNote.Name = "_ctxAddNote";
            this._ctxAddNote.Size = new System.Drawing.Size(119, 22);
            this._ctxAddNote.Text = "Add Note";
            this._ctxAddNote.Click += new System.EventHandler(this._ctxAddNote_Click);
            // 
            // _ctxDelete
            // 
            this._ctxDelete.Name = "_ctxDelete";
            this._ctxDelete.Size = new System.Drawing.Size(119, 22);
            this._ctxDelete.Text = "Delete";
            this._ctxDelete.Click += new System.EventHandler(this._ctxDelete_Click);
            // 
            // _treeImages
            // 
            this._treeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_treeImages.ImageStream")));
            this._treeImages.TransparentColor = System.Drawing.Color.Transparent;
            this._treeImages.Images.SetKeyName(0, "text.png");
            this._treeImages.Images.SetKeyName(1, "folder_closed.png");
            this._treeImages.Images.SetKeyName(2, "folder.png");
            // 
            // _txtTags
            // 
            this._txtTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTags.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._bindingNote, "Tags", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._txtTags.Location = new System.Drawing.Point(469, 7);
            this._txtTags.Name = "_txtTags";
            this._txtTags.Size = new System.Drawing.Size(145, 20);
            this._txtTags.TabIndex = 9;
            // 
            // _bindingNote
            // 
            this._bindingNote.DataSource = typeof(SecurityCenter.Entity.Note2);
            // 
            // _txtNotes
            // 
            this._txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNotes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._bindingNote, "Notes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._txtNotes.Font = new System.Drawing.Font("NSimSun", 12F);
            this._txtNotes.ImeMode = System.Windows.Forms.ImeMode.On;
            this._txtNotes.Location = new System.Drawing.Point(3, 35);
            this._txtNotes.Multiline = true;
            this._txtNotes.Name = "_txtNotes";
            this._txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtNotes.Size = new System.Drawing.Size(611, 324);
            this._txtNotes.TabIndex = 8;
            this._txtNotes.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // _txtName
            // 
            this._txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._bindingNote, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._txtName.Font = new System.Drawing.Font("NSimSun", 9F);
            this._txtName.ImeMode = System.Windows.Forms.ImeMode.On;
            this._txtName.Location = new System.Drawing.Point(3, 6);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(460, 21);
            this._txtName.TabIndex = 7;
            this._txtName.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // _panelSummary
            // 
            this._panelSummary.Controls.Add(this._btnRefreshTimeout);
            this._panelSummary.Controls.Add(this._chkTop);
            this._panelSummary.Controls.Add(this._btnSave);
            this._panelSummary.Controls.Add(this._lbChanged);
            this._panelSummary.Controls.Add(this._btnChangePwd);
            this._panelSummary.Controls.Add(this._lbSchema);
            this._panelSummary.Controls.Add(this.label3);
            this._panelSummary.Controls.Add(this._lbLastUpdated);
            this._panelSummary.Controls.Add(this.label2);
            this._panelSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelSummary.Location = new System.Drawing.Point(0, 32);
            this._panelSummary.Name = "_panelSummary";
            this._panelSummary.Size = new System.Drawing.Size(825, 32);
            this._panelSummary.TabIndex = 0;
            this._panelSummary.Visible = false;
            // 
            // _btnRefreshTimeout
            // 
            this._btnRefreshTimeout.Location = new System.Drawing.Point(597, 8);
            this._btnRefreshTimeout.Margin = new System.Windows.Forms.Padding(2);
            this._btnRefreshTimeout.Name = "_btnRefreshTimeout";
            this._btnRefreshTimeout.Size = new System.Drawing.Size(56, 19);
            this._btnRefreshTimeout.TabIndex = 6;
            this._btnRefreshTimeout.Text = "...";
            this._btnRefreshTimeout.UseVisualStyleBackColor = true;
            this._btnRefreshTimeout.Click += new System.EventHandler(this._btnRefreshTimeout_Click);
            // 
            // _chkTop
            // 
            this._chkTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chkTop.AutoSize = true;
            this._chkTop.Location = new System.Drawing.Point(655, 10);
            this._chkTop.Name = "_chkTop";
            this._chkTop.Size = new System.Drawing.Size(45, 17);
            this._chkTop.TabIndex = 4;
            this._chkTop.Text = "Top";
            this._chkTop.UseVisualStyleBackColor = true;
            this._chkTop.CheckedChanged += new System.EventHandler(this._chkTop_CheckedChanged);
            // 
            // _btnSave
            // 
            this._btnSave.Enabled = false;
            this._btnSave.Location = new System.Drawing.Point(362, 6);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(51, 23);
            this._btnSave.TabIndex = 3;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
            // 
            // _lbChanged
            // 
            this._lbChanged.AutoSize = true;
            this._lbChanged.Font = new System.Drawing.Font("Arial Black", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._lbChanged.ForeColor = System.Drawing.Color.Red;
            this._lbChanged.Location = new System.Drawing.Point(341, 5);
            this._lbChanged.Name = "_lbChanged";
            this._lbChanged.Size = new System.Drawing.Size(17, 17);
            this._lbChanged.TabIndex = 5;
            this._lbChanged.Text = "*";
            this._lbChanged.Visible = false;
            // 
            // _btnChangePwd
            // 
            this._btnChangePwd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnChangePwd.Location = new System.Drawing.Point(715, 6);
            this._btnChangePwd.Name = "_btnChangePwd";
            this._btnChangePwd.Size = new System.Drawing.Size(107, 23);
            this._btnChangePwd.TabIndex = 5;
            this._btnChangePwd.Text = "Change Password";
            this._btnChangePwd.UseVisualStyleBackColor = true;
            this._btnChangePwd.Click += new System.EventHandler(this._btnChangePwd_Click);
            // 
            // _lbSchema
            // 
            this._lbSchema.AutoSize = true;
            this._lbSchema.Location = new System.Drawing.Point(260, 10);
            this._lbSchema.Name = "_lbSchema";
            this._lbSchema.Size = new System.Drawing.Size(54, 13);
            this._lbSchema.TabIndex = 3;
            this._lbSchema.Text = "{Schema}";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Schema:";
            // 
            // _lbLastUpdated
            // 
            this._lbLastUpdated.AutoSize = true;
            this._lbLastUpdated.Location = new System.Drawing.Point(92, 10);
            this._lbLastUpdated.Name = "_lbLastUpdated";
            this._lbLastUpdated.Size = new System.Drawing.Size(76, 13);
            this._lbLastUpdated.TabIndex = 1;
            this._lbLastUpdated.Text = "{LastUpdated}";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Last Updated:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lbInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 435);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(825, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _lbInfo
            // 
            this._lbInfo.Name = "_lbInfo";
            this._lbInfo.Size = new System.Drawing.Size(38, 17);
            this._lbInfo.Text = "Ready";
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 457);
            this.Controls.Add(this._splitMain);
            this.Controls.Add(this._panelSummary);
            this.Controls.Add(this._panelLogin);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Security Center 2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrame_FormClosing);
            this.Load += new System.EventHandler(this.MainFrame_Load);
            this._panelLogin.ResumeLayout(false);
            this._panelLogin.PerformLayout();
            this._splitMain.Panel1.ResumeLayout(false);
            this._splitMain.Panel1.PerformLayout();
            this._splitMain.Panel2.ResumeLayout(false);
            this._splitMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitMain)).EndInit();
            this._splitMain.ResumeLayout(false);
            this._ctxNotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._bindingNote)).EndInit();
            this._panelSummary.ResumeLayout(false);
            this._panelSummary.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _panelLogin;
        private System.Windows.Forms.SplitContainer _splitMain;
        private System.Windows.Forms.TextBox _txtPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnLogin;
        private System.Windows.Forms.Panel _panelSummary;
        private System.Windows.Forms.Label _lbSchema;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label _lbLastUpdated;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _btnInit;
        private System.Windows.Forms.TextBox _txtNotes;
        private System.Windows.Forms.Button _btnChangePwd;
        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.Label _lbChanged;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.ContextMenuStrip _ctxNotes;
        private System.Windows.Forms.ToolStripMenuItem _ctxAddNote;
        private System.Windows.Forms.ToolStripMenuItem _ctxDelete;
        private System.Windows.Forms.CheckBox _chkTop;
        private System.Windows.Forms.TreeView _tree;
        private System.Windows.Forms.ImageList _treeImages;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel _lbInfo;
        private System.Windows.Forms.Button _btnRefreshTimeout;
        private System.Windows.Forms.TextBox _txtTags;
        private System.Windows.Forms.Button _btnImport1;
        private System.Windows.Forms.BindingSource _bindingNote;
        private System.Windows.Forms.Button _btnClearSearch;
        private System.Windows.Forms.Button _btnSearch;
        private System.Windows.Forms.TextBox _txtKey;
    }
}

