using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Szerencsefaktor.Other_classes
{
    public class GameFeatures
    {
        #region MyRegion


        /*
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
        public string GameName
        {
            get => gameName;
            private set
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
        public int SmallestNumber
        {
            get => smallestNumber;
            private set
            {
                if (value != 0)
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
            private set
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
            private set
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
            private set
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
            private set
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
            private set
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
            private set
            {
                if (value != 0)
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
            private set
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
            private set
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
        }*/
        #endregion

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
        private string playableIndexFilePath;
        private string hitIndexFilePath;

        public string GameName { get => gameName; set => gameName = value; }
        public int SmallestNumber { get => smallestNumber; set => smallestNumber = value; }
        public int LargestNumber { get => largestNumber; set => largestNumber = value; }
        public int HowManyCanIPlay { get => howManyCanIPlay; set => howManyCanIPlay = value; }
        public string HomePage { get => homePage; set => homePage = value; }
        public string FromWhat { get => fromWhat; set => fromWhat = value; }
        public string WhereWhat { get => whereWhat; set => whereWhat = value; }
        public double ConstantValueOfVibrationY { get => constantValueOfVibrationY; set => constantValueOfVibrationY = value; }
        public int VibrationYConstantDivisibleBy { get => vibrationYConstantDivisibleBy; set => vibrationYConstantDivisibleBy = value; }
        public int VibrationYConstantDivisor { get => vibrationYConstantDivisor; set => vibrationYConstantDivisor = value; }
        public string PlayableIndexFilePath { get => playableIndexFilePath; set => playableIndexFilePath = value; }
        public string HitIndexFilePath { get => hitIndexFilePath; set => hitIndexFilePath = value; }
        public virtual void ConvertJsonStringToJsonFormat(string fromJson)
        {
            GameFeatures conf = JsonConvert.DeserializeObject<GameFeatures>(fromJson);
            GameName = conf.GameName;
            SmallestNumber = conf.SmallestNumber;
            LargestNumber = conf.LargestNumber;
            HowManyCanIPlay = conf.HowManyCanIPlay;
            HomePage = conf.HomePage;
            FromWhat = conf.FromWhat;
            WhereWhat = conf.WhereWhat;
            ConstantValueOfVibrationY = conf.ConstantValueOfVibrationY;
            VibrationYConstantDivisibleBy = conf.VibrationYConstantDivisibleBy;
            VibrationYConstantDivisor = conf.VibrationYConstantDivisor;
        }
        public virtual string SaveStringFormatToJson(GameFeatures game)
        {
            return JsonConvert.SerializeObject(game, Formatting.Indented);


        }
    }
}
