using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Szerencsefaktor.Other_classes;
using Szerencsefaktor.FajlKezeles;

namespace Szerencsefaktor.Forms
{
    public partial class SelectGameTheFirstStart : Form
    {
        GameFeatures SelectGame;
        public SelectGameTheFirstStart()
        {
            InitializeComponent();
            groupBox2.Enabled = false;
            SelectGame = new GameFeatures();
            FillComboboxWithData();
            LoadGameDataFromFile();
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGameDataFromFile();
        }
        #region Other functions and methods
        public void FillComboboxWithData()
        {
            string[] games = File.ReadAllText("games.csv").Split(';');
            foreach (string item in games)
            {
                comboBox1.Items.Add(item);
            }
            comboBox1.SelectedIndex = 0;
        }

        public void LoadGameDataFromFile()
        {
            string fajlnev = string.Empty;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    fajlnev = "otos.json";
                    break;
                case 1:
                    fajlnev = "hatos.json";
                    break;
                case 2:
                    fajlnev = "skandi.json";
                    break;
                case 3:
                    fajlnev = "keno.json";
                    break;
            }
            SelectGame.ReadFromJsonFile(JsonFileManagement.ReadFromJsonFile(fajlnev));
        }

        public void FillGameDataToForm()
        {
            textBox2.Text = SelectGame.HomePage;
            textBox3.Text = SelectGame.FromWhat;
            textBox4.Text = SelectGame.WhereWhat;
            //textBox5.Text = ;
            //textBox6.Text = ;
            textBox1.Text = SelectGame.SmallestNumber.ToString();
            textBox7.Text = SelectGame.LargestNumber.ToString();
            textBox8.Text = SelectGame.HowManyCanIPlay.ToString();
            textBox9.Text = SelectGame.ConstantValueOfVibrationY.ToString(); //osztandó
            textBox10.Text = SelectGame.VibrationYConstantDivisor.ToString(); //osztó
            textBox11.Text = SelectGame.ConstantValueOfVibrationY.ToString();

            
        }
        #endregion

    }
}
