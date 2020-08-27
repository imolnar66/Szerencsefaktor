using System;
using System.Collections.Generic;

namespace EMACalculation
{
    delegate void EMACalculationIssue();
    public class Calculating
    {
        /*
        * Formula:
        *  alpha = 2/(n+1)
        *  EMAt = alpha * actPrice + (1*alpha)*EMAt-1
        */
        private List<double> inputDataSet;
        private int movingAverageLength;
        private double simpleAverage;
        private double valueOfTheAlphaVariable;
        private List<Double> exponentialAverageList;
        public List<double> ExponentialAverageList => exponentialAverageList; //only get

        public Calculating(List<double> inputDataSet, int movingAverageLength)
        {
            this.inputDataSet = inputDataSet;
            this.movingAverageLength = movingAverageLength;
            simpleAverage = 0;
            valueOfTheAlphaVariable = 0;
            exponentialAverageList = new List<double>();
        }

        public void FirstFillingWithZero()
        {
            for (int i = 0; i < movingAverageLength - 1; i++)
            {
                ExponentialAverageList.Add(0);
            }
        }
        public void SecondSimpleAverageCalculation()
        {
            for (int i = 0; i < movingAverageLength; i++)
            {
                simpleAverage += inputDataSet[i];
            }
            exponentialAverageList.Add(simpleAverage / movingAverageLength);
        }
        public void ThirdAlphaVariableValueCalculation()
        {
            valueOfTheAlphaVariable = (2.0 / (movingAverageLength + 1)); //alpha = 2/(n+1)
        }
        public void FourthExponentialAvergaeCalculation()
        {
            double tempVariable;

            for (int i = movingAverageLength; i < inputDataSet.Count; i++)
            {
                tempVariable = 0;
                tempVariable = (valueOfTheAlphaVariable * inputDataSet[i]) + ((1 - valueOfTheAlphaVariable) * exponentialAverageList[i - 1]); //EMAt = (alpha*actPrice)+((1-alpha)*previous expAverge)
                //tempVariable = ((2 / (movingAverageLength + 1)) * inputDataSet[i]) + ((1 - (2 / (movingAverageLength + 1))) * exponentialAverageList.Last());
                exponentialAverageList.Add(tempVariable);
            }

        }



    }
}
