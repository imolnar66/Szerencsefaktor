using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szerencsefaktor.Other_classes;
using Szerencsefaktor.ForDatabase;


namespace Szerencsefaktor.Forms
{
    public partial class ConfigurationSettingsFrm : Form
    {
        internal ConfigurationSettings ConfSettings { get; set; }
        bool focusLb1;
        bool focusLb2;
        int rowNumber;
        

        public ConfigurationSettingsFrm()
        {
            InitializeComponent();
            rowNumber = -1;
            focusLb1 = false;
            focusLb2 = false;           
        }
        internal ConfigurationSettingsFrm(ConfigurationSettings conf):this()
        {
            ConfSettings = conf;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //ConfSettings = new ConfigurationSettings();

            //basic settings
           // ConfSettings.GameName = textBox1.Text;
            //ConfSettings.DrawingTablesNames = listBox1.DataSource;
            //ConfSettings.DerivedTablesNames = listBox2.DataSource;
            //ConfSettings.VibrationTrendLength = (int)numericUpDown1.Value;
            //ConfSettings.IndicatorNames = listBox3.DataSource;

            //game settings
            /* nem módosítható értékek
            ConfSettings.GameName = textBox1.Text;
            ConfSettings.SmallestNumber= textBox2.Text;
            ConfSettings.LargestNumber = textBox3.Text;
            ConfSettings.HowManyCanIPlay = textBox4.Text;
            ConfSettings.HomePage = textBox5.Text;
            ConfSettings.FromWhat = textBox6.Text;
            ConfSettings.WhereWhat = textBox7.Text;
            ConfSettings.ConstantValueOfVibrationY = textBox8.Text;
            ConfSettings.VibrationYConstantDivisibleBy = textBox9.Text;
            ConfSettings.VibrationYConstantDivisor = textBox10.Text;

            */
            //EMA
            ConfSettings.ShortEma =(int)numericUpDown2.Value;
            ConfSettings.LongEma = (int)numericUpDown3.Value;

            //trix
            ConfSettings.TrixSLength = (int)numericUpDown4.Value;
            ConfSettings.TrixLLength = (int)numericUpDown5.Value;

            //RSI
            ConfSettings.RsiLength = (int)numericUpDown6.Value;
            ConfSettings.RsiTrendLength = (int)numericUpDown7.Value;
            //ConfSettings.RsiLevels = listBox4.DataSource;

            //viszonyítási szám
            ConfSettings.MinusNLength = (int)numericUpDown9.Value;

            //ABC
            ConfSettings.AbcLength = (int)numericUpDown10.Value;
            if (tabControl1.Enabled)
            {
                tabControl1.Enabled = false;
            }
            
        }

        private void ConfigurationSettingsFrm_Load(object sender, EventArgs e)
        {
            this.Top = 200;
            this.Left = 400;

            //basic settings
            textBox1.Text = ConfSettings.GameName;
            listBox1.DataSource = ConfSettings.DrawingTablesNames;
            listBox2.DataSource = ConfSettings.DerivedTablesNames;
            numericUpDown1.Value = ConfSettings.VibrationTrendLength;
            listBox3.DataSource = ConfSettings.IndicatorNames;

            //game settings
            textBox1.Text = ConfSettings.GameName;
            textBox2.Text = ConfSettings.SmallestNumber.ToString();
            textBox3.Text = ConfSettings.LargestNumber.ToString();
            textBox4.Text = ConfSettings.HowManyCanIPlay.ToString();
            textBox5.Text = ConfSettings.HomePage;
            textBox6.Text = ConfSettings.FromWhat;
            textBox7.Text = ConfSettings.WhereWhat;
            textBox8.Text = ConfSettings.ConstantValueOfVibrationY.ToString();
            textBox9.Text = ConfSettings.VibrationYConstantDivisibleBy.ToString();
            textBox10.Text = ConfSettings.VibrationYConstantDivisor.ToString();

            //EMA
            numericUpDown2.Value = ConfSettings.ShortEma;
            numericUpDown3.Value = ConfSettings.LongEma;

            //trix
            numericUpDown4.Value = ConfSettings.TrixSLength;
            numericUpDown5.Value = ConfSettings.TrixLLength;

            //RSI
            numericUpDown6.Value = ConfSettings.RsiLength;
            numericUpDown7.Value = ConfSettings.RsiTrendLength;
            listBox4.DataSource = ConfSettings.RsiLevels;

            //viszonyítási szám
            numericUpDown9.Value = ConfSettings.MinusNLength;

            //ABC
            numericUpDown10.Value = ConfSettings.AbcLength;
        }
        #region RSI modifier      
        private void button9_Click(object sender, EventArgs e)
        {
            if (rowNumber !=-1)
            {
                rowNumber = -1;
            }
            ConfSettings.RsiLevels.Add((int)numericUpDown8.Value);
            ConfSettings.RsiLevels.Sort();
            numericUpDown8.Value = 0;
            LbRefresh4();
        }

        private void LbRefresh4()
        {
            listBox4.DataSource = null;
            listBox4.DataSource = ConfSettings.RsiLevels;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (listBox4.SelectedIndex != -1)
            {
                rowNumber = listBox4.SelectedIndex;
                numericUpDown8.Value = Convert.ToInt32(listBox4.SelectedItem);
            }
            ListboxItemRemove();

        }
        private void ListboxItemRemove()
        {
            if (numericUpDown8.Value == (int) listBox4.SelectedItem)
            {
                ConfSettings.RsiLevels.RemoveAt(listBox4.SelectedIndex);
                LbRefresh4();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (listBox4.SelectedIndex != -1)
            {
                ConfSettings.RsiLevels.RemoveAt(listBox4.SelectedIndex);
                LbRefresh4();
            }
        }
        #endregion

        #region Indikátorlista kezelése
        private void button6_Click(object sender, EventArgs e)
        {
            

        }

        #endregion

        private void button12_Click(object sender, EventArgs e)
        {
            if (KiIrBoxba.MitIrjonKi("Módosítani szeretné az adatokat?",Other_classes.Uzenetek.kérdés)==DialogResult.Yes)
            {
                tabControl1.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewTableNameFrm dialogus = new NewTableNameFrm();
            if (dialogus.ShowDialog() == DialogResult.OK)
            {
                if (focusLb1)
                {
                    ConfSettings.DrawingTablesNames.Add(dialogus.TableName);
                    LbRefresh1();
                }
                else if (focusLb2)
                {

                    ConfSettings.DerivedTablesNames.Add(dialogus.TableName);
                    LbReferesh2();
                }
                else
                {
                    KiIrBoxba.MitIrjonKi("Kattintson arra a listbox-ra amelyiknek az adatait módosítani szeretné!", Uzenetek.informacio);
                }
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            focusLb1 = true;
            focusLb2 = false;
            button3.Text = "Új elem a húzások táblában";
            button4.Text = "Húzások tábla nevének módosítása";
        }

        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {
            focusLb1 = false;
            focusLb2 = true;
            button3.Text = "Új elem a származtatott táblában";
            button4.Text = "Származtatott tábla nevének módosítása";
        }

        private void LbRefresh1()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = ConfSettings.DrawingTablesNames;
        }

        private void LbReferesh2()
        {
            listBox2.DataSource = null;
            listBox2.DataSource = ConfSettings.DerivedTablesNames;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (focusLb1)
            {
                if (listBox1.SelectedIndex != -1)
                {
                    NewTableNameFrm dialogus = new NewTableNameFrm((string)listBox1.SelectedItem);
                    if (dialogus.ShowDialog() == DialogResult.OK)
                    {
                        ConfSettings.DrawingTablesNames[listBox1.SelectedIndex] = dialogus.TableName;
                        LbRefresh1();
                    }
                }
            }
            else if (focusLb2)
            {
                if (listBox2.SelectedIndex != -1)
                {
                    NewTableNameFrm dialogus = new NewTableNameFrm((string)listBox2.SelectedItem);
                    if (dialogus.ShowDialog()==DialogResult.OK)
                    {
                        ConfSettings.DerivedTablesNames[listBox2.SelectedIndex] = dialogus.TableName;
                        LbReferesh2();
                    }
                }

            }
        }
    }
}
