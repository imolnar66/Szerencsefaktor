using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateDataTables
{
    struct StrUsedIndex
    {
        private string indexCount;   //index szám
        private int fixCounts;      //fix számok
        private int combinationCounts;  //kombinációs számok
        private int numberOfBaseGames;  //alapjátékok száma

        public string IndexCount 
        { 
            get => indexCount;
            set 
            {
                if (value != String.Empty)
                {
                    indexCount = value;
                }
                else
                {
                    throw new ArgumentException("Az 'indexszám' mező értéke nem lehet üres!");
                }
                
            }
        }
        public int FixCounts { get => fixCounts; set => fixCounts = value; }
        public int CombinationCounts { get => combinationCounts; set => combinationCounts = value; }
        public int NumberOfBaseGames { get => numberOfBaseGames; set => numberOfBaseGames = value; }
        public StrUsedIndex(string indexCount, int fixCounts, int combinationCounts, int numberOfBaseGames):this()
        {
            IndexCount = indexCount;
            FixCounts = fixCounts;
            CombinationCounts = combinationCounts;
            NumberOfBaseGames = numberOfBaseGames;
        }
        public override string ToString()
        {
            return $"{indexCount} -> fix számok :{fixCounts} db - kombinációs számok :{combinationCounts} db - alapjátékok száma :{numberOfBaseGames} db";
        }
    }
    struct StrTimeOfOtherDraws //egyéb húzások ideje
    {
        private int id;
        private int year;
        private byte week;
        private byte day;
        private DateTime drawOfDate;

        public int Id 
        { 
            get => id;
            set
            {
                if (value != 0)
                {
                    id = value;
                }
                else
                {
                    throw new ArgumentException("Az 'id' mező értéke nem lehet nulla");
                }                
            }
        }
        public int Year
        { 
            get => year;
            set
            {
                if (value != 0)
                {
                    year = value;
                }
                else
                {
                    throw new ArgumentException("Az 'év' mező értéke nem lehet nulla!");
                }                
            }
        }
        public byte Week 
        { 
            get => week;
            set 
            {
                if (week != 0)
                {
                    week = value;
                }
                else
                {
                    throw new ArgumentException("A 'hét' mező értéke nem lehet nulla!");
                }                
            }
        }
        public byte Day
        {
            get => day;
            set
            {
                if (day != 0)
                {
                    day = value;
                }
                else
                {
                    throw new ArgumentException("A 'húzás napja' mező értéke nem lehet nulla!");
                }
            }
        }
        public DateTime DrawOfDate
        {
            get => drawOfDate;
            set 
            {
                if (value != null)
                {
                    drawOfDate = value;
                }
                else
                {
                    throw new ArgumentException("A 'dátum' mező értéke nem lehet null érték!");
                }                
            }
        }
        public StrTimeOfOtherDraws(int id, DateTime drawOfDate, int year, byte week, byte day = 3):this()
        {
            /*
             * Skandináv lottót szerdán húzzák (3),
             * Az ötöslottót szombaton (6),
             * A hatoslottót vasárnap (7),
             * A Kenót a hát minden napján húzzák
             */
            Id = id;
            Year = year;
            Week = week;
            Day = day;
            DrawOfDate = drawOfDate;
        }
        public override string ToString()
        {
            return $"{Id} -> év :{Year} - hét : {Week} - nap :{Day} - húzás dátuma : {DrawOfDate}";
        }
    }
    struct StrPrizes  //nyeremények strukt
    {
        private byte fieldPrize;
        private int prizePiece;
        private float prizeForint;
     
        public byte FieldPrize 
        { 
            get => fieldPrize;
            set
            {
                if (value != 0)
                {
                    fieldPrize = value;
                }
                else
                {
                    throw new ArgumentException("A 'találati' mező értéke nem lehet nulla!");
                }
            }
        }
        public int PrizePiece
        {
            get => prizePiece;
            set
            {
                if (value != 0)
                {
                    prizePiece = value;
                }
                else
                {
                    throw new ArgumentException("A 'nyeremények darabszám' mező értéke nem lehet nulla!");
                }
            }
        }   //nyeremények darab
        public float PrizeForint
        {
            get => prizeForint;
            set
            {
                if (value != 0)
                {
                    prizeForint = value;
                }
                else
                {
                    throw new ArgumentException("A 'nyeremény' mező értéke nem lehet nulla!");
                }

            }
        }   //egy nyeremény értéke

        public StrPrizes(byte fieldPrize, int prizePiece, float prizeForint):this()
        {
            FieldPrize = fieldPrize;
            PrizePiece = prizePiece;
            PrizeForint = prizeForint;
        }
        public override string ToString()
        {
            return $"Nyereménymező :{FieldPrize} - hány darab találat van :{PrizePiece} - egy találat értéke : {PrizeForint}";
        }
    }
    
    class Sturctures
    {
       
    }
}
