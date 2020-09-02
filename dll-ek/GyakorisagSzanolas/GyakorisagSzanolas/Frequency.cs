using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyakorisagSzanolas
{
    /* struct Elem
     {
         private string ertek;
         private int darab;

         public string Ertek { get => ertek; set => ertek = value; }
         public int Darab { get => darab; set => darab = value; }
         public Elem(string ertek, int darab) : this()
         {
             this.ertek = ertek;
             this.darab = darab;
         }
     }*/

    class Elem
    {
        private string ertek;
        private int darab;

       

        public string Ertek { get => ertek; set => ertek = value; }
        public int Darab { get => darab; set => darab = value; }

        public Elem(string ertek, int darab)
        {
            this.ertek = ertek;
            this.darab = darab;
        }

    }

    class Frequency
    {
        /*
         Az osztály visszaadott értéke  egy lista, mely elemei: List<Elem> (Érték, darab);
         */
        private List<Elem> frequencyList;
        private List<string> inputList;
        public List<string> InputList { get => inputList; set => inputList = value; }

        public List<Elem> FrequencyList { get => frequencyList; set => frequencyList = value; }

        public Frequency(List<string> inputList)
        {
            InputList = inputList;
            frequencyList = new List<Elem>();
        }

        public void CauntElement()
        {
            //A bemeneti lista elkső elemét hozzáadja a gyakorisági listához;           

            FrequencyList.Add(new Elem { Ertek = InputList[0].ToString(), Darab = 1 }); //(elem);

            for (int i = 1; i < InputList.Count(); i++)
            {
                int b = 0;

                while (b < FrequencyList.Count())
                {
                    if (FrequencyList[b].Ertek == Convert.ToString(inputList[i]))
                    {

                        Elem elem = new Elem(FrequencyList[b].Ertek, FrequencyList[b].Darab);
                        elem.Darab++;
                        FrequencyList[b] = elem;
                        break;
                    }
                    b++;
                }

                if (b == FrequencyList.Count())
                {
                    FrequencyList.Add(new Elem(InputList[i], 1));
                }
            }
        }
        public string ToSzoveg(int x)
        {
            return "Érték = " + FrequencyList[x].Ertek + " - Darab = " + FrequencyList[x].Darab;
        }

    }
}
