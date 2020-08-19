using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szerencsefaktor.Other_classes;

namespace Szerencsefaktor.ForDatabase
{
    class CreatingDatatables
    {
        const string createTable = "CREATE TABLE ";
        const string idCreate = "id INT NOT NULL IDENTITY(1,1) PRIMARY KEY";
        private string tableString;
        private KindOfGame game;
        private SkandiDraws draws;
        private byte maxNumber;
        List<string> derivedTableNames;
        List<string> derivedTableNamesString;
        private string drawTimeTableString;     //húzásokideje tábla string
        private string prizeTableString;        //nyereménytábla string;
        private string drawNumbersTableString;  //húzott számok táblas tring
        private int numberFrom;                 //telitalálatos
        private int numberTo;                   //a legkisebb nyeremyényes találat
        private int numberPiece;                //húzások darabszáma
        private string gameName;                //játék neve
        private string kenoMegjatszottIndexTablaString;
        private string kenoNyeremenySzorzoTablaString;
        private string kenoNyertesMezoSzorzoTablaString;
        private string kenoNyeroOsztalyokbaEsoNyertesSzammezokSzamaTablaString;
        private string baseIndexMegjatszottIndexTableString;
        private string baseIndexTalalatiTablaString;
        private string szadatokTablaString;




        //private string  keno?
        internal KindOfGame Game { get => game; set => game = value; }
        internal SkandiDraws Draws { get => draws; set => draws = value; }
        public string TableString { get => tableString; private set => tableString = value; }
        public string DrawTimeTableString { get => drawTimeTableString; private set => drawTimeTableString = value; }
        public string PrizeTableString { get => prizeTableString; private set => prizeTableString = value; }
        public string DrawNumbersTableString { get => drawNumbersTableString; private set => drawNumbersTableString = value; }
        public int NumberFrom { get => numberFrom; private set => numberFrom = value; }
        public int NumberTo { get => numberTo; private set => numberTo = value; }
        public int NumberPiece { get => numberPiece; private set => numberPiece = value; }
        public string GameName { get => gameName; private set => gameName = value; }
        public string KenoMegjatszottIndexTablaString { get => kenoMegjatszottIndexTablaString; private set => kenoMegjatszottIndexTablaString = value; }
        public string KenoNyeremenySzorzoTablaString { get => kenoNyeremenySzorzoTablaString; private set => kenoNyeremenySzorzoTablaString = value; }
        public string KenoNyertesMezoSzorzoTablaString { get => kenoNyertesMezoSzorzoTablaString; private set => kenoNyertesMezoSzorzoTablaString = value; }
        public string KenoNyeroOsztalyokbaEsoNyertesSzammezokSzamaTablaString { get => kenoNyeroOsztalyokbaEsoNyertesSzammezokSzamaTablaString; private set => kenoNyeroOsztalyokbaEsoNyertesSzammezokSzamaTablaString = value; }
        public string BaseIndexMegjatszottIndexTableString { get => baseIndexMegjatszottIndexTableString; private set => baseIndexMegjatszottIndexTableString = value; }
        public string BaseIndexTalalatiTablaString { get => baseIndexTalalatiTablaString; private set => baseIndexTalalatiTablaString = value; }
        public string SzadatokTablaString { get => szadatokTablaString; private set => szadatokTablaString = value; }
        public byte MaxNumber { get => maxNumber; private set => maxNumber = value; }
        public List<string> DerivedTableNames { get => derivedTableNames; set => derivedTableNames = value; }
        public List<string> DerivedTableNamesString { get => derivedTableNamesString; set => derivedTableNamesString = value; }

