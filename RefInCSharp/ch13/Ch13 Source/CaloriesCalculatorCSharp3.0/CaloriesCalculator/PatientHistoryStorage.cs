using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace CaloriesCalculator
{
    class PatientHistoryStorage
    {
        private List<Patient> patients;

        XmlSerializer serializer = 
            new XmlSerializer(typeof(List<Patient>));

        public static string PatientsHistoryFileLocation
        {
            get
            {
                return Assembly.
                    GetExecutingAssembly().Location.Replace(
                    "CaloriesCalculator.exe", "PatientsHistory.bin");
            }
            private set { }
        }

        public PatientHistoryStorage()
        {
            try
            {
                LoadPatientsHistoryFile();
            }
            catch (FileNotFoundException)
            {
                patients = new List<Patient>();                
            }
        }

        public void Save(Patient patient)
        {
            if (PatientIsNew(patient))
            {
                patients.Add(patient);
            }
            SaveHistory();
        }

        private bool PatientIsNew(Patient patient)
        {
            return patients.IndexOf(patient) < 0;           
        }

        private void SaveHistory()
        {
            using (Stream stream = new FileStream(
                PatientsHistoryFileLocation,
                FileMode.Create, FileAccess.Write, 
                FileShare.Write))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, patients);                
                stream.Close();
            }
        }

        private void LoadPatientsHistoryFile()
        {
            using (Stream stream = new FileStream(
                PatientsHistoryFileLocation,
                   FileMode.Open, FileAccess.Read, 
                   FileShare.Read))
            {
                IFormatter formatter = new BinaryFormatter();
                patients = (List<Patient>)
                    formatter.Deserialize(stream);                
                stream.Close();
            }
        }

        public Patient FindPatient(String ssn)
        {
            var found = from patient in this.patients
                        where patient.SSN == ssn
                        select patient;
            return found.FirstOrDefault();
        }
    }

}
