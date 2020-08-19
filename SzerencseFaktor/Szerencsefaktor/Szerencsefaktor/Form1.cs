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
using Newtonsoft.Json;

namespace Szerencsefaktor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!AbKezeloMSSQL.DoesTheTableExist("huzasokIdeje") && !AbKezeloMSSQL.DoesTheTableExist("szadatok"))
            {
                if (KiIrBoxba.MitIrjonKi("Az adattáblák nem léteznek!\nLétrehozzam azokat? ", Uzenetek.kérdés)==DialogResult.Yes)
                {
                    //JatekKivalasztasa dialog = new JatekKivalasztasa();
                    //dialog.Show;
                }
                else if (!AbKezeloMSSQL.DoesTheTableExist("huzasokideje") && AbKezeloMSSQL.DoesTheTableExist("szadatok"))
                {
                    if (KiIrBoxba.MitIrjonKi("A húzásokhoz kapcsolódó adattáblák nem léteznek!\nA származtatott adatokhoz kapcsolódó adattáblák léteznek!\nLétrehozzam azokat?", Uzenetek.kérdés)==DialogResult.Yes)
                    {
                        KiIrBoxba.MitIrjonKi("A származtatott adatokhoz kapcsolódó táblákat törölni kell!\nTáblákat törlö, majd létrehozom az új üres táblákat\na húzásokhoz és a származtatott adatokhoz!", Uzenetek.informació);
                    }

                }
                else if (true)
                {
                    
                }
            }
        }
    }
}
