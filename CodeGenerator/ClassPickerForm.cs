using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGenerator
{
    public partial class ClassPickerForm : Form
    {
        private Assembly _assembly;

        public ClassPickerForm()
        {
            InitializeComponent();
        }

        private void _btnBrowse_Click(object sender, EventArgs e)
        {
            if (_openFile.ShowDialog() == DialogResult.OK)
            {
                _txtFileName.Text = _openFile.FileName;

                _assembly = Assembly.LoadFrom(_openFile.FileName);
                (from type in _assembly.GetTypes()
                        orderby type.FullName
                        select type.FullName).ToList()
                        .ForEach(x => _listClass.Items.Add(x));
            }
        }

        private void ClassPickerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK && _listClass.SelectedIndex < 0)
            {
                e.Cancel = true;
            }
        }

        public Type SelectedType
        {
            get { return _assembly.GetType(_listClass.SelectedItem.ToString()); }
        }
    }
}
