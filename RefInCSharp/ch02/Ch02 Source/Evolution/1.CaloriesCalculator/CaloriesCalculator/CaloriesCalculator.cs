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
            if (rbtnMale.Checked)
            {
                txtCalories.Text = (66
                            + (6.3 * Convert.ToDouble(txtWeight.Text))
                            + (12.9 * ((Convert.ToDouble(txtFeet.Text) * 12)
                            + Convert.ToDouble(txtInches.Text)))
                            - (6.8 * Convert.ToDouble(txtAge.Text))).ToString();
            }
            else
            {
                txtCalories.Text = (655
                            + (4.3 * Convert.ToDouble(txtWeight.Text))
                            + (4.7 * ((Convert.ToDouble(txtFeet.Text) * 12)
                            + Convert.ToDouble(txtInches.Text)))
                            - (4.7 * Convert.ToDouble(txtAge.Text))).ToString();
            }

        }
    }
}
