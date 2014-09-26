using System;

namespace CaloriesCalculator
{   
    [Serializable]
    public struct Measurement
    {
        public Measurement(decimal heightInInches, decimal weightInPounds, 
            int age, decimal dailyCaloriesRecommended, decimal idealBodyWeight,
            decimal distanceFromIdealWeight) : this()
        {
            HeightInInches = heightInInches;
            WeightInPounds = weightInPounds;
            Age = age;
            Date = DateTime.Now;
            DailyCaloriesRecommended = dailyCaloriesRecommended;
            IdealBodyWeight = idealBodyWeight;
            DistanceFromIdealWeight = distanceFromIdealWeight;
        }
        
        public int Age
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public decimal HeightInInches
        {
            get;
            set;
        }

        public decimal WeightInPounds
        {
            get;
            set;
        }
        
        public  decimal DailyCaloriesRecommended{
            get;
            set;
        }

        public decimal IdealBodyWeight{
            get;
            set;
        }

        public decimal DistanceFromIdealWeight
        {
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Measurement))
            {
                return false;
            }

            return (((Measurement)obj).Date == this.Date);

        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(
                this.Date.Day.ToString() +
                this.Date.Month.ToString() +
                this.Date.Year.ToString().Substring(2) +
                this.Date.Millisecond.ToString());
        }
    }
}
