using System;
using System.IO;

namespace FileSizeInfo
{
    public class FajlMeretInfo
    {
        /*Az osztály összehasonlítja két fájl méretét. Ha a két fájl megegyezik akkor true, ha nem akkor false eredményt ad vissza.
         Ezen kívul le lehet kérdezni két állomány méretét*/
        #region Fields
        string fajlNevUtvonal1;
        string fajlNevUtvonal2;
        long fajl1Meret;
        long fajl2Meret;


        public string FajlNevUtvonal1
        {
            get => fajlNevUtvonal1;
            set
            {
                if (value != "")
                {
                    fajlNevUtvonal1 = value;
                }
                else
                {
                    throw new ArgumentException("A fájl elérési útja és neve nem lehet üres mező!");
                }

            }
        }
        public string FajlNevUtvonal2
        {
            get => fajlNevUtvonal2;
            set
            {
                if (value != "")
                {
                    fajlNevUtvonal2 = value;
                }
                else
                {
                    throw new ArgumentException("A fájl elérési útja és neve nem lehet üres mező!");
                }

            }
        }
        public long Fajl1Meret { get => fajl1Meret; private set => fajl1Meret = value; }
        public long Fajl2Meret { get => fajl2Meret; private set => fajl2Meret = value; }

        #endregion

        #region Construktor

        public FajlMeretInfo(string fajlNevUtvonal1, string fajlNevUtvonal2)
        {
            FajlNevUtvonal1 = fajlNevUtvonal1;
            FajlNevUtvonal2 = fajlNevUtvonal2;
            Fajl1Meret = new FileInfo(FajlNevUtvonal1).Length;
            Fajl2Meret = new FileInfo(FajlNevUtvonal2).Length;
        }
        #endregion

        #region Other functions and methods
        public long GetFajlMeret1()
        {

            return Fajl1Meret;
        }

        public long GetFajlMeret2()
        {
            return Fajl2Meret;
        }

        public static bool AzonosMeretE(string utvonalnev1, string utvonalnev2)
        {
            if (utvonalnev1 != "" && utvonalnev2 != "")
            {
                long meret1 = new FileInfo(utvonalnev1).Length;
                long meret2 = new FileInfo(utvonalnev2).Length;
                if (meret1 == meret2)
                {
                    return true;
                }
                return false;
            }
            else
            {
                throw new ArgumentException("Nem adott meg érvényes útvonalat és fájlnevet !");
            }

        }

        public static bool LetezikEAFajl(string utvonalNev)
        {
            if (utvonalNev != "")
            {
                if (File.Exists(@utvonalNev))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new ArgumentException("Nem adott meg érvényes útvonalat és fájlnevet!");
            }


        }
        #endregion

    }
}

