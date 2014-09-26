using System;
using CaloriesCalculator;
using NUnit.Framework;

namespace TestCaloriesCalculator
{
    [TestFixture]
    public class TestFemalePatient
    {
        private FemalePatient femalePatient;

        [SetUp()]
        public void CreateFemalePatientInstance()
        {
            femalePatient = new FemalePatient();
            femalePatient.HeightInInches = 72;
            femalePatient.WeightInPounds = 110;
            femalePatient.Age = 30;
        }

        [Test()]
        public void TestIdealBodyWeight()
        {
            double expectedResult = 161.15626;
            double realResult = femalePatient.IdealBodyWeight();            
            Assert.AreEqual(expectedResult, realResult);
        }

        [Test()]
        public void TestDailyCaloriesRecommended()
        {            
            double expectedResult = 1325.4;
            double realResult = femalePatient.DailyCaloriesRecommended();
            Assert.AreEqual(expectedResult, realResult);
        }

        [Test(), ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HeightLessThan5Ft()
        {
            femalePatient.HeightInInches = 59;
        }

        [Test()] public void TestBodyFatContent(){
            decimal expectedResult = 36;
            decimal realResult = femalePatient.BodyFatContent();
            Assert.AreEqual(expectedResult, realResult);
        }

    }
}