        public CreatingDatatables(KindOfGame game, SkandiDraws draws = SkandiDraws.MachineDraws)
        {
            Game = game;
            Draws = draws;
            drawTimeTableString = "";
            prizeTableString = "";
            drawNumbersTableString = "";
            derivedTableNamesString = new List<string>();


            switch (Game)
            {
                case KindOfGame.Ötöslottó:
                    numberFrom = 5; //5 találatos
                    numberTo = 2;   //2 találatos - ezek fizetnek
                    numberPiece = 5;
                    maxNumber = 90;
                    gameName = "Ötöslottó";
                    break;
                case KindOfGame.Hatoslottó:
                    numberFrom = 6;
                    numberTo = 3;
                    numberPiece = 6;
                    maxNumber = 45;
                    gameName = "Hatoslottó";
                    break;
                case KindOfGame.Kenó:
                    numberPiece = 20;
                    gameName = "Kenó";
                    maxNumber = 80;
                    break;
                case KindOfGame.Skandináv_lottó:
                    numberFrom = 7;
                    numberTo = 4;
                    numberPiece = 7;
                    gameName = "Skandinávlottó";
                    maxNumber = 35;
                    break;
            }
        }

        public void BaseTableCodeGeneration()
        {

            //string secondString = "tablaName"            
            string lastString = ", CONSTRAINT HuzasokIdeje_Nyeremenyek_FK FOREIGN KEY (id) REFERENCES huzasokideje(id))";

            //húzások ideje tábla szerkezetének létrehozása
            drawTimeTableString = createTable + "huzasokideje (" + idCreate + ", ev INT NOT NULL, het TINYINT NOT NULL ";
            if (gameName == "Kenó")
            {
                drawTimeTableString += ", huzasnapja TINYINT NOT NULL";
            }
            drawTimeTableString += ", huzasdatuma DATE NOT NULL)";

            //nyereménytábla létrehozása
            //Kenóban nincs nyereménytábla
            if (gameName != "Kenó")
            {
                prizeTableString = createTable + "nyeremények (" + idCreate;
                for (int i = numberFrom; i >= numberTo; i--)
                {
                    prizeTableString += ", talalt" + (i).ToString() + "db INT, talalat" + (i).ToString() + "Ft FLOAT";
                }
                prizeTableString += lastString;
            }

            //húzott számok tábla létrehozása
            drawNumbersTableString = createTable + "huzottszamok (" + idCreate;
            for (int i = 1; i <= numberPiece; i++)
            {
                drawNumbersTableString += ", szam" + (i).ToString() + " TINYINT";
            }
            drawNumbersTableString += lastString;

            //szadatok tábla létrehozása
            string numbers = "";
            for (int i = 1; i <= maxNumber; i++)
            {
                numbers += " szam" + i.ToString() + " INT";
                if (i != maxNumber)
                {
                    numbers += ", ";
                }
            }

            SzadatokTablaString = createTable + "szadatok (" +
                idCreate + ", " +
                numbers + ")";
        }
        public void DerivedDataTablesGeneration() //származtatott adattáblák
        {

            foreach (string item in derivedTableNames)
            {
                string oneTableString = "";
                oneTableString += createTable + " " + item + "(" + idCreate;
                for (int i = 1; i <= maxNumber; i++)
                {
                    oneTableString += ", szam" + i.ToString() + " FLOAT,";
                }
                oneTableString += ", CONSTRAINT FOREIGN KEY (id) REFERENCES szadatok(id))";
                DerivedTableNamesString.Add(oneTableString);
            }
        }
        public void BaseIndexTableStringGeneration()
        {
            string fromToNumber = "";
            BaseIndexMegjatszottIndexTableString = createTable + "megjatszottIndex ( " +
                "indexSzam VARCHAR(3) NOT NULL, " +
                "fixSzamokDb TINYINT, " +
                "kombSzamokDb TINYINT, " +
                "alapJatekokDb INT NOT NULL)";

            for (int i = numberFrom; i >= numberTo; i--)
            {
                fromToNumber += "talalat" + i.ToString() + "Db INT";
                if (i != numberTo)
                {
                    fromToNumber += ", ";
                }
                else
                {
                    fromToNumber += ")";
                }
            }
            BaseIndexTalalatiTablaString = createTable + tableString + "talalatiIndex (" +
                "indexSzam VARCHAR(3) NOT NULL, " +
                "fixSzamok TINYINT, " +
                "kombSzamok TINYINT, " +
                fromToNumber + ")";
        }
        public void KenoIndexTableGeneration()
        {
            //megjatszottIndex 
            //indexSzam pk, jetekTipus, jelolesekSzama, szammezokSzama, alapjatekokSzama ha a tet 1* 2* 3* 4* 5*
            //indexSzam, jetekTipus, jelolesekSzama, szammezokSzama, alapJetekDb1xTet, alapjatekDb2xTet, stb
            KenoMegjatszottIndexTablaString = createTable + "megjatszottIndex (" +
                "indexSzam INT NOT NULL, " +
                "jetekTipus VARCHAR(2), " +
                "jelolesekSzama TINYINT NOT NULL, " +
                "szammezokSzama INT NOT NULL, " +
                "alapjatekDbHaSzorzo1 INT NOT NULL, " +
                "alapjatekDbHaSzorzo2 INT NOT NULL, " +
                "alapjatekDbHaSzorzo3 INT NOT NULL, " +
                "alapjatekDbHaSzorzo4 INT NOT NULL, " +
                "alapjatekDbHaSzorzo5 INT NOT NULL)";
            //talaltiIndex
            //indexSzam, jeleolesekSzama, szammezokSzama, talalatokSzama, 

            KenoNyeremenySzorzoTablaString = createTable + "nyeremenySzorzo (" +
                idCreate + ", " +
                "indexSzam INT NOT NULL, " +
                "talaltokSzama TINYINT NOT NULL, " +
                "nyeremenySzorzoHa1xTet INT NOT NULL, " +
                "nyeremenySzorzoHa2xTet INT NOT NULL, " +
                "nyeremenySzorzoHa3xTet INT NOT NULL, " +
                "nyeremenySzorzoHa4xTet INT NOT NULL, " +
                "nyeremenySzorzoHa5xTet INT NOT NULL, " +
                "CONSTRAINT FOREIGN KEY(indexSzam) REFERENCES megjatszottIndex(indexSzam))";
            /*
             */
            KenoNyertesMezoSzorzoTablaString = createTable + "nyertesMezoSzorzo (" +
                idCreate + ", " +
                "jatekTipus VARCHAR(2), " +
                "nyertesMezoSzorzo10 VARCHAR(10), " +
                "nyertesMezoSzorzo09 VARCHAR(10), " +
                "nyertesMezoSzorzo08 VARCHAR(10), " +
                "nyertesMezoSzorzo07 VARCHAR(10), " +
                "nyertesMezoSzorzo06 VARCHAR(10), " +
                "nyertesMezoSzorzo05 VARCHAR(10), " +
                "nyertesMezoSzorzo04 VARCHAR(10), " +
                "nyertesMezoSzorzo03 VARCHAR(10), " +
                "nyertesMezoSzorzo02 VARCHAR(10), " +
                "nyertesMezoSzorzo01 VARCHAR(10))";

            KenoNyeroOsztalyokbaEsoNyertesSzammezokSzamaTablaString = createTable + "nyeroOsztalybaEsoNyertesSzammezokSzama (" +
                idCreate + ", " +
                "indexSzam INT NOT NULL, " +
                "jatekTipus VARCHAR(2), " +
                "talaltokSzama INT, " +
                "nyertesSzammezokSzama10 INT, " +
                "nyertesSzammezokSzama09 INT, " +
                "nyertesSzammezokSzama08 INT, " +
                "nyertesSzammezokSzama07 INT, " +
                "nyertesSzammezokSzama06 INT, " +
                "nyertesSzammezokSzama05 INT, " +
                "nyertesSzammezokSzama04 INT, " +
                "nyertesSzammezokSzama03 INT, " +
                "nyertesSzammezokSzama02 INT, " +
                "nyertesSzammezokSzama01 INT, " +
                "nyertesSzammezokSzama00 INT) ";
        }
    }
}
