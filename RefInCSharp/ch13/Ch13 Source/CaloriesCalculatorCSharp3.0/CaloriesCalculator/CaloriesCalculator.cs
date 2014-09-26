using System;
using System.Windows.Forms;

namespace CaloriesCalculator
{
    public partial class CaloriesCalculator : Form
    {
        private Patient patient;

        private PatientHistoryStorage storage;            

        public CaloriesCalculator()
        {
            InitializeComponent();
            this.storage = new PatientHistoryStorage();            
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            ClearResults();
            if (!UserInputValid())
            {
                return;
            }
            FindOrCreatePatient();                       
            SetPatientData();            
            DisplayCalculationResult();
        }

        private void FindOrCreatePatient()
        {
            patient = storage.FindPatient(CurrentSSN());
            if (patient == null)
            {
                CreateNewPatient();
            }
        }

        private void DisplayCalculationResult()
        {
            txtCalories.Text = patient.
                DailyCaloriesRecommended().ToString();
            txtIdealWeight.Text = patient.
                IdealBodyWeight().ToString();
            txtDistance.Text = patient.
                DistanceFromIdealWeight().ToString();
        }

        private void SetPatientData()
        {
            patient.SSN = CurrentSSN();
            patient.FirstName = txtFirstName.Text;
            patient.LastName = txtLastName.Text;
            patient.Age = Convert.ToInt16(txtAge.Text);
            patient.WeightInPounds = Convert.ToDecimal(txtWeight.Text);
            patient.HeightInInches = (Convert.ToDecimal(txtFeet.Text) * 12)
                                + Convert.ToDecimal(txtInches.Text);
        }

        private void CreateNewPatient()
        {
            if (rbtnFemale.Checked)
            {
                patient = new FemalePatient();
            }
            else
            {
                patient = new MalePatient();
            }            
        }

        private string CurrentSSN()
        {
            return txtSSNFirstPart.Text +
                            txtSSNSecondPart.Text + txtSSNThirdPart.Text;
        }

        private void ClearResults()
        {
            txtDistance.Text = "";
            txtIdealWeight.Text = "";
            txtCalories.Text = "";
        }

        private bool UserInputValid()
        {
            decimal result;
            if (!decimal.TryParse(txtFeet.Text, out result))
            {
                MessageBox.Show("Feet must be a numeric value.");
                txtFeet.Select();
                return false;
            }
            if (!decimal.TryParse(txtInches.Text, out result))
            {
                MessageBox.Show("Inches must be a numeric value.");
                txtInches.Select();
                return false;
            }
            if (!decimal.TryParse(txtWeight.Text, out result))
            {
                MessageBox.Show("Weight must be a numeric value.");
                txtWeight.Select();
                return false;
            }
            if (!decimal.TryParse(txtAge.Text, out result))
            {
                MessageBox.Show("Age must be a numeric value.");
                txtAge.Select();
                return false;
            }
            if (!(Convert.ToDecimal(txtFeet.Text) >= 5))
            {
                MessageBox.Show("Height has to be equals or greater than 5 feet!");
                txtFeet.Select();
                return false;
            }
            return true;
        }

        private bool ValidatePatientPersonalData()
        {
            
            if (SSNNotValid())
            {
                SSNIsInvalid();
                return false;

            }
            if (txtFirstName.Text.Trim().Length < 1)
            {
                MessageBox.Show("You must enter patient’s first name.");
                txtFirstName.Select();
                return false;
            }
            if (txtLastName.Text.Trim().Length < 1)
            {
                MessageBox.Show("You must enter patient’s last name.");
                txtLastName.Select();
                return false;
            }
            return true;

        }

        private void SSNIsInvalid()
        {
            MessageBox.Show("You must enter valid SSN.");
            txtSSNFirstPart.Select();
        }

        private bool SSNNotValid()
        {
            int result;
            return (!int.TryParse(txtSSNFirstPart.Text, out result)) |
                           (!int.TryParse(txtSSNSecondPart.Text, out result)) |
                           (!int.TryParse(txtSSNThirdPart.Text, out result));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidatePatientPersonalData())
            {
                return;
            }            
            PerformFreshCalculation();
            CreateMeasurement();
            storage.Save(this.patient);
        }

        private void CreateMeasurement()
        {
            patient.TakeSnapshot();
        }

        private void PerformFreshCalculation()
        {
            btnCalculate_Click(null, null);
        }       

        private void btnView_Click(object sender, EventArgs e)
        {
            if (SSNNotValid())
            {
                SSNIsInvalid();
                return;
            }
            
            FindOrCreatePatient();
            PatientHistoryViewer viewer = new PatientHistoryViewer            
            {
                Patient = patient             
            };
            viewer.txtSSNFirstPart.Text = txtSSNFirstPart.Text;
            viewer.txtSSNSecondPart.Text = txtSSNSecondPart.Text;
            viewer.txtSSNThirdPart.Text = txtSSNThirdPart.Text;
            viewer.ShowDialog();            
        }


    }
}

