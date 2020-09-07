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
using Newtonsoft.Json;

namespace Szerencsefaktor.Forms
{
    public partial class SelectGameTheFirstStart : Form
    {
        string dataDirectory;

        GameFeatures SelectGame;
        public SelectGameTheFirstStart()
        {
            InitializeComponent();
            dataDirectory = "./Adatallomanyok/";
            groupBox2.Enabled = false;
            
            FillComboboxWithData();
            LoadGameDataFromFile();
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
            FillGameDataToForm(LoadGameDataFromFile());
        }
        #region Other functions and methods
        public void FillComboboxWithData()
        {
            string[] games = File.ReadAllText(dataDirectory+"games.csv").Split(';');
            foreach (string item in games)
            {
                comboBox1.Items.Add(item);
            }
            comboBox1.SelectedIndex = 0;
        }

        public GameFeatures LoadGameDataFromFile()
        {
            string fajlnev = string.Empty;
            bool gepiKezi = false;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    fajlnev = "otos";
                    break;
                case 1:
                    fajlnev = "hatos";
                    break;
                case 2:
                    fajlnev = "skandi";
                    gepiKezi = true;
                    break;
                case 3:
                    fajlnev = "keno";
                    break;
            }
            SelectGame = new GameFeatures();
            groupBox1.Enabled = gepiKezi;
            //string json = JsonFileManagement.ReadStringFromJsonFile("./Adatallomanyok/otos.json");
            //SelectGame.ConvertJsonStringToJsonFormat(json);
            //SelectGame.ConvertJsonStringToJsonFormat(JsonFileManagement.ReadFromJsonFile(dataDirectory+fajlnev));
            //GameFeatures newGame = JsonConvert.DeserializeObject<GameFeatures>(File.ReadAllText("./Adatallomanyok/otos.json"));
             SelectGame = JsonConvert.DeserializeObject<GameFeatures>(File.ReadAllText(dataDirectory + fajlnev+".json"));
            //SelectGame.ConvertJsonStringToJsonFormat(File.ReadAllText(dataDirectory + fajlnev));
            return SelectGame;
        }

        public void FillGameDataToForm(GameFeatures game)
        {
            textBox2.Text = game.HomePage;
            textBox3.Text = game.FromWhat;
            textBox4.Text = game.WhereWhat;
            //textBox5.Text = ;
            //textBox6.Text = ;
            textBox1.Text = game.SmallestNumber.ToString();
            textBox7.Text = game.LargestNumber.ToString();
            textBox8.Text = game.HowManyCanIPlay.ToString();
            textBox9.Text = game.ConstantValueOfVibrationY.ToString(); //osztandó
            textBox10.Text = game.VibrationYConstantDivisor.ToString(); //osztó
            textBox11.Text = game.ConstantValueOfVibrationY.ToString();            
        }
        #endregion

    }
}
