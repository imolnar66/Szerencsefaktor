using System;
using System.Collections.Generic;
using System.Linq;

namespace FrequencyCollection
{
    public class FrequencyCalculation
    {
        private List<int> zeroFrequencyList;
        private List<int> nonZeroFrequencyList;
        private List<int> baseDataList;
        private int largestElement;
        private int sumOfElements;

        public FrequencyCalculation()
        {
            baseDataList = new List<int>();
            zeroFrequencyList = new List<int>();
            nonZeroFrequencyList = new List<int>();
            largestElement = 0;
            sumOfElements = 0;
        }
        public void SetBaseDataList(List<int> baseData)
        {
            baseDataList = baseData;
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
        public int GettheSumOfTheItemsInTheList(bool fromIndexZeroOrOne = false,  bool zeroOrNonZeroList=false)
        {
            //fromIndexZeroOrOne
            //true - from the zero index element
            //false - from the one index element

            //zeroOrNonZeroList
            //true - the sum of the items in the zero list
            //false - the sum of the items in the non zero list
            
            int firstElementIndex;

            if (fromIndexZeroOrOne)
            {
                firstElementIndex = 0;
            }
            else
            {
                firstElementIndex = 1;
            }

            if (zeroOrNonZeroList)
            {
                for (int i = firstElementIndex; i < zeroFrequencyList.Count; i++)
                {
                    sumOfElements += zeroFrequencyList[i];
                }
            }
            else
            {
                for (int i= firstElementIndex; i<nonZeroFrequencyList.Count;i++)
                {
                    sumOfElements += nonZeroFrequencyList[i];
                }
            }
            return sumOfElements;
        }

        /*
         HIÁNYZIK az arányosítás list!!
         */
    }
}
