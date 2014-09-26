    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaloriesCalculator
{
    public class MalePatient:Patient
    {
        public override double DailyCaloriesRecommended()
        {
            return 66 + (6.3 * WeightInPounds)
                + (12.9 * HeightInInches) - (6.8 * Age);
        }

        public override double IdealBodyWeight()
        {
            return (50 + (2.3 * (HeightInInches - 60))) * 2.2046;
        }
    }
}
