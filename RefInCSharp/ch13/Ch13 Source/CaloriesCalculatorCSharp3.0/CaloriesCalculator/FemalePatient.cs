using System;

namespace CaloriesCalculator
{
    [Serializable]
    public class FemalePatient : Patient
    {
        public override decimal DailyCaloriesRecommended()
        {
            return Decimal.Round(655m + (4.3m * WeightInPounds)
                + (4.7m * HeightInInches) - (4.7m * Age), 2);
        }

        public override decimal IdealBodyWeight()
        {
            return Decimal.Round(
                (45.5m + (2.3m * (HeightInInches - 60m))) * 2.2046m 
                , 2);
        }
    }
}
