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
using Szerencsefaktor.ForDatabase;

namespace Szerencsefaktor.Forms
{
    public partial class SelectGameTheFirstStart : Form
    {
        string dataDirectory;
        ConfigurationSettings Conf;
        GameFeatures SelectGame;
        CreatingDatatables CreateMSSQlTables;
        public SelectGameTheFirstStart()
        {
            InitializeComponent();
            Conf = new ConfigurationSettings();
            Conf.ReadFromJsonFile("beallitasok.json");

            this.Text = Directory.GetCurrentDirectory();
            dataDirectory = "./Adatallomanyok/";
            groupBox2.Enabled = false;
            
            FillComboboxWithData();
            LoadGameDataFromFile();
            Conf.GameName = comboBox1.SelectedItem.ToString();
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {                       
            FillGameDataToForm(LoadGameDataFromFile());
        }
        #region Other functions and methods
        public void FillComboboxWithData()
        {
            /*
            string[] games = File.ReadAllText(dataDirectory+"games.csv").Split(';');
            foreach (string item in games)
            {
                comboBox1.Items.Add(item);
            }
            comboBox1.SelectedIndex = 2;
            */
            comboBox1.DataSource = Enum.GetValues(typeof(KindOfGame));
            comboBox1.SelectedIndex = 3;
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
            textBox5.Text = game.PlayableIndexFilePath;
            textBox6.Text = game.HitIndexFilePath;
            textBox1.Text = game.SmallestNumber.ToString();
            textBox7.Text = game.LargestNumber.ToString();
            textBox8.Text = game.HowManyCanIPlay.ToString();
            textBox9.Text = game.VibrationYConstantDivisibleBy.ToString(); //osztandó
            textBox10.Text = game.VibrationYConstantDivisor.ToString(); //osztó
            textBox11.Text = game.ConstantValueOfVibrationY.ToString();            
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            //I have to save the game name
            //Ha megváltozott a játék neve csak akkor menti el az új játék nevet
            if (((KindOfGame)comboBox1.SelectedItem).ToString() != Conf.GameName)
            {
                JsonFileManagement.SaveStringToJsonFile(dataDirectory + "beallitasok.json", Conf.SaveToJsonFile(Conf));
            }
            #region CreateDatatableStrings
            // I have to create the datatables
            CreateMSSQlTables = new CreatingDatatables((KindOfGame)comboBox1.SelectedItem);
                                    
            CreateMSSQlTables.DerivedTableNames = Conf.DerivedTablesNames;
            CreateMSSQlTables.BaseTablesStringGeneration();
            CreateMSSQlTables.BaseIndexTablesStringGeneration();
            CreateMSSQlTables.DerivedDataTablesStringGeneration();

            /*
            if ((KindOfGame)comboBox1.SelectedItem != KindOfGame.Kenó )
            {
                CreateMSSQlTables.BaseIndexTablesStringGeneration();
            }
            else
            {
                CreateMSSQlTables.KenoIndexTablesStringGeneration();
            }*/

            #endregion

            #region CreateMssqlDataTables

            File.WriteAllLines("datatbalestring.csv", CreateMSSQlTables.AllTableStrings);
            //DeleteExitsDataTable();


            foreach (string item in CreateMSSQlTables.AllTableStrings)
            {
               
                 try
                {
                    int db = AbKezeloMSSQL.CreatingDataTable(item);
                   // KiIrBoxba.MitIrjonKi($"Érintett elem: {db}", Uzenetek.informació);
                }
                catch (Exception ex)
                {

                  KiIrBoxba.MitIrjonKi(ex.Message, Uzenetek.hiba);
                }
               
            }
            string uzenet = "";
            if (AbKezeloMSSQL.IfDoesTheTableExist("szadatok"))
            {
                uzenet = "létezik";
            }
            else
            {
                uzenet = "nem létezik";
            }
            KiIrBoxba.MitIrjonKi($"A 'szadatok' tábla {uzenet}", Uzenetek.informació);
            #endregion
              



        }
        private void DeleteExitsDataTable()
        {
            foreach (string item in Conf.DrawingTablesNames)
            {
                if (AbKezeloMSSQL.IfDoesTheTableExist(item))
                {
                    AbKezeloMSSQL.DeleteDatatable(item);
                }
            }
            foreach (string item in Conf.DerivedTablesNames)
            {
                if (AbKezeloMSSQL.IfDoesTheTableExist(item))
                {
                    AbKezeloMSSQL.DeleteDatatable(item);
                }
            }
        }
        private void SelectGameTheFirstStart_Load(object sender, EventArgs e)
        {
            
        }
    }
}
