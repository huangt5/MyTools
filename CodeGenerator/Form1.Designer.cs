namespace CodeGenerator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._txtResult = new System.Windows.Forms.TextBox();
            this._btnGenPropAssign = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _txtResult
            // 
            this._txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtResult.Location = new System.Drawing.Point(12, 41);
            this._txtResult.Multiline = true;
            this._txtResult.Name = "_txtResult";
            this._txtResult.Size = new System.Drawing.Size(507, 463);
            this._txtResult.TabIndex = 0;
            // 
            // _btnGenPropAssign
            // 
            this._btnGenPropAssign.Location = new System.Drawing.Point(12, 12);
            this._btnGenPropAssign.Name = "_btnGenPropAssign";
            this._btnGenPropAssign.Size = new System.Drawing.Size(233, 23);
            this._btnGenPropAssign.TabIndex = 1;
            this._btnGenPropAssign.Text = "Generate C# property assignment from class";
            this._btnGenPropAssign.UseVisualStyleBackColor = true;
            this._btnGenPropAssign.Click += new System.EventHandler(this._btnGenPropAssign_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 516);
            this.Controls.Add(this._btnGenPropAssign);
            this.Controls.Add(this._txtResult);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtResult;
        private System.Windows.Forms.Button _btnGenPropAssign;
    }
}

