using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class FleetMaintenance : Form
    {
        ModelData modelData = new ModelData();
        BranchData branchData = new BranchData();
        VehicleData data = new VehicleData();

        IList<Model> models;
        IList<Branch> branches;
        IList<Vehicle> vehicles;
             
        private bool isNewVehicle;        
        private int current;

        public FleetMaintenance()
        {
            InitializeComponent();
        }

        private void FleetMaintenance_Load(object sender, EventArgs e)
        {
            LoadBranchCombo();
            LoadModelCombo();
            LoadVehicles();
            BindTankLevelCombo();
            if (vehicles.Count > 0)
            {
                current = 0;
                DisplayCurrent();
            }
        }

        private void BindTankLevelCombo()
        {
            this.tankLevel.DataSource = Enum.GetValues(typeof(TankLevel));
        }    

        private void LoadVehicles()
        {
            vehicles = data.GetAll();
        }

        private void LoadModelCombo()
        {
            this.models = modelData.GetAll();
            model.DataSource = models;
            model.DisplayMember = "Name";
            model.ValueMember = "Id";
        }

        private void LoadBranchCombo()
        {
            this.branches = branchData.GetAll();
            branch.DataSource = branches;
            branch.DisplayMember = "Name";
            branch.ValueMember = "Id";
        }

        private void FillCombo(IDataReader reader, ComboBox combo, Hashtable nameIdRelation)
        {
            while (reader.Read())
            {
                combo.Items.Add(reader[1]);
                nameIdRelation.Add(reader[1], reader[0]);
            }
        }

        private void right_Click(object sender, EventArgs e)
        {
            if (vehicles.Count > current + 1)
            {
                current++;
                DisplayCurrent();
            }
        }

        private void left_Click(object sender, EventArgs e)
        {
            if (current - 1 >= 0 & vehicles.Count > 0)
            {
                current--;
                DisplayCurrent();
            }
        }

        private void first_Click(object sender, EventArgs e)
        {
            if (vehicles.Count > 0)
            {
                current = 0;
                DisplayCurrent();
            }
        }

        private void last_Click(object sender, EventArgs e)
        {
            if (vehicles.Count > 0)
            {
                current = vehicles.Count - 1;
                DisplayCurrent();
            }
        }

        private void DisplayCurrent()
        {
            Vehicle vehicle = vehicles[current];
            licensePlate.Text = vehicle.LicensePlate;
            branch.Text = vehicle.Branch.Name;
            model.Text = vehicle.Model.Name;
            mileage.Text = vehicle.Mileage.ToString();
            tankLevel.SelectedItem = vehicle.TankLevel;
            isNewVehicle = false;
            this.licensePlate.Enabled = false;
        }

        private void new_Click(object sender, EventArgs e)
        {
            licensePlate.Text = String.Empty;
            branch.Text = String.Empty;
            model.Text = String.Empty;
            mileage.Text = 0.ToString();
            tankLevel.SelectedItem = TankLevel.Full;
            isNewVehicle = true;
            this.licensePlate.Enabled = true;
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (isNewVehicle)
            {
                InsertVehicle();
            }
            else {
                UpdateVehicle();
            }
            FleetMaintenance_Load(null, null);
        }

        private void InsertVehicle()
        {
            Vehicle vehicle = new Vehicle(
                this.licensePlate.Text, 
                (Model)this.model.SelectedItem, 
                (Branch)this.branch.SelectedItem, 
                (TankLevel)this.tankLevel.SelectedItem, 
                Convert.ToInt32(this.mileage.Text),
                null);
            data.Insert(vehicle);
        }

        private void UpdateVehicle()
        {
            Vehicle vehicle = vehicles[current];
            vehicle.Model = (Model)this.model.SelectedItem;
            vehicle.Branch = (Branch)this.branch.SelectedItem;
            vehicle.TankLevel = (TankLevel)this.tankLevel.SelectedItem;
            vehicle.Mileage = Convert.ToInt32(this.mileage.Text);
            data.Update(vehicle);
        }


        private void delete_Click(object sender, EventArgs e)
        {
            data.Delete(vehicles[current]);
            FleetMaintenance_Load(null, null);
        }

        private void reload_Click(object sender, EventArgs e)
        {
            FleetMaintenance_Load(null, null);
        }
    }
}

