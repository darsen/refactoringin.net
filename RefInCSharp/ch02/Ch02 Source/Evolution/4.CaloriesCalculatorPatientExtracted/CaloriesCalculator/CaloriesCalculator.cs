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
    private Patient patient;

    public CaloriesCalculator()
    {
        InitializeComponent();
    }

    public Patient Patient {
        get { return patient; }
        set { patient = value; }        
    }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            ClearResults();
            if (!UserInputValid())
            {
                return;
            }
            //Creating new instance of Patient class
            patient = new Patient();
            //Setting patient properties with data from form
            if (rbtnFemale.Checked) {
                patient.Gender = Gender.Female;
            }else{
                patient.Gender = Gender.Male;
            }
            patient.HeightInInches = (Convert.ToDouble(txtFeet.Text) * 12) 
                + Convert.ToDouble(txtInches.Text);
            patient.WeightInPounds = Convert.ToDouble(txtWeight.Text);
            patient.Age = Convert.ToInt16(txtAge.Text);
            txtCalories.Text = patient.DailyCaloriesRecommended().ToString();
            txtIdealWeight.Text = patient.IdealBodyWeight().ToString();
            txtDistance.Text = patient.DistanceFromIdealWeight().ToString();
        }

        private void ClearResults()
        {
            txtDistance.Text = "";
            txtIdealWeight.Text = "";
            txtCalories.Text = "";
        }

        private bool UserInputValid()
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

    }
}
