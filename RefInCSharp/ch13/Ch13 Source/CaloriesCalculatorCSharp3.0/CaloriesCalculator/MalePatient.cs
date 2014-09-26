using System;

namespace CaloriesCalculator
{
    [Serializable]
    class MalePatient : Patient
    {

        public override decimal DailyCaloriesRecommended()
        {
            return Decimal.Round(66m + (6.3m * WeightInPounds)
                + (12.9m * HeightInInches) - (6.8m * Age),2);
        }

        public override decimal IdealBodyWeight()
        {
            return Decimal.Round(
                (50m + (2.3m * (HeightInInches - 60m))) * 2.2046m 
                , 2);
        }
    }
}
