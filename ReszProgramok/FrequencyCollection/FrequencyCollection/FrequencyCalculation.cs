using System;
using System.Collections.Generic;
using System.Linq;

namespace FrequencyCollection
{
    public class FrequencyCalculation
    {
        /*
         Ez az osztály arra szolgál, hogy visszaadja az alábiakat:
        1) hányszor húzták egymás után az adott számot -> ennek gyakoriságát,
        2) hányszor nem húzták egymás után az adott számot -> ennek gyakoriságát
        3) az egyes gyakorisági listák elemeinek az összes úzáshoz viszonyított arányát.
            Ennek leényege, hogy mekkora %-ban húzzák vagy nem húzzák az adott számot.
         
         */
        private List<int> zeroFrequencyList;
        private List<int> nonZeroFrequencyList;
        private List<int> baseDataList;
        private List<float> zeroRateList;
        private List<float> nonZeroRateList;
        private int sumOfZeroElements;
        private int sumOfNonZeroElements;
        private bool fromIndexZeroOrOne;
        //private bool zeroOrNonZeroList;
        public FrequencyCalculation()
        {
            baseDataList = new List<int>();
            zeroFrequencyList = new List<int>();
            nonZeroFrequencyList = new List<int>();
            zeroRateList = new List<float>();
            nonZeroRateList = new List<float>();
            sumOfZeroElements = 0;
            sumOfNonZeroElements = 0;
        }
        public void SetBaseDataList(List<int> baseData)
        {
            baseDataList = baseData;
        } 
        public void SetZeroIndexOrNonZeroIndex(bool fromIndexZeroOrOne = false)
        {
            //fromIndexZeroOrOne
            //true - from the zero index element
            //false - from the one index element
            this.fromIndexZeroOrOne = fromIndexZeroOrOne;
        }
        /*public void SetZeroOrNonZeroListCalculation(bool zeroOrNonZeroList = false)
        {
            //zeroOrNonZeroList
            //true - the sum of the items in the zero list
            //false - the sum of the items in the non zero list
            this.zeroOrNonZeroList = zeroOrNonZeroList;
        }        */
        public void ZeroIncidenceFrequencyCalculation()
        {
            int previousValue = baseDataList.First();
            
            if (previousValue > 0)
            {
                zeroFrequencyList.Add(0);
            }
            else
            {
                zeroFrequencyList.Add(1);
            }

            for (int i = 1; i < baseDataList.Count; i++)
            {
                if (baseDataList[i] > previousValue)
                {
                    zeroFrequencyList.Add(0);
                }
                else
                {                
                    if (zeroFrequencyList.Last() == 0)
                    {
                        zeroFrequencyList.Add(1);
                    }
                    else
                    {
                        zeroFrequencyList[zeroFrequencyList.Count - 1]++;
                    }
                }                
                previousValue = baseDataList[1];
            }
        }
        public void NonZeroIncidenceFrequencyCalculation()
        {
            int previousValue = baseDataList.First();
            if (previousValue > 0)
            {
                nonZeroFrequencyList.Add(1);
            }
            else
            {
                nonZeroFrequencyList.Add(0);
            }

            for (int i = 1; i < baseDataList.Count; i++)
            {
                if (baseDataList[i] > previousValue)
                {
                    if (nonZeroFrequencyList.Last() == 0)
                    {
                        nonZeroFrequencyList.Add(1);
                    }
                    else
                    {
                        nonZeroFrequencyList[nonZeroFrequencyList.Count-1]++;
                    }
                }
                else
                {
                    nonZeroFrequencyList.Add(0);
                }
                previousValue = baseDataList[1];
            }
        }
        private int FirstElementIndex()
        {
            int firstElementIndex;

            if (fromIndexZeroOrOne)
            {
                firstElementIndex = 0;
            }
            else
            {
                firstElementIndex = 1;
            }
            return firstElementIndex;
        }
        public void SumOfTheItemsInTheZeroListCalculation()
        {                                                         
                for (int i = FirstElementIndex(); i < zeroFrequencyList.Count; i++)
                {
                    sumOfZeroElements += zeroFrequencyList[i];
                }                    
        }
        public void SumOfTheItemsInTheNonZeroListCalculation()
        {           
                for (int i = FirstElementIndex(); i < nonZeroFrequencyList.Count; i++)
                {
                    sumOfNonZeroElements += nonZeroFrequencyList[i];
                }           
        }
        public void ZeroRateListCalculation()
        {
            try
            {
                for (int i = 1; i < zeroFrequencyList.Count; i++)
                {
                    zeroRateList.Add(zeroFrequencyList[i]/sumOfZeroElements);
                }
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Hiányzik a lista elemek összege!\nFuttassa a 'SumOfTheItemsInTheZeroListCalculation' metódust!", ex);
            }
        }
        public void NonZeroRateListCalculation()
        {
            try
            {
                for (int i = 1; i < nonZeroFrequencyList.Count; i++)
                {
                    nonZeroRateList.Add(nonZeroFrequencyList[i] / sumOfNonZeroElements);
                }
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Hiányzik a lista elemek összege!\nFuttassa a 'SumOfTheItemsInTheNonZeroListCalculation' metódust!", ex);
            }
        }
        public int GetLargestElement()
        {
            int largestNumber = 0;

            foreach (int item in baseDataList)
            {
                if (largestNumber < item)
                {
                    largestNumber = item;
                }
            }
            return largestNumber;
        }
        public int GetSumOfZerotheItemsInTheList()
        {
            return sumOfZeroElements;
        }
        public int GetSumOfNonZerotheItemsInTheList()
        {
            return sumOfNonZeroElements;
        }
        public List<float> GetNonZeroRateList()
        {
            return nonZeroRateList;
        }
        public List<float> GetZeroRateList()
        {
            return zeroRateList;
        }
    }
}
