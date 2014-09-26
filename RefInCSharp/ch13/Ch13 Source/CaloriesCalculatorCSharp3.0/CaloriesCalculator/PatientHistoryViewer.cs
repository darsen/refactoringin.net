using System;
using System.Windows.Forms;

namespace CaloriesCalculator
{
    public partial class PatientHistoryViewer : Form
    {
        Patient patient;

        public Patient Patient
        {
            get { return patient; }
            set { patient = value; }
        }

        public PatientHistoryViewer()
        {
            InitializeComponent();                                                             
        }

        private void PatientHistoryViewer_Load(object sender, EventArgs e)
        {
            grid.DataSource = patient.Measurements;            
        }
    }
}
