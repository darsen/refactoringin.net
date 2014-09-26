namespace CaloriesCalculator
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Patient
    {
        private string ssn;
        private string firstName;
        private string lastName;
        private double heightInInches;
        private double weightInPounds;
        private double age;
        private Gender gender;
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
            set { heightInInches = value; }
        }
        public double WeightInPounds
        {
            get { return weightInPounds; }
            set { weightInPounds = value; }
        }
        public double Age
        {
            get { return age; }
            set { age = value; }
        }
        public Gender Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private double DailyCaloriesRecommendedFemale()
        {
            return 655 + (4.3 * WeightInPounds)
                + (4.7 * HeightInInches) - (4.7 * Age);
        }

        private double DailyCaloriesRecommendedMale()
        {
            return 66 + (6.3 * WeightInPounds)
                + (12.9 * HeightInInches) - (6.8 * Age);

        }

        public double DailyCaloriesRecommended()
        {
            if (this.Gender == Gender.Female)
            {
                return DailyCaloriesRecommendedFemale();
            }
            else
            {
                return DailyCaloriesRecommendedMale();
            }
        }

        private double IdealBodyWeightMale()
        {
            return (50 + (2.3 * (HeightInInches - 60))) * 2.2046;
        }

        private double IdealBodyWeightFemale()
        {
            return (45.5 + (2.3 * (HeightInInches - 60))) * 2.2046;
        }

        public double IdealBodyWeight()
        {
            if (this.Gender == Gender.Female)
            {
                return IdealBodyWeightFemale();
            }
            else
            {
                return IdealBodyWeightMale();
            }
        }

        public double DistanceFromIdealWeight()
        {
            if (this.Gender == Gender.Female)
            {
                return DistanceFromIdealWeightFemale();
            }
            else
            {
                return DistanceFromIdealWeightMale();
            }
        }

        private double DistanceFromIdealWeightMale()
        {
            return WeightInPounds - IdealBodyWeightMale();
        }

        private double DistanceFromIdealWeightFemale()
        {
            return WeightInPounds - IdealBodyWeightFemale();
        }

    }
}