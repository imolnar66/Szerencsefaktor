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

            if (!AbKezeloMSSQL.DoesTheTableExist("huzasokIdeje") && !AbKezeloMSSQL.DoesTheTableExist("szadatok")) //egyik sem létezik
            {
                if (KiIrBoxba.MitIrjonKi("Sem az alap, sem a származtatott adattáblák nem léteznek!\nLétrehozzam azokat? ", Uzenetek.kérdés) == DialogResult.Yes)
                {
                    //JatekKivalasztasa dialog = new JatekKivalasztasa();
                    //dialog.Show;
                }
                else if (AbKezeloMSSQL.DoesTheTableExist("huzasokideje") && !AbKezeloMSSQL.DoesTheTableExist("szadatok")) //csak a származtatott nem létezik
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
    }
}
