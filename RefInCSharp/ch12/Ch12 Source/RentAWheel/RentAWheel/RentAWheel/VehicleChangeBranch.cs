using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RentAWheel.Business;
using RentAWheel.Data.Implementation;

namespace RentAWheel
{
    public partial class VehicleChangeBranch : Form
    {
        private VehicleData vehicleData;

        public VehicleData VehicleData
        {
            get { return vehicleData; }
            set { vehicleData = value; }
        }
        private BranchData branchData;

        public BranchData BranchData
        {
            get { return branchData; }
            set { branchData = value; }
        }

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
            this.branches = BranchData.GetAll();
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
            VehicleData.Update(vehicle);
        }

        private void VehicleChangeBranch_Shown(object sender, EventArgs e)
        {
            LoadBranchCombo();
            this.licensePlate.Text = vehicle.LicensePlate;
            this.currentBranch.Text = vehicle.Branch.Name;
        }
    }
}
