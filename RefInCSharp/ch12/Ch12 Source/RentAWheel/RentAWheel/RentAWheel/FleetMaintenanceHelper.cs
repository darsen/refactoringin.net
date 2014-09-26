using System;
using System.Collections.Generic;
using RentAWheel.Business;
using RentAWheel.Data.Implementation;
using RentAWheel.GUI;

namespace RentAWheel
{
    class FleetMaintenanceHelper : MaintenanceFormAbstractHelper<Vehicle>
    {
        private bool isNewVehicle;

        VehicleData vehicleData;

        public VehicleData VehicleData
        {
            get { return vehicleData; }
            set { vehicleData = value; }
        }

        ModelData modelData;

        public ModelData ModelData
        {
            get { return modelData; }
            set { modelData = value; }
        }

        BranchData branchData;

        public BranchData BranchData
        {
            get { return branchData; }
            set { branchData = value; }
        }

        IList<Branch> branches;

        IList<Model> models;

        private FleetMaintenance form;

        public FleetMaintenance Form
        {
            get { return form; }
            set { form = value; }
        }

        private void LoadModelCombo()
        {
            this.models = ModelData.GetAll();
            Form.model.DataSource = models;
            Form.model.DisplayMember = "Name";
            Form.model.ValueMember = "Id";
        }

        private void LoadBranchCombo()
        {
            this.branches = BranchData.GetAll();
            Form.branch.DataSource = branches;
            Form.branch.DisplayMember = "Name";
            Form.branch.ValueMember = "Id";
        }

        private void BindTankLevelCombo()
        {
            Form.tankLevel.DataSource = Enum.GetValues(typeof(TankLevel));
        } 

        protected override void DisplayCurrent()
        {
            Vehicle vehicle = Current();
            Form.licensePlate.Text = vehicle.LicensePlate;
            Form.branch.Text = vehicle.Branch.Name;
            Form.model.Text = vehicle.Model.Name;
            Form.mileage.Text = vehicle.Mileage.ToString();
            Form.tankLevel.SelectedItem = vehicle.TankLevel;
            isNewVehicle = false;
            Form.licensePlate.Enabled = false;
        }

        protected override void CleanForm()
        {
            Form.licensePlate.Text = String.Empty;
            Form.branch.Text = String.Empty;
            Form.model.Text = String.Empty;
            Form.mileage.Text = 0.ToString();
            Form.tankLevel.SelectedItem = TankLevel.Full;
            isNewVehicle = true;
            Form.licensePlate.Enabled = true;
        }

        protected override void LoadMaintanied()
        {
            this.Maintained = VehicleData.GetAll();
            LoadModelCombo();
            LoadBranchCombo();
            BindTankLevelCombo();
        }

        protected override void DeleteMaintained()
        {
            VehicleData.Delete(Current());
        }

        protected override void SaveMaintained()
        {
            if (isNewVehicle)
            {
                Vehicle vehicle = new Vehicle(
                Form.licensePlate.Text,
                (Model)Form.model.SelectedItem,
                (Branch)Form.branch.SelectedItem,
                (TankLevel)Form.tankLevel.SelectedItem,
                Convert.ToInt32(Form.mileage.Text),
                null);
                VehicleData.Insert(vehicle);
            }
            else
            {
                Vehicle vehicle = Current();
                vehicle.Model = (Model)Form.model.SelectedItem;
                vehicle.Branch = (Branch)Form.branch.SelectedItem;
                vehicle.TankLevel = (TankLevel)Form.tankLevel.SelectedItem;
                vehicle.Mileage = Convert.ToInt32(Form.mileage.Text);
                VehicleData.Update(vehicle);
            }

        }      
    }
}
