using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Szerencsefaktor.Other_classes
{
    class GameFeatures
    {
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
        }
        public virtual void ReadFromJsonFile(string fromJson)
        {
            GameFeatures conf = JsonConvert.DeserializeObject<GameFeatures>(fromJson);
            GameName = conf.gameName;
            SmallestNumber = conf.smallestNumber;
            LargestNumber = conf.largestNumber;
            HowManyCanIPlay = conf.howManyCanIPlay;
            HomePage = conf.homePage;
            FromWhat = conf.fromWhat;
            WhereWhat = conf.whereWhat;
            ConstantValueOfVibrationY = conf.constantValueOfVibrationY;
            VibrationYConstantDivisibleBy = conf.vibrationYConstantDivisibleBy;
            VibrationYConstantDivisor = conf.vibrationYConstantDivisor;            
        }
    }
}
