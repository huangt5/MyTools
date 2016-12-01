using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.CSharp;

namespace MPToolsApp.TextProcessor {
	/// <summary>
	/// Summary description for TextProcessForm.
	/// </summary>
	public class TextProcessForm : Form {
		public TextProcessForm() {
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this._txtCodes = new System.Windows.Forms.RichTextBox();
            this._btnRun = new System.Windows.Forms.Button();
            this._groupResults = new System.Windows.Forms.GroupBox();
            this._txtResults = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this._groupProcessByLine = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._txtPattern = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._btnSub = new System.Windows.Forms.Button();
            this._btnIndexOf = new System.Windows.Forms.Button();
            this._btnReplace = new System.Windows.Forms.Button();
            this._txtIndex = new System.Windows.Forms.TextBox();
            this._txtTo = new System.Windows.Forms.TextBox();
            this._txtFrom = new System.Windows.Forms.TextBox();
            this._btnUndo = new System.Windows.Forms.Button();
            this._groupPreset = new System.Windows.Forms.GroupBox();
            this._btnTrim = new System.Windows.Forms.Button();
            this._btnRemoveEmpty = new System.Windows.Forms.Button();
            this._btnToLower = new System.Windows.Forms.Button();
            this._btnToUpper = new System.Windows.Forms.Button();
            this._groupCustom = new System.Windows.Forms.GroupBox();
            this._btnValidate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._tipRegex = new System.Windows.Forms.ToolTip(this.components);
            this._groupResults.SuspendLayout();
            this._groupProcessByLine.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this._groupPreset.SuspendLayout();
            this._groupCustom.SuspendLayout();
            this.SuspendLayout();
            // 
            // _txtCodes
            // 
            this._txtCodes.AcceptsTab = true;
            this._txtCodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtCodes.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._txtCodes.Location = new System.Drawing.Point(40, 32);
            this._txtCodes.Name = "_txtCodes";
            this._txtCodes.Size = new System.Drawing.Size(440, 112);
            this._txtCodes.TabIndex = 0;
            this._txtCodes.Text = "";
            // 
            // _btnRun
            // 
            this._btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnRun.Location = new System.Drawing.Point(432, 160);
            this._btnRun.Name = "_btnRun";
            this._btnRun.Size = new System.Drawing.Size(75, 23);
            this._btnRun.TabIndex = 1;
            this._btnRun.Text = "Run";
            this._btnRun.Click += new System.EventHandler(this._btnRun_Click);
            // 
            // _groupResults
            // 
            this._groupResults.Controls.Add(this._txtResults);
            this._groupResults.Dock = System.Windows.Forms.DockStyle.Left;
            this._groupResults.Location = new System.Drawing.Point(0, 0);
            this._groupResults.Name = "_groupResults";
            this._groupResults.Size = new System.Drawing.Size(368, 653);
            this._groupResults.TabIndex = 2;
            this._groupResults.TabStop = false;
            this._groupResults.Text = "Results";
            // 
            // _txtResults
            // 
            this._txtResults.AcceptsTab = true;
            this._txtResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtResults.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtResults.Location = new System.Drawing.Point(3, 16);
            this._txtResults.Name = "_txtResults";
            this._txtResults.Size = new System.Drawing.Size(362, 634);
            this._txtResults.TabIndex = 0;
            this._txtResults.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(368, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(6, 653);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // _groupProcessByLine
            // 
            this._groupProcessByLine.Controls.Add(this.groupBox2);
            this._groupProcessByLine.Controls.Add(this.groupBox1);
            this._groupProcessByLine.Controls.Add(this._btnUndo);
            this._groupProcessByLine.Controls.Add(this._groupPreset);
            this._groupProcessByLine.Controls.Add(this._groupCustom);
            this._groupProcessByLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupProcessByLine.Location = new System.Drawing.Point(374, 0);
            this._groupProcessByLine.Name = "_groupProcessByLine";
            this._groupProcessByLine.Size = new System.Drawing.Size(546, 653);
            this._groupProcessByLine.TabIndex = 4;
            this._groupProcessByLine.TabStop = false;
            this._groupProcessByLine.Text = "Process By Line";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this._txtPattern);
            this.groupBox2.Location = new System.Drawing.Point(16, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 79);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Regex Groups";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(486, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "?";
            this._tipRegex.SetToolTip(this.label6, "Named group ->  (?< name > subexpression )\r\n\r\nTips: Group Index starts from 1");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(422, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Notes: Call Match(int groupIndex) or Match(string groupName) to get match group v" +
    "alue.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Pattern";
            // 
            // _txtPattern
            // 
            this._txtPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtPattern.Location = new System.Drawing.Point(62, 19);
            this._txtPattern.Name = "_txtPattern";
            this._txtPattern.Size = new System.Drawing.Size(418, 20);
            this._txtPattern.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this._btnSub);
            this.groupBox1.Controls.Add(this._btnIndexOf);
            this.groupBox1.Controls.Add(this._btnReplace);
            this.groupBox1.Controls.Add(this._txtIndex);
            this.groupBox1.Controls.Add(this._txtTo);
            this.groupBox1.Controls.Add(this._txtFrom);
            this.groupBox1.Location = new System.Drawing.Point(248, 320);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 168);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Template";
            // 
            // _btnSub
            // 
            this._btnSub.Location = new System.Drawing.Point(6, 88);
            this._btnSub.Name = "_btnSub";
            this._btnSub.Size = new System.Drawing.Size(75, 23);
            this._btnSub.TabIndex = 7;
            this._btnSub.Text = "Substring";
            this._btnSub.UseVisualStyleBackColor = true;
            this._btnSub.Click += new System.EventHandler(this._btnSub_Click);
            // 
            // _btnIndexOf
            // 
            this._btnIndexOf.Location = new System.Drawing.Point(6, 56);
            this._btnIndexOf.Name = "_btnIndexOf";
            this._btnIndexOf.Size = new System.Drawing.Size(75, 23);
            this._btnIndexOf.TabIndex = 7;
            this._btnIndexOf.Text = "IndexOf";
            this._btnIndexOf.UseVisualStyleBackColor = true;
            this._btnIndexOf.Click += new System.EventHandler(this._btnIndexOf_Click);
            // 
            // _btnReplace
            // 
            this._btnReplace.Location = new System.Drawing.Point(6, 24);
            this._btnReplace.Name = "_btnReplace";
            this._btnReplace.Size = new System.Drawing.Size(75, 23);
            this._btnReplace.TabIndex = 7;
            this._btnReplace.Text = "Replace";
            this._btnReplace.UseVisualStyleBackColor = true;
            this._btnReplace.Click += new System.EventHandler(this._btnReplace_Click);
            // 
            // _txtIndex
            // 
            this._txtIndex.Location = new System.Drawing.Point(87, 58);
            this._txtIndex.Name = "_txtIndex";
            this._txtIndex.Size = new System.Drawing.Size(88, 20);
            this._txtIndex.TabIndex = 6;
            // 
            // _txtTo
            // 
            this._txtTo.Location = new System.Drawing.Point(134, 26);
            this._txtTo.Name = "_txtTo";
            this._txtTo.Size = new System.Drawing.Size(41, 20);
            this._txtTo.TabIndex = 1;
            // 
            // _txtFrom
            // 
            this._txtFrom.Location = new System.Drawing.Point(87, 26);
            this._txtFrom.Name = "_txtFrom";
            this._txtFrom.Size = new System.Drawing.Size(41, 20);
            this._txtFrom.TabIndex = 1;
            // 
            // _btnUndo
            // 
            this._btnUndo.Location = new System.Drawing.Point(40, 494);
            this._btnUndo.Name = "_btnUndo";
            this._btnUndo.Size = new System.Drawing.Size(104, 23);
            this._btnUndo.TabIndex = 4;
            this._btnUndo.Text = "Undo";
            this._btnUndo.UseVisualStyleBackColor = true;
            this._btnUndo.Click += new System.EventHandler(this._btnUndo_Click);
            // 
            // _groupPreset
            // 
            this._groupPreset.Controls.Add(this._btnTrim);
            this._groupPreset.Controls.Add(this._btnRemoveEmpty);
            this._groupPreset.Controls.Add(this._btnToLower);
            this._groupPreset.Controls.Add(this._btnToUpper);
            this._groupPreset.Location = new System.Drawing.Point(16, 320);
            this._groupPreset.Name = "_groupPreset";
            this._groupPreset.Size = new System.Drawing.Size(226, 168);
            this._groupPreset.TabIndex = 3;
            this._groupPreset.TabStop = false;
            this._groupPreset.Text = "Preset";
            // 
            // _btnTrim
            // 
            this._btnTrim.Location = new System.Drawing.Point(24, 88);
            this._btnTrim.Name = "_btnTrim";
            this._btnTrim.Size = new System.Drawing.Size(104, 23);
            this._btnTrim.TabIndex = 3;
            this._btnTrim.Text = "Trim";
            this._btnTrim.Click += new System.EventHandler(this._btnTrim_Click);
            // 
            // _btnRemoveEmpty
            // 
            this._btnRemoveEmpty.Location = new System.Drawing.Point(24, 120);
            this._btnRemoveEmpty.Name = "_btnRemoveEmpty";
            this._btnRemoveEmpty.Size = new System.Drawing.Size(104, 23);
            this._btnRemoveEmpty.TabIndex = 2;
            this._btnRemoveEmpty.Text = "Remove Empty";
            this._btnRemoveEmpty.Click += new System.EventHandler(this._btnRemoveEmpty_Click);
            // 
            // _btnToLower
            // 
            this._btnToLower.Location = new System.Drawing.Point(24, 56);
            this._btnToLower.Name = "_btnToLower";
            this._btnToLower.Size = new System.Drawing.Size(104, 23);
            this._btnToLower.TabIndex = 1;
            this._btnToLower.Text = "ToLower";
            this._btnToLower.Click += new System.EventHandler(this._btnToLower_Click);
            // 
            // _btnToUpper
            // 
            this._btnToUpper.Location = new System.Drawing.Point(24, 24);
            this._btnToUpper.Name = "_btnToUpper";
            this._btnToUpper.Size = new System.Drawing.Size(104, 23);
            this._btnToUpper.TabIndex = 0;
            this._btnToUpper.Text = "ToUpper";
            this._btnToUpper.Click += new System.EventHandler(this._btnToUpper_Click);
            // 
            // _groupCustom
            // 
            this._groupCustom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._groupCustom.Controls.Add(this._btnValidate);
            this._groupCustom.Controls.Add(this.label2);
            this._groupCustom.Controls.Add(this.label1);
            this._groupCustom.Controls.Add(this._txtCodes);
            this._groupCustom.Controls.Add(this._btnRun);
            this._groupCustom.Controls.Add(this.label3);
            this._groupCustom.Location = new System.Drawing.Point(16, 104);
            this._groupCustom.Name = "_groupCustom";
            this._groupCustom.Size = new System.Drawing.Size(512, 192);
            this._groupCustom.TabIndex = 2;
            this._groupCustom.TabStop = false;
            this._groupCustom.Text = "C# Codes";
            // 
            // _btnValidate
            // 
            this._btnValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnValidate.Location = new System.Drawing.Point(352, 160);
            this._btnValidate.Name = "_btnValidate";
            this._btnValidate.Size = new System.Drawing.Size(72, 23);
            this._btnValidate.TabIndex = 3;
            this._btnValidate.Text = "Validate";
            this._btnValidate.Click += new System.EventHandler(this._btnValidate_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(16, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(488, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "}";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(488, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "public static object ProcessString(string str) {";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(300, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Note: Return null to delete the line. Return string[] to add lines.";
            // 
            // _tipRegex
            // 
            this._tipRegex.AutoPopDelay = 60000;
            this._tipRegex.InitialDelay = 100;
            this._tipRegex.ReshowDelay = 100;
            // 
            // TextProcessForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(920, 653);
            this.Controls.Add(this._groupProcessByLine);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this._groupResults);
            this.Name = "TextProcessForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TextProcessForm";
            this.Load += new System.EventHandler(this.TextProcessForm_Load);
            this._groupResults.ResumeLayout(false);
            this._groupProcessByLine.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this._groupPreset.ResumeLayout(false);
            this._groupCustom.ResumeLayout(false);
            this._groupCustom.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void _btnRun_Click(object sender, EventArgs e)
		{
		    _originalTxt = _txtResults.Text;
			Assembly assembly = ValidateCodes(_txtCodes.Text);
			if (assembly == null) {
				return;
			}

			Type tempType = assembly.GetType(DYNAMIC_CLASS_NAME);
			MethodInfo methodInfo = tempType.GetMethod(DYNAMIC_METHOD_NAME, BindingFlags.Static | BindingFlags.Public);

			ArrayList target = new ArrayList();
			foreach (string original in _txtResults.Lines) {
				object result = methodInfo.Invoke(null, new object[] {original});
				if (result == null) {
					continue;
				} else if (result.GetType() == typeof(string[])) {
					target.AddRange(result as string[]);
				} else {
					target.Add(result.ToString());
				}
			}

			_txtResults.Lines = target.ToArray(typeof(string)) as string[];
		}

		private void _btnValidate_Click(object sender, System.EventArgs e) {
			if (ValidateCodes(_txtCodes.Text) != null) {
				MessageBox.Show("Validate successfully.");
			}
		}

		private Assembly ValidateCodes(string codes) {
			CompilerResults results = Compile(codes);

			if (results.Errors.HasErrors) {
				string format = "{0}\n";
				StringBuilder errors = new StringBuilder();
				foreach (CompilerError error in results.Errors) {
					errors.AppendFormat(format, error.ErrorText);
				}
				MessageBox.Show(errors.ToString());
				return null;
			} else {
				return results.CompiledAssembly;
			}
		}


		private CompilerResults Compile(string codes) {
			CodeDomProvider comp = new CSharpCodeProvider();
			CompilerParameters cp = new CompilerParameters();

			string templateCodes = @"
using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

public class {0} {{
	public static object {1}(string str) {{
        _line = str;
		{2}
	}}

    private static string _line;

    public static string Match(int groupIndex) {{
        Regex reg = new Regex(@""{3}"");
        Match match = reg.Match(_line);
        if (match.Success)
        {{
            return match.Groups[groupIndex].Value;
        }}
        return string.Format(""===NO MATCH GROUP {{0}}==="", groupIndex);
    }}

    public static string Match(string groupName) {{
        Regex reg = new Regex(@""{3}"");
        Match match = reg.Match(_line);
        if (match.Success)
        {{
            return match.Groups[groupName].Value;
        }}
        return string.Format(""===NO MATCH GROUP {{0}}==="", groupName);
    }}
}}
";

			cp.ReferencedAssemblies.Add("System.dll");
			cp.ReferencedAssemblies.Add("Mscorlib.dll");
			cp.ReferencedAssemblies.Add("System.Data.dll");
			cp.GenerateExecutable = false;
			cp.GenerateInMemory = true;
            //cp.TempFiles.KeepFiles = true;

			return comp.CreateCompiler().CompileAssemblyFromSource(cp, string.Format(templateCodes, DYNAMIC_CLASS_NAME, DYNAMIC_METHOD_NAME, codes, _txtPattern.Text));
		}

		private void _btnToUpper_Click(object sender, System.EventArgs e) {
			_txtCodes.Text = "return str.ToUpper();";
		}

		private void _btnToLower_Click(object sender, System.EventArgs e) {
			_txtCodes.Text = "return str.ToLower();";
		}

		private void _btnRemoveEmpty_Click(object sender, System.EventArgs e) {
			_txtCodes.Text = @"
if (str.Trim() == """") {
	return null;
}
return str;
";
		}

		private void _btnTrim_Click(object sender, System.EventArgs e) {
			_txtCodes.Text = "return str.Trim();";
		}

		private RichTextBox _txtCodes;
        private Button _btnRun;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _btnValidate;
        private IContainer components;

		private const string DYNAMIC_CLASS_NAME = "TempDynamicClass";
		private System.Windows.Forms.Button _btnToUpper;
		private System.Windows.Forms.Button _btnToLower;
		private System.Windows.Forms.Button _btnRemoveEmpty;
		private System.Windows.Forms.Button _btnTrim;
		private System.Windows.Forms.GroupBox _groupResults;
		private System.Windows.Forms.GroupBox _groupProcessByLine;
		private System.Windows.Forms.GroupBox _groupCustom;
		private System.Windows.Forms.GroupBox _groupPreset;
        private RichTextBox _txtResults;
        private Button _btnUndo;
	    private string _originalTxt;
        private GroupBox groupBox1;
        private Button _btnSub;
        private Button _btnIndexOf;
        private Button _btnReplace;
        private TextBox _txtIndex;
        private TextBox _txtTo;
        private TextBox _txtFrom;
        private GroupBox groupBox2;
        private Label label4;
        private TextBox _txtPattern;
        private Label label6;
        private ToolTip _tipRegex;
        private Label label5;
	    private const string DYNAMIC_METHOD_NAME = "ProcessString";

        private void _btnUndo_Click(object sender, EventArgs e)
        {
            _txtResults.Text = _originalTxt;
        }

        private void _btnReplace_Click(object sender, EventArgs e) {
            InsertToEditor(string.Format(".Replace(\"{0}\",\"{1}\")", _txtFrom.Text, _txtTo.Text));
            _txtFrom.Text = _txtTo.Text = "";
        }

        private void InsertToEditor(string template)
        {
            var selectionIndex = _txtCodes.SelectionStart;
            _txtCodes.Text = _txtCodes.Text.Insert(selectionIndex, template);
            _txtCodes.SelectionStart = selectionIndex + template.Length;
        }

        private void _btnIndexOf_Click(object sender, EventArgs e) {
            InsertToEditor(string.Format(".IndexOf(\"{0}\")", _txtIndex.Text));
            _txtIndex.Text = "";
        }

        private void _btnSub_Click(object sender, EventArgs e) {
            InsertToEditor(string.Format(".Substring()"));
        }

        private void TextProcessForm_Load(object sender, EventArgs e) {
            int[] tabs = new int[32];
            for (int i = 0; i < tabs.Length; ++i)
                tabs[i] = 22 * (i + 1); 
            _txtResults.SelectionTabs = tabs;
        }
	}
}
