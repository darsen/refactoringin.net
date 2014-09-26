using System;
using System.Collections.Generic;

namespace CaloriesCalculator
{
    [Serializable]
    public abstract class Patient
    {
        protected List<Measurement> measurements = 
            new List<Measurement>();

        public string SSN
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
       } 

        public string LastName
        {
            get;
            set;
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

        public IEnumerable<Measurement> Measurements
        {
            get {
                return measurements;
            }
            protected set {
                measurements = (List<Measurement>)value;
            }
        }

        public abstract decimal DailyCaloriesRecommended();

        public abstract decimal IdealBodyWeight();

        public decimal DistanceFromIdealWeight()
        {
            return WeightInPounds - IdealBodyWeight();
        }

        public void TakeSnapshot()
        {
            Measurement measurement = new Measurement(
                    HeightInInches, WeightInPounds, Age,
                    DailyCaloriesRecommended(), IdealBodyWeight(),
                    DistanceFromIdealWeight());                              
            measurements.Add(measurement);            
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Patient))
            {
                return false;
            }

            return (((Patient)obj).SSN == this.SSN);
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(SSN);
        }
    }
}