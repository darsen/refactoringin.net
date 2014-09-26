using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CaloriesCalculator
{
    public partial class CaloriesCalculator : Form
    {
        public CaloriesCalculator()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            clearResults();
            if (!userInputValid())
            {
                return;
            }
            if (rbtnMale.Checked)
            {
                txtCalories.Text = dailyCaloriesRecommendedMale(
                    Convert.ToDouble(txtWeight.Text),
                    (Convert.ToDouble(txtFeet.Text) * 12) 
                    + Convert.ToDouble(txtInches.Text),
                    Convert.ToDouble(txtAge.Text)).ToString();

                txtIdealWeight.Text = idealBodyWeightMale((
                    Convert.ToDouble(txtFeet.Text) * 12)
                    + Convert.ToDouble(txtInches.Text)).ToString();
            }
            else
            {
                txtCalories.Text = dailyCaloriesRecommendedMale(
                    Convert.ToDouble(txtWeight.Text),
                    (Convert.ToDouble(txtFeet.Text) * 12) 
                    + Convert.ToDouble(txtInches.Text),
                    Convert.ToDouble(txtAge.Text)).ToString();

                txtIdealWeight.Text = idealBodyWeightFemale(
                    (Convert.ToDouble(txtFeet.Text) * 12)
                    + Convert.ToDouble(txtInches.Text)).ToString();
            }

            txtDistance.Text = distanceFromIdealWeight(
                Convert.ToDouble(txtWeight.Text),
                Convert.ToDouble(txtIdealWeight.Text)).ToString();
        }

        private void clearResults()
        {
            txtDistance.Text = "";
            txtIdealWeight.Text = "";
            txtCalories.Text = "";
        }

        public bool userInputValid()
        {
            double result;
            if (!double.TryParse(txtFeet.Text, out result))
            {
                MessageBox.Show("Feet must be a numeric value!");
                txtFeet.Select();
                return false;
            }
            if (!double.TryParse(txtInches.Text, out result))
            {
                MessageBox.Show("Inches must be a numeric value!");
                txtInches.Select();
                return false;
            }
            if (!double.TryParse(txtWeight.Text, out result))
            {
                MessageBox.Show("Weight must be a numeric value!");
                txtWeight.Select();
                return false;
            }
            if (!double.TryParse(txtAge.Text, out result))
            {
                MessageBox.Show("Age must be a numeric value!");
                txtAge.Select();
                return false;
            }
            if (!(Convert.ToDouble(txtFeet.Text) >= 5))
            {
                MessageBox.Show("Height has to be equals or greater than 5 feet!");
                txtFeet.Select();
                return false;
            }
            return true;
        }

        private double distanceFromIdealWeight(double actualWeightInPounds,
            double idealWeightInPounts)
        {
            return actualWeightInPounds - idealWeightInPounts;
        }

        private double dailyCaloriesRecommendedMale(double weightInPounds,
            double heightInInches, double age)
        {
            return 66 + (6.3 * weightInPounds) 
                + (12.9 * heightInInches) - (6.8 * age);

        }

        private double dailyCaloriesRecommendedFemale(double weightInPounds,
            double heightInInches, double age)
        {
            return 655 + (4.3 * weightInPounds) 
                + (4.7 * heightInInches) - (4.7 * age);

        }

        private double idealBodyWeightMale(double heightInInches)
        {
            return (50 + (2.3 * (heightInInches - 60))) * 2.2046;
        }

        private double idealBodyWeightFemale(double heightInInches)
        {
            return (45.5 + (2.3 * (heightInInches - 60))) * 2.2046;
        }

    }
}
