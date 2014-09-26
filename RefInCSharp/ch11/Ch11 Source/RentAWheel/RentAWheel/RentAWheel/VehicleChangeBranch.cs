using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RentAWheel.Business;
using RentAWheel.Data.Implementation;

namespace RentAWheel
{
    public partial class VehicleChangeBranch : Form
    {
        private VehicleData vehicleData = new VehicleData();
        private BranchData branchData = new BranchData();

        private IList<Branch> branches;

        private Vehicle vehicle;

        public Vehicle Vehicle
        {
            get { return vehicle; }
            set { vehicle = value; }
        }

        public VehicleChangeBranch()
        {
            InitializeComponent();
        }

        private void LoadBranchCombo()
        {
            this.branches = branchData.GetAll();
            branch.DataSource = branches;
            branch.DisplayMember = "Name";
            branch.ValueMember = "Id";            
        }

        private void changeBranch_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm",
            MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                ChangeBranch();
                this.Close();
            }
        }

        private void ChangeBranch() {
            vehicle.Branch = (Branch)branch.SelectedItem;
            vehicleData.Update(vehicle);
        }

        private void VehicleChangeBranch_Shown(object sender, EventArgs e)
        {
            LoadBranchCombo();
            this.licensePlate.Text = vehicle.LicensePlate;
            this.currentBranch.Text = vehicle.Branch.Name;
        }
    }
}
