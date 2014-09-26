using System;

namespace CaloriesCalculator
{
    public abstract class Patient
    {
        private string ssn;
        private string firstName;
        private string lastName;
        private double heightInInches;
        private double weightInPounds;
        private int age;        
        public string SSN
        {
            get { return ssn; }
            set { ssn = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public double HeightInInches
        {
            get { return heightInInches; }
            set {
                if (value <= 60)
                {
                    throw new ArgumentOutOfRangeException(
                        "Height has to be greater " +
                        "than five feet (60 inches)");
                }
                heightInInches = value; 
            }
        }
        public double WeightInPounds
        {
            get { return weightInPounds; }
            set { weightInPounds = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public abstract double DailyCaloriesRecommended();
        
        public abstract double IdealBodyWeight();

        public double DistanceFromIdealWeight() {
            return WeightInPounds - IdealBodyWeight();
        }        
    }
}