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
using Szerencsefaktor.FajlKezeles;



namespace Szerencsefaktor.Forms
{
    public partial class ConfigurationSettingsFrm : Form
    {

        internal ConfigurationSettings ConfSettings { get; set; }
        ConfigurationSettings ConfSett;
        GameFeatures Game;
        ReferenciaNumber RefNum;
        ConfigurationSettings Conf;
        TrixSettings Trix;
        EmasSettings EmaS;
        RsiSettings RsiS;
        ABCLongSettings ABCS;
        bool focusLb1;
        bool focusLb2;
        int rowNumber;
        

        public ConfigurationSettingsFrm()
        {
            InitializeComponent();
            #region The basic settings load from json file
            ConfSett = new ConfigurationSettings();
            ConfSett.ReadFromJsonFile(JsonFileManagement.ReadStringFromJsonFile("beallitasok.json"));
            #endregion          

            #region This is section loading the game features
            Game = new GameFeatures();
            Game.ConvertJsonStringToJsonFormat(JsonFileManagement.ReadStringFromJsonFile(Conf.GameName + ".json"));
            #endregion

            #region This is section loading the reference number from json file
            RefNum = new ReferenciaNumber();
            RefNum.ReadFromJsonFile(JsonFileManagement.ReadStringFromJsonFile("viszonyitasiszam.json"));
            #endregion

            #region This is section loading the ABC length settings from Json file for trend determination 
            ABCS = new ABCLongSettings();
            ABCS.ReadFromJsonFile(JsonFileManagement.ReadStringFromJsonFile("abc.json"));
            #endregion

            #region This is section loading the RSI indicator settings from json file
            RsiS = new RsiSettings();
            RsiS.ReadFromJsonFile(JsonFileManagement.ReadStringFromJsonFile("rsi.json"));
            #endregion

            #region This is module loading the Trix indicator datas from Json file
            Trix = new TrixSettings();
            Trix.ReadFromJsonFile(JsonFileManagement.ReadStringFromJsonFile("trix.json"));
            #endregion

            #region This is modul loading the EMA settings from Json file
            EmaS = new EmasSettings();
            EmaS.ReadFromJsonFile(JsonFileManagement.ReadStringFromJsonFile("ema.json"));
            #endregion

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
            
            //EMA
            EmaS.ShortEma =(int)numericUpDown2.Value;
            EmaS.LongEma = (int)numericUpDown3.Value;
            
            
            //trix
            Trix.TrixSLength = (int)numericUpDown4.Value;
            Trix.TrixLLength = (int)numericUpDown5.Value;
          
            
            //RSI
            RsiS.RsiLength = (int)numericUpDown6.Value;
            RsiS.RsiTrendLength = (int)numericUpDown7.Value;
                   

            //viszonyítási szám
            RefNum.MinusNLength = (int)numericUpDown9.Value;
           
            //ABC
            ABCS.AbcLength = (int)numericUpDown10.Value;
            if (tabControl1.Enabled)
            {
                tabControl1.Enabled = false;
            }
            #region Data save to Json file                                   
            JsonFileManagement.SaveStringToJsonFile("viszonyitasiszam.json", RefNum.SaveToJsonFile(RefNum.MinusNLength));
            JsonFileManagement.SaveStringToJsonFile("trix.json",Trix.SaveToJsonFile(Trix));
            JsonFileManagement.SaveStringToJsonFile("ema.json",EmaS.SaveToJsonFile(EmaS));
            JsonFileManagement.SaveStringToJsonFile("rsi.json",RsiS.SaveToJsonFile(RsiS));
            JsonFileManagement.SaveStringToJsonFile("abc.json",ABCS.SaveToJsonFile(ABCS));
            JsonFileManagement.SaveStringToJsonFile("beallitasok.json",ConfSett.SaveToJsonFile(ConfSett));
            #endregion
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
            textBox1.Text = Game.GameName;
            textBox2.Text = Game.SmallestNumber.ToString();
            textBox3.Text = Game.LargestNumber.ToString();
            textBox4.Text = Game.HowManyCanIPlay.ToString();
            textBox5.Text = Game.HomePage;
            textBox6.Text = Game.FromWhat;
            textBox7.Text = Game.WhereWhat;
            textBox8.Text = Game.ConstantValueOfVibrationY.ToString();
            textBox9.Text = Game.VibrationYConstantDivisibleBy.ToString();
            textBox10.Text = Game.VibrationYConstantDivisor.ToString();

            //EMA
            numericUpDown2.Value = EmaS.ShortEma;
            numericUpDown3.Value = EmaS.LongEma;

            //trix
            numericUpDown4.Value = Trix.TrixSLength;
            numericUpDown5.Value = Trix.TrixLLength;

            //RSI
            numericUpDown6.Value = RsiS.RsiLength;
            numericUpDown7.Value = RsiS.RsiTrendLength;
            listBox4.DataSource = RsiS.RsiLevels;

            //viszonyítási szám
            numericUpDown9.Value = RefNum.MinusNLength;

            //ABC
            numericUpDown10.Value = ABCS.AbcLength;
        }
        #region RSI modifier      
        private void button9_Click(object sender, EventArgs e)
        {
            if (rowNumber !=-1)
            {
                rowNumber = -1;
            }
            RsiS.RsiLevels.Add((int)numericUpDown8.Value);
            RsiS.RsiLevels.Sort();
            numericUpDown8.Value = 0;
            LbRefresh4();
        }

        private void LbRefresh4()
        {
            listBox4.DataSource = null;
            listBox4.DataSource = RsiS.RsiLevels;
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
                RsiS.RsiLevels.RemoveAt(listBox4.SelectedIndex);
                LbRefresh4();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (listBox4.SelectedIndex != -1)
            {
                RsiS.RsiLevels.RemoveAt(listBox4.SelectedIndex);
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
                    KiIrBoxba.MitIrjonKi("Kattintson arra a listbox-ra amelyiknek az adatait módosítani szeretné!", Uzenetek.informació);
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
