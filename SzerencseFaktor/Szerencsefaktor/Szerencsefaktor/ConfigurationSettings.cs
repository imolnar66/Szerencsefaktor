using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Szerencsefaktor.Other_classes;

namespace Szerencsefaktor
{
    class ConfigurationSettings //: ICloneable
    {
        #region fields
        //game
        private string gameName;
        private int smallestNumber;
        private int largestNumber;
        private int howManyCanIPlay;
        private string homePage;
        private string fromWhat;
        private string whereWhat;
        private double constantValueOfVibrationY;
        private int vibrationYConstantDivisibleBy;
        private int vibrationYConstantDivisor;

        //viszonyítási szám
        private int minusNLength;

        //trix
        private int trixSLength;
        private int trixLLength;

        //EMA Exponential Moving Average
        private int shortEma;
        private int longEma;

        //basic settings
        private List<string> drawingTablesNames;
        private List<string> derivedTablesNames;
        private int vibrationTrendLength;
        private string theNameOfTheSavedDataFile;
        private List<string> indicatorNames;

        //Relative Strength Index
        private int rsiLength;
        private int rsiTrendLength;
        private List<double> rsiLevels;

        //ABC length
        private int abcLength;
        #endregion

        #region properties
        //game
        public string GameName 
        {
            get => gameName;
            set 
            {
                if (value != string.Empty)
                {
                    gameName = value;
                }
                else
                {
                    throw new ArgumentException("A 'gameName' változó értéke nem lehet üres karaktersorozat!");
                }
                
            }
        }
        public int SmallestNumber { 
            get => smallestNumber;
            set
            {
                if (value != 0 )
                {
                    smallestNumber = value;
                }
                else
                {
                    throw new ArgumentException("A 'smallestNumber' változó értéke nem lehet nulla!");
                }
                
            }
        }
        public int LargestNumber 
        { 
            get => largestNumber;
            set
            {
                if (value != 0)
                {
                    largestNumber = value;
                }
                else
                {
                    throw new ArgumentException("A 'largestNumber' változó értéke nem lehet nulla!");
                }
                
            }
        }
        public int HowManyCanIPlay 
        { 
            get => howManyCanIPlay;
            set
            {
                if (value != 0)
                {
                    howManyCanIPlay = value;
                }
                else
                {                    
                    throw new ArgumentException("A 'howManyCanIPlay' változó értéke nem lehet nulla!");
                }
                
            }
        }
        public string HomePage 
        {
            get => homePage;
            set
            {
                if (value != string.Empty)
                {
                    homePage = value;
                }
                else
                {
                    throw new ArgumentException("A 'homePage' változó értéke nem lehet üres karaktersorozat!");
                }
                
            }
        }
        public string FromWhat
        {
            get => fromWhat;
            set
            {
                if (value != string.Empty)
                {
                    fromWhat = value;
                }
                else
                {
                    throw new ArgumentException("A 'fromWhat' változó értéke nem lehet üres karaktersorozat!");
                }
                
            } 
        }
        public string WhereWhat 
        { 
            get => whereWhat;
            set
            {
                if (value != string.Empty)
                {
                    whereWhat = value;
                }
                else
                {
                    throw new ArgumentException("A 'whereWhat' változó értéke nem leht üres karaktersorozat!");
                }
                
            }
        }
        public double ConstantValueOfVibrationY
        {
            get => constantValueOfVibrationY;
            set
            {
                if (value !=0)
                {
                    constantValueOfVibrationY = value;
                }
                else
                {
                    throw new ArgumentException("A 'constantValueOfVibrationY' változó értéke nem leht nulla !");
                }
                
            }
        }
        public int VibrationYConstantDivisibleBy 
        {
            get => vibrationYConstantDivisibleBy;
            set 
            {
                if (value != 0)
                {
                    vibrationYConstantDivisibleBy = value;
                }
                else
                {
                    throw new ArgumentException("A 'vibrationYConstantDivisibleBy' változó értéke nem lehet nulla!");
                }
                
            }
        }
        public int VibrationYConstantDivisor 
        {
            get => vibrationYConstantDivisor;
            set 
            {
                if (value != 0)
                {
                    vibrationYConstantDivisor = value;
                }
                else
                {
                    throw new ArgumentException("A 'vibrationYConstantDivisor' változó értéke nem lehet nulla!");
                }

            }
        }
        
        //viszonyítási szám
        public int MinusNLength 
        { 
            get => minusNLength;
            set
            {
                if (value != 0)
                {
                    minusNLength = value;
                }
                else
                {
                    throw new ArgumentException("A 'minusLength' változó értéke nem lehet nulla!");
                }
                
            }
        }

