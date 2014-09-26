using System;
using System.Xml;
using System.IO;

namespace CaloriesCalculator
{
    class PatientHistoryXMLStorage
    {
        public static string PatientsHistoryFileLocation
        {
            get
            {
                return System.Reflection.Assembly.
                GetExecutingAssembly().Location.Replace(
                    "CaloriesCalculator.exe", "PatientsHistory.xml");
            }
            private set { }
        }

        private XmlDocument document;
        private Patient patient;

        public PatientHistoryXMLStorage()
        {
            this.document = new XmlDocument();
        }

        public void Save(Patient patient)
        {
            this.patient = patient;
            bool fileCrated = true;
            try
            {
                LoadPatientsHistoryFile();
            }
            catch (FileNotFoundException)
            {
                fileCrated = false;
            }
            if (!fileCrated)
            {
                CreatePatientsHistoryXmlFirstTime();
            }
            else
            {
                XmlNode patientNode = FindPatientNode();
                if (patientNode == null)
                {
                    AddNewPatient();
                }
                else
                {
                    XmlNode measurement = patientNode.FirstChild.CloneNode(true);
                    measurement = SetMeasurementValues(measurement);
                    patientNode.AppendChild(measurement);
                }
            }
            document.Save(PatientsHistoryFileLocation);
        }

        private void CreatePatientsHistoryXmlFirstTime()
        {
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
        }

        private void LoadPatientsHistoryFile()
        {
            document.Load(PatientsHistoryFileLocation);           
        }

        private void AddNewPatient()
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

        private XmlNode FindPatientNode()
        {
            XmlNode patientNode = null;

            foreach (XmlNode node in document.FirstChild.ChildNodes)
            {
                foreach (XmlAttribute attrib in node.Attributes)
                {
                    if ((attrib.Name == "ssn") & (attrib.Value == patient.SSN))
                    {
                        patientNode = node;
                    }
                }
            }
            return patientNode;
        }
    }
}
