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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void _btnGenPropAssign_Click(object sender, EventArgs e)
        {
            ClassPickerForm form = new ClassPickerForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Type type = form.SelectedType;

                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("{0} ob = new {0}();{1}", type.Name, Environment.NewLine);
                type.GetProperties().ToList().ForEach(
                    x => sb.AppendFormat("ob.{0} = {1};{2}", x.Name, GetDefaultValue(x), Environment.NewLine));

                _txtResult.Text = sb.ToString();
            }
        }

        private string GetDefaultValue(PropertyInfo propInfo)
        {
            if (propInfo.PropertyType == typeof (string))
            {
                return "\"\"";
            } else if (propInfo.PropertyType == typeof (decimal))
            {
                return "0";
            }
            else if (propInfo.PropertyType == typeof(int))
            {
                return "0";
            }
            else if (propInfo.PropertyType == typeof(DateTime))
            {
                return "DateTime.Now";
            }
            return "";
        }
    }
}