        //trix indikátor
        public int TrixSLength 
        {
            get => trixSLength;
            set
            {
                if (value != 0)
                {
                    trixSLength = value;
                }
                else
                {
                    throw new ArgumentException("A 'trixSLength' változó értéke nem lehet nulla!");
                }
                
            }
        }
        public int TrixLLength 
        { 
            get => trixLLength;
            set
            {
                if (value != 0)
                {
                    trixLLength = value;
                }
                else
                {
                    throw new ArgumentException("A 'trixLLength' változó értéke nem lehet nulla!");
                }
                
            }
        }

        //EMA Exponential Moving Average
        public int ShortEma 
        { 
            get => shortEma;
            set
            {
                if (value != 0)
                {
                    shortEma = value;
                }
                else
                {
                    throw new ArgumentException("A 'shortEma' változó értéke nem lehet nulla! ");
                }
                
            }
        }
        public int LongEma 
        { 
            get => longEma;
            set
            {
                if (value != 0)
                {
                    longEma = value;
                }
                else
                {
                    throw new ArgumentException("A 'longEma' változó értéke nem lehet nulla!");
                }
                
            }
        }

        //basic settings
        public List<string> DrawingTablesNames { get => drawingTablesNames; set => drawingTablesNames = value; }
        public List<string> DerivedTablesNames { get => derivedTablesNames; set => derivedTablesNames = value; }
        public int VibrationTrendLength 
        {
            get => vibrationTrendLength;
            set
            {
                if ( value != 0)
                {
                    vibrationTrendLength = value;
                }
                else
                {
                    throw new ArgumentException("A 'vibrationTrendLength' változó értéke nem lehet nulla!");
                }
                
            }
        }
        public string TheNameOfTheSavedDataFile
        { 
            get => theNameOfTheSavedDataFile;
            set
            {
                if (value != string.Empty)
                {
                    theNameOfTheSavedDataFile = value;
                }
                else
                {
                    throw new ArgumentException("A 'theNameOfTheSavedDataFile' változó étrtéke nem lehet üres karaktersorozat!");
                }
                
            }
        }
        public List<string> IndicatorNames { get => indicatorNames; set => indicatorNames = value; }

        //Relative Strength Index
        public int RsiLength 
        {
            get => rsiLength;
            set
            {
                if (value != 0)
                {
                    rsiLength = value;
                }
                else
                {
                    throw new ArgumentException("A 'rsiLength' változó értéke nem lehet nulla!");
                }
                
            }
        }
        public int RsiTrendLength 
        { 
            get => rsiTrendLength;
            set
            {
                if (value != 0)
                {
                    rsiTrendLength = value;
                }
                else
                {
                    throw new ArgumentException("A 'rsiTrendLength' változó értéke nem lehet nulla!");
                }
                
            }
        }
        public List<double> RsiLevels { get => rsiLevels; set => rsiLevels = value; }
        //ABC length
        public int AbcLength 
        {
            get => abcLength;
            set
            {
                if (value != 0)
                {
                    abcLength = value;
                }
                else
                {
                    throw new ArgumentException("A 'abcLength' változó értéke nem lehet nulla!");
                }
                
            }
        }
        #endregion

        public ConfigurationSettings()
        {
            drawingTablesNames = new List<string>();
            derivedTablesNames = new List<string>();
            indicatorNames = new List<string>();
            rsiLevels = new List<double>();
        }
        public virtual string SaveToJsonFile(ConfigurationSettings conf)
        {
            string resultConvertJson = JsonConvert.SerializeObject(conf);
            return resultConvertJson;
        }

        public virtual void ReadFromJsonFile(string fromJson)
        {
            ConfigurationSettings conf = JsonConvert.DeserializeObject<ConfigurationSettings>(fromJson);
            gameName = conf.gameName;
            smallestNumber = conf.smallestNumber;
            largestNumber = conf.largestNumber;
            howManyCanIPlay = conf.howManyCanIPlay;
            homePage = conf.homePage;
            fromWhat = conf.fromWhat;
            whereWhat = conf.whereWhat;
            constantValueOfVibrationY = conf.constantValueOfVibrationY;
            vibrationYConstantDivisibleBy = conf.vibrationYConstantDivisibleBy;
            vibrationYConstantDivisor = conf.vibrationYConstantDivisor;
            minusNLength = conf.minusNLength;
            trixSLength = conf.trixSLength;
            trixLLength = conf.trixLLength;
            shortEma = conf.shortEma;
            longEma = conf.longEma;
            drawingTablesNames = conf.drawingTablesNames;
            derivedTablesNames = conf.derivedTablesNames;
            vibrationTrendLength = conf.vibrationTrendLength;
            theNameOfTheSavedDataFile = conf.theNameOfTheSavedDataFile;
            indicatorNames = conf.indicatorNames;
            rsiLength = conf.rsiLength;
            rsiTrendLength = conf.rsiTrendLength;
            rsiLevels = conf.rsiLevels;
            abcLength = conf.abcLength;        
        }

        /*public object Clone()
        {
            return this.MemberwiseClone();
        }*/
    }
}
