using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaloriesCalculator
{
    public class FemalePatient:Patient
    {
        public override double DailyCaloriesRecommended()
        {
            return 655 + (4.3 * WeightInPounds)
                + (4.7 * HeightInInches) - (4.7 * Age);
        }

        public override double IdealBodyWeight()
        {
            return (45.5 + (2.3 * (HeightInInches - 60))) * 2.2046;
        }
    }
}
