using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PontozasAranyositassal
{
    public partial class Form1 : Form
    {
        CPontozas pontoz;
        PontErtekTartomany pontTartomany;
        Ertektartomany ertekTartomany;
        PontozasIranya irany;
        double aktErtek;
        public Form1()
        {

            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                irany = PontozasIranya.Felfele;
            }
            else
            {
                irany = PontozasIranya.Lefele;
            }
            aktErtek = Convert.ToDouble(textBox2.Text);
           
            ertekTartomany = new Ertektartomany((double)numericUpDown2.Value, (double)numericUpDown1.Value);
            pontTartomany = new PontErtekTartomany((double)numericUpDown4.Value, (double)numericUpDown3.Value);
            pontoz = new CPontozas(ertekTartomany,pontTartomany,irany);
            pontoz.PontozniAkartErtek=aktErtek;
            pontoz.Pontkiosztas();
            textBox1.Text = pontoz.AdottPontszam.ToString();
        }
    }
}
