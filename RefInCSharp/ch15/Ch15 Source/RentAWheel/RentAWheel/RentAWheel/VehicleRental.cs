using System;
using System.Windows.Forms;
using RentAWheel.Business;
using RentAWheel.Data.Implementation;
using RentAWheel.Data;

namespace RentAWheel
{
    public partial class VehicleRental : Form
    {
        private IData<Vehicle> vehicleData;

        public IData<Vehicle> VehicleData
        {
            get { return vehicleData; }
            set { vehicleData = value; }
        }

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
            SetExisitngCustomerProperties();                  
            Vehicle.Rent();
            VehicleData.Update(this.Vehicle);
        }


        private void SetExisitngCustomerProperties()
        {
            Vehicle.Customer.FirstName = this.firstName.Text;
            Vehicle.Customer.LastName = this.lastName.Text;
            Vehicle.Customer.DocNumber = this.documentNumber.Text;
            Vehicle.Customer.DocType = this.documentType.Text;
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
