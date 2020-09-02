using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VarianciaMatrix;

namespace VarianciaProba
{
    public partial class Form1 : Form
    {
        List<tolIg> ertekHatarok;
        VarianciaSzamolas Szamolas;
        List<List<int>> variaciok;
        List<string> sVariaciok;
        public Form1()
        {
            InitializeComponent();
            ertekHatarok = new List<tolIg>();
            variaciok = new List<List<int>>();
            sVariaciok = new List<string>();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Minimum= numericUpDown1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ertekHatarok.Add(new tolIg((int)numericUpDown1.Value, (int)numericUpDown2.Value));
            LbFrrisit1();
        }
        private void LbFrrisit1() 
        {
            listBox1.DataSource = null;
            listBox1.DataSource = ertekHatarok;
        }
        private void LbFrissit2()
        {
            listBox2.DataSource = null;
            listBox2.DataSource = sVariaciok;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Szamolas = new VarianciaSzamolas(ertekHatarok);
            variaciok = Szamolas.GetKombinaltAdatSorok();
            foreach (List<int> item in variaciok)
            {
                string sor = "";
                foreach (int szam in item)
                {
                    sor += szam.ToString() + " - ";

                }
                sVariaciok.Add(sor);
            }
            LbFrissit2();
        }
    }
}
