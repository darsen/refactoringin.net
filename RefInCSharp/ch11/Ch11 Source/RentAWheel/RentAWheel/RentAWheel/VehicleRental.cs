using System;
using System.Windows.Forms;
using RentAWheel.Business;
using RentAWheel.Data.Implementation;

namespace RentAWheel
{
    public partial class VehicleRental : Form
    {
        private VehicleData data = new VehicleData();

        private Vehicle vehicle;

        public Vehicle Vehicle
        {
            get { return vehicle; }
            set { vehicle = value; }
        }
            
        public VehicleRental()
        {
            InitializeComponent();
        }

        private void rent_Click(object sender, EventArgs e)
        {
            if (UserConfirms())
            {
                RentVehicle();
                this.Close();
            }
        }
        
        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RentVehicle()
        {
            this.Vehicle.Customer = new Customer();
            this.Vehicle.Customer.FirstName = this.firstName.Text;
            this.Vehicle.Customer.LastName = this.lastName.Text;
            this.Vehicle.Customer.DocNumber = this.documentNumber.Text;
            this.Vehicle.Customer.DocType = this.documentType.Text;
            this.Vehicle.Rent();
            data.Update(this.Vehicle);
        }

       
        private void VehicleRental_Shown(object sender, EventArgs e)
        {
            this.licensePlate.Text = vehicle.LicensePlate;
            firstName.Text = String.Empty;
            lastName.Text = String.Empty;
            documentNumber.Text = String.Empty;
            documentType.Text = String.Empty;
        }

        private bool UserConfirms()
        {
            return MessageBox.Show("Are you sure?", "Confirm",
                MessageBoxButtons.OKCancel) == DialogResult.OK;
        }    
    }
}
