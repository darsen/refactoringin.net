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
            //Clear old results
            txtDistance.Text = "";
            txtIdealWeight.Text = "";
            txtCalories.Text = "";

            /* Validate User Input: */
            //Validate height (feet) is numeric value
            double result;
            if (!double.TryParse(txtFeet.Text, out result))
            {
                MessageBox.Show("Feet must be a numeric value!");
                txtFeet.Select();
                return;
            }
            //Validate height (inches) is numeric value
            if (!double.TryParse(txtInches.Text, out result))
            {
                MessageBox.Show("Inches must be a numeric value!");
                txtInches.Select();
                return;
            }
            //Validate weight is numeric value
            if (!double.TryParse(txtWeight.Text, out result))
            {
                MessageBox.Show("Weight must be a numeric value!");
                txtWeight.Select();
                return;
            }
            //Validate age is numeric value
            if (!double.TryParse(txtAge.Text, out result))
            {
                MessageBox.Show("Age must be a numeric value!");
                txtAge.Select();
                return;
            }
            if (!(Convert.ToDouble(txtFeet.Text) >= 5))
            {
                MessageBox.Show("Height has to be equal or greater than 5 feet!");
                txtFeet.Select();
                return;
            }
            /*End validation*/
            if (rbtnMale.Checked)
            {
                txtCalories.Text = (66
                            + (6.3 * Convert.ToDouble(txtWeight.Text))
                            + (12.9 * ((Convert.ToDouble(txtFeet.Text) * 12)
                            + Convert.ToDouble(txtInches.Text)))
                            - (6.8 * Convert.ToDouble(txtAge.Text))).ToString();
                //Calculate ideal body weight
                txtIdealWeight.Text = ((50 +
                            (2.3 * (((Convert.ToDouble(txtFeet.Text) - 5) * 12)
                            + Convert.ToDouble(txtInches.Text)))) * 2.2046).ToString();
            }
            else
            {
                txtCalories.Text = (655
                            + (4.3 * Convert.ToDouble(txtWeight.Text))
                            + (4.7 * ((Convert.ToDouble(txtFeet.Text) * 12)
                            + Convert.ToDouble(txtInches.Text)))
                            - (4.7 * Convert.ToDouble(txtAge.Text))).ToString();
                //Calculate ideal body weight
                txtIdealWeight.Text = ((45.5 +
                            (2.3 * (((Convert.ToDouble(txtFeet.Text) - 5) * 12)
                            + Convert.ToDouble(txtInches.Text)))) * 2.2046).ToString();
            }
            //Calculate and display distance from ideal weight
            txtDistance.Text = (Convert.ToDouble(txtWeight.Text)
                        - Convert.ToDouble(txtIdealWeight.Text)).ToString();

        }

    }
}
