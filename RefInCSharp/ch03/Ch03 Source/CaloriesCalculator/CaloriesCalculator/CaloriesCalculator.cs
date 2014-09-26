using System;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace CaloriesCalculator
{
    public partial class CaloriesCalculator : Form
    {
        private Patient patient;
        private PatientHistoryXMLStorage storage;

        public CaloriesCalculator()
        {
            InitializeComponent();
            this.storage = new PatientHistoryXMLStorage();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            ClearResults();
            if (!UserInputValid())
            {
                return;
            }
            //Creating instance of Patient subclass
            if (rbtnFemale.Checked)
            {
                patient = new FemalePatient();
            }
            else
            {
                patient = new MalePatient();
            }
            //Setting patient properties with data from form
            patient.HeightInInches = (Convert.ToDouble(txtFeet.Text) * 12)
                + Convert.ToDouble(txtInches.Text);
            patient.WeightInPounds = Convert.ToDouble(txtWeight.Text);
            patient.Age = Convert.ToInt16(txtAge.Text);
            patient.SSN = txtSSNFirstPart.Text +
                txtSSNSecondPart.Text + txtSSNThirdPart.Text;
            patient.FirstName = txtFirstName.Text;
            patient.LastName = txtLastName.Text;
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
                MessageBox.Show("Feet must be a numeric value.");
                txtFeet.Select();
                return false;
            }
            if (!double.TryParse(txtInches.Text, out result))
            {
                MessageBox.Show("Inches must be a numeric value.");
                txtInches.Select();
                return false;
            }
            if (!double.TryParse(txtWeight.Text, out result))
            {
                MessageBox.Show("Weight must be a numeric value.");
                txtWeight.Select();
                return false;
            }
            if (!double.TryParse(txtAge.Text, out result))
            {
                MessageBox.Show("Age must be a numeric value.");
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

        private bool ValidatePatientPersonalData()
        {
            int result;
            if ((!int.TryParse(txtSSNFirstPart.Text, out result)) |
               (!int.TryParse(txtSSNSecondPart.Text, out result)) |
               (!int.TryParse(txtSSNThirdPart.Text, out result)))
            {
                MessageBox.Show("You must enter valid SSN.");
                txtSSNFirstPart.Select();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidatePatientPersonalData())
            {
                return;
            }
            //make sure to perform fresh calculation
            btnCalculate_Click(null, null);
            storage.Save(this.patient);
        }

        private void AddNewPatient(XmlDocument document)
        {
            XmlNode thisPatient =
                document.DocumentElement.FirstChild.CloneNode(false);
            thisPatient.Attributes["ssn"].Value =
                patient.SSN;
            thisPatient.Attributes["firstName"].Value =
                patient.FirstName;
            thisPatient.Attributes["lastName"].Value =
                patient.LastName;
            XmlNode measurement =
                document.DocumentElement.FirstChild["measurement"].CloneNode(true);
            measurement = SetMeasurementValues(measurement);
            thisPatient.AppendChild(measurement);
            document.FirstChild.AppendChild(thisPatient);
        }

        private XmlNode FindPatientNode(XmlDocument document)
        {
            XmlNode patientNode = null;
            foreach (XmlNode node in document.FirstChild.ChildNodes)
            {
                foreach (XmlAttribute attrib in node.Attributes)
                {
                    //We will use SSN to uniquely identify patient
                    if ((attrib.Name == "ssn") & (attrib.Value == patient.SSN))
                    {
                        patientNode = node;
                    }
                }
            }
            return patientNode;
        }

        private XmlDocument CreatePatientsHistoryXmlFirstTime()
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(
            "<PatientsHistory>" +
                "<patient ssn=\"" + patient.SSN + "\"" +
                " firstName=\"" + patient.FirstName + "\"" +
                " lastName=\"" + patient.LastName + "\"" + ">" +
                    "<measurement date=\"" + DateTime.Now + "\"" + ">" +
                        "<height>" + patient.HeightInInches + "</height>" +
                        "<weight>" + patient.WeightInPounds + "</weight>" +
                        "<age>" + patient.Age + "</age>" +
                        "<dailyCaloriesRecommended>" +
                        patient.DailyCaloriesRecommended() +
                        "</dailyCaloriesRecommended>" +
                        "<idealBodyWeight>" +
                        patient.IdealBodyWeight() +
                        "</idealBodyWeight>" +
                        "<distanceFromIdealWeight>" +
                        patient.DistanceFromIdealWeight() +
                        "</distanceFromIdealWeight>" +
                    "</measurement>" +
                "</patient>" +
            "</PatientsHistory>");
            return document;
        }

        private XmlDocument LoadPatientsHistoryFile()
        {
            XmlDocument document = new XmlDocument();
            document.Load(System.Reflection.Assembly.
                GetExecutingAssembly().Location.
                Replace("CaloriesCalculator.exe", "PatientsHistory.xml"));
            return document;
        }

        private XmlNode SetMeasurementValues(XmlNode measurement)
        {
            measurement.Attributes["date"].Value =
                DateTime.Now.ToString();
            measurement["height"].FirstChild.Value =
                patient.HeightInInches.ToString();
            measurement["weight"].FirstChild.Value =
                patient.WeightInPounds.ToString();
            measurement["age"].FirstChild.Value =
                patient.Age.ToString();
            measurement["dailyCaloriesRecommended"].FirstChild.Value =
                patient.DailyCaloriesRecommended().ToString();
            measurement["idealBodyWeight"].FirstChild.Value =
                patient.IdealBodyWeight().ToString();
            measurement["distanceFromIdealWeight"].FirstChild.Value =
                patient.DistanceFromIdealWeight().ToString();
            return measurement;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            Process.Start("IExplore.exe", 
                PatientHistoryXMLStorage.PatientsHistoryFileLocation);
        }
    }
}

