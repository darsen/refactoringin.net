using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class FleetView : Form
    {
        private BranchData branchData = new BranchData();
        private CategoryData categoryData = new CategoryData();
        private VehicleData vehicleData = new VehicleData();

        private IList<Branch> branches;
        private IList<Category> categories;
        private IList<Vehicle> vehicles;
      
        BranchMaintenance branchMaintenance = new BranchMaintenance();
        VehicleCategoriesMaintenance categoryMaintenance = new VehicleCategoriesMaintenance();
        ModelMaintenance modelMaintenance = new ModelMaintenance();
        FleetMaintenance fleetMaintenance = new FleetMaintenance();
        VehicleRental vehicleRental = new VehicleRental();
        VehicleReception vehicleReception = new VehicleReception();
        VehicleChangeBranch changeBranchForm = new VehicleChangeBranch();
        
        private static void AskUserToMakeSelection()
        {
            MessageBox.Show("Please select vehicle first!");
        }

        public FleetView()
        {
            InitializeComponent();
        }

        private void branchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            branchMaintenance.ShowDialog();
        }

        private void FleetView_Load(object sender, EventArgs e)
        {            
            LoadBranchCombo();
            LoadCategoryCombo();            
        }

        private void LoadBranchCombo()
        {
            this.branches = branchData.GetAll();
            cboBranch.DataSource = branches;
            cboBranch.DisplayMember = "Name";
            cboBranch.ValueMember = "Id";
            cboBranch.Text = "All";
        }

        private void LoadCategoryCombo()
        {
            this.categories = categoryData.GetAll();
            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
            cboCategory.Text = "All";
        }

        private void FillCombo(IDataReader reader, ComboBox combo, Hashtable nameIdRelation)
        {
            while (reader.Read())
            {
                combo.Items.Add(reader[1]);
                nameIdRelation.Add(reader[1], reader[0]);
            }
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            categoryMaintenance.ShowDialog();
        }

        private void modelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modelMaintenance.ShowDialog();
        }

        private void fleetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fleetMaintenance.ShowDialog();
        }

        private void changeBranch_Click(object sender, EventArgs e)
        {
            if (SelectionMade())
            {
                changeBranchForm.Vehicle = Selected;
                changeBranchForm.ShowDialog();
            }
            else
            {
                AskUserToMakeSelection();
            }
            display_Click(null, null);
        }

        private bool SelectionMade()
        {
            return fleetViewGrid.SelectedRows.Count > 0;
        }

        private void rent_Click(object sender, EventArgs e)
        {            
            if (SelectionMade())
            {
                vehicleRental.Vehicle = Selected;
                vehicleRental.ShowDialog();
            }
            else
            {
                AskUserToMakeSelection();
            }
            display_Click(null, null);
        }

        private void display_Click(object sender, EventArgs e)
        {
            this.fleetViewGrid.Rows.Clear();
            this.vehicles = vehicleData.GetByCriteria(
                this.cboOperational.Text.Equals("All") ? null : (Nullable<Operational>)this.cboOperational.SelectedItem,
                this.cboAvailable.Text.Equals("All") ? null : (Nullable<RentalState>)this.cboAvailable.SelectedItem,
                (this.cboBranch.Text.Equals("All") ? null : (Nullable <Int32>)(this.cboBranch.SelectedValue)),
                (this.cboCategory.Text.Equals("All") ? null : (Nullable<Int32>)(this.cboCategory.SelectedValue)));
            
            this.fleetViewGrid.Rows.Clear();
            FillGrid();
        }

        private void FillGrid()
        {
            foreach (Vehicle vehicle in vehicles)
            {
                string firstName = string.Empty;
                string lastName = string.Empty;
                string docNumber = string.Empty;
                string docType = string.Empty;
                if ((vehicle.Customer != null))
                {
                    firstName = vehicle.Customer.FirstName;
                    lastName = vehicle.Customer.LastName;
                    docNumber = vehicle.Customer.DocNumber;
                    docType = vehicle.Customer.DocType;
                }
                string[] row = {   
                                   vehicle.LicensePlate, 
                                   vehicle.Model.Category.Name,                                    
                                   vehicle.RentalState.ToString(), 
                                   vehicle.Operational.ToString(), 
                                   vehicle.Model.Name, 
                                   vehicle.Branch.Name, 
                                   vehicle.Model.Category.DailyPrice.ToString(), 
                                   vehicle.Model.Category.WeeklyPrice.ToString(), 
                                   vehicle.Model.Category.MonthlyPrice.ToString(), 
                                   vehicle.Mileage.ToString(), 
                                   vehicle.TankLevel.ToString(), 
                                   firstName, 
                                   lastName, 
                                   docNumber, 
                                   docType 
                               };
                this.fleetViewGrid.Rows.Add(row);
            }
        }
           
        private static string RemoveTrailing_AND_(string sql)
        {
            return sql.Substring(0, sql.Length - 5);
        }

        private void gridFleetView_SelectionChanged(object sender, EventArgs e)
        {
            if (fleetViewGrid.RowCount > 0 & fleetViewGrid.SelectedRows.Count > 0 &
                fleetViewGrid.Rows[0].Cells[0].Value != null)
            {
                EnableAndDisableButtons();
            }
        }

        private void EnableAndDisableButtons()
        {
            switch (Selected.RentalState)
            {
                case RentalState.Available:
                    rent.Enabled = true;
                    handOver.Enabled = false;
                    receive.Enabled = false;
                    charge.Enabled = false;
                    break;
                case RentalState.Rented:
                    rent.Enabled = false;
                    handOver.Enabled = true;
                    receive.Enabled = false;
                    charge.Enabled = false;
                    break;
                case RentalState.HandedOver:
                    rent.Enabled = false;
                    handOver.Enabled = false;
                    receive.Enabled = true;
                    charge.Enabled = false;
                    break;
                case RentalState.PaymentPending:
                    rent.Enabled = false;
                    handOver.Enabled = false;
                    receive.Enabled = false;
                    charge.Enabled = true;
                    break;
            }

            switch (Selected.Operational)
            {
                case Operational.InMaintenence:
                    toMaintenance.Enabled = false;
                    fromMaintenance.Enabled = true;
                    break;
                case Operational.InOperation:
                    toMaintenance.Enabled = true;
                    fromMaintenance.Enabled = false;
                    break;
            }

        }

        private void handOver_Click(object sender, EventArgs e)
        {
            if (!SelectionMade())
            {
                AskUserToMakeSelection();
                return;
            }
            if (!UserConfirms())
            {
                return;
            }
            HandOverVehicle();
            display_Click(null, null);
        }

        private void HandOverVehicle()
        {
            Selected.HandOver();
            vehicleData.Update(Selected);
        }

        private void receive_Click(object sender, EventArgs e)
        {
            if (SelectionMade())
            {                
                vehicleReception.Vehicle = Selected;
                vehicleReception.ShowDialog();
            }
            else
            {
                AskUserToMakeSelection();
            }
            display_Click(null, null);
        }

        public Vehicle Selected {
            get {
                Vehicle vehicle = null;
                foreach (Vehicle selected in vehicles)
                {
                    if (selected.LicensePlate.Equals(SelectedLicensePlate()))
                    {
                        vehicle = selected;
                    }
                }
                return vehicle;
            }        
        }

        private string SelectedLicensePlate()
        {
            return fleetViewGrid.SelectedRows[0].
                            Cells[0].Value.ToString();
        }

        private void charge_Click(object sender, EventArgs e)
        {
            if (!SelectionMade())
            {
                AskUserToMakeSelection();
                return;
            }
            if (!UserConfirms())
            {
                return;
            }
            ChargeVehicle();
            display_Click(null, null);
        }

        private void ChargeVehicle()
        {             
            Selected.Charge();
            vehicleData.Update(Selected);
        }

        private void toMaintenance_Click(object sender, EventArgs e)
        {
            if (!SelectionMade())
            {
                AskUserToMakeSelection();
                return;
            }
            if (!UserConfirms())
            {
                return;
            }
            VehicleToMaintenance();          
            display_Click(null, null);
        }

        private void VehicleToMaintenance()
        {
            Selected.ToMaintenence();
            vehicleData.Update(Selected);
        }

        private void fromMaintenance_Click(object sender, EventArgs e)
        {
            if (!SelectionMade())
            {
                AskUserToMakeSelection();
                return;
            }
            if (!UserConfirms())
            {
                return;
            }
            VehicleFromMaintenance();
            display_Click(null, null); 
        }

        private void VehicleFromMaintenance()
        {
            Selected.FromMaintenence();
            vehicleData.Update(Selected);
        }

        private bool UserConfirms()
        {
            return MessageBox.Show("Are you sure?", "Confirm",
                MessageBoxButtons.OKCancel) == DialogResult.OK;
        }
    }
}
