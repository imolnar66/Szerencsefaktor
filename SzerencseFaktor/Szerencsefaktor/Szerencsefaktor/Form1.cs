using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Szerencsefaktor.ForDatabase;
using Szerencsefaktor.Other_classes;
using DownloadFileFromNet;
using Newtonsoft.Json;
using System.Net.Http;
using Szerencsefaktor.Forms;

namespace Szerencsefaktor
{
    public partial class Form1 : Form
    {
        DownloadFileFromNetClass FileFromNet;
       
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region adattáblák ellenőrzése
                     
            if (!AbKezeloMSSQL.IfDoesTheTableExist("huzasokideje") && !AbKezeloMSSQL.IfDoesTheTableExist("szadatok")) //egyik sem létezik
            {
                if (KiIrBoxba.MitIrjonKi("Nincs kiválasztott játék !\nAdattáblák nem léteznek!\nVálaszt egy játékot? ", Uzenetek.kérdés) == DialogResult.Yes)
                {
                    SelectGameTheFirstStart FirstStart = new SelectGameTheFirstStart();
                    if (FirstStart.ShowDialog() == DialogResult.OK)
                    {
                        //folytatás
                    }
                }
                else if (AbKezeloMSSQL.IfDoesTheTableExist("huzasokideje") && !AbKezeloMSSQL.IfDoesTheTableExist("szadatok")) //csak a származtatott nem létezik
                {
                    if (KiIrBoxba.MitIrjonKi("Az alap adattáblák léteznek!\nA származtatott adattáblák nem léteznek!\nLétrehozzam azokat?", Uzenetek.kérdés) == DialogResult.Yes)
                    {
                        //származtatott adattáblák létrehozása
                    }
                }
            }
            #endregion

            //if-hez mind az alap, mind a származtatott adattábla létezik

            #region Hálózati kapcsolat ellenőrzése
            try
            {
                
            }
            catch (HttpRequestException ex)
            {
                KiIrBoxba.MitIrjonKi($"Adat lekérdezési hiba ! A HGiba üzenet :{ex}", Uzenetek.hiba);                   
            }
            #endregion

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            AbKezeloMSSQL.DisconnectTheDatabase();
        }
    }
}
