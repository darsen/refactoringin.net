using System;
using System.Windows.Forms;
using RentAWheel.Business;
using RentAWheel.Data.Implementation;

namespace RentAWheel
{
    public partial class VehicleReception : Form
    {
        private VehicleData vehicleData;

        public VehicleData VehicleData
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


        private const String connectionString = "Data Source=TESLATEAM;" +
        "Initial Catalog=RENTAWHEELS;" +
        "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123";
        
        private const string receiveVehicleSql = "Update Vehicle Set Available = 3,Mileage = @Mileage, Tank = @Tank WHERE LicensePlate = @SelectedLP";

        private const string mileageParameterName = "@Mileage";
        private const string tankParameterName = "@Tank";
        private const string selectedLicesePlateParameter = "@SelectedLP";

        public VehicleReception()
        {
            InitializeComponent();
            BindTankLevelCombo();
        }

        private void BindTankLevelCombo()
        {
            tank.DataSource = Enum.GetValues(typeof(TankLevel));
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void receive_Click(object sender, EventArgs e)
        {
            if (UserConfirms())
            {
                ReceiveVehicle();
                this.Close();
            }            
        }

        private void ReceiveVehicle() {

            this.Vehicle.Mileage = Convert.ToInt32(this.mileage.Text);
            this.Vehicle.TankLevel = (TankLevel)this.tank.SelectedItem;
            this.Vehicle.Receive();
            VehicleData.Update(this.Vehicle);
        }

        
        private void VehicleReception_Shown(object sender, EventArgs e)
        {               
            mileage.Text = String.Empty;
            tank.Text = String.Empty;
            licensePlate.Text = vehicle.LicensePlate;
        }

        private bool UserConfirms()
        {
            return MessageBox.Show("Are you sure?", "Confirm",
                MessageBoxButtons.OKCancel) == DialogResult.OK;
        }
    }
}
