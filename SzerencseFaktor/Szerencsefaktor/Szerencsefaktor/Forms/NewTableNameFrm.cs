using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szerencsefaktor.Forms
{
    public partial class NewTableNameFrm : Form
    {
        internal string TableName { get; set; }
        public NewTableNameFrm()
        {
            InitializeComponent();
        }
        public NewTableNameFrm(string tableName):this()
        {
            textBox1.Text = tableName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableName = textBox1.Text;
        }
    }
}
