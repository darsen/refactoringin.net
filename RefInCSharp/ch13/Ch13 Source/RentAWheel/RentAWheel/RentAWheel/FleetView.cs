using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RentAWheel.Business;
using RentAWheel.Data;
using RentAWheel.Data.Implementation;

namespace RentAWheel
{
    public partial class FleetView : Form
    {
        private LinqData<Branch> branchData;
    
        public LinqData<Branch> BranchData
        {
            get { return branchData; }
            set { branchData = value; }
        }
        private LinqData<Category> categoryData;

        public LinqData<Category> CategoryData
        {
            get { return categoryData; }
            set { categoryData = value; }
        }
        private LinqData<Vehicle> vehicleData;

        public LinqData<Vehicle> VehicleData
        {
            get { return vehicleData; }
            set { vehicleData = value; }
        }

        private IList<Branch> branches;
        private IList<Category> categories;
        private IList<Vehicle> vehicles;

        BranchMaintenance branchMaintenance;

        public BranchMaintenance BranchMaintenance
        {
            get { return branchMaintenance; }
            set { branchMaintenance = value; }
        }
        VehicleCategoriesMaintenance categoryMaintenance;

        public VehicleCategoriesMaintenance CategoryMaintenance
        {
            get { return categoryMaintenance; }
            set { categoryMaintenance = value; }
        }
        ModelMaintenance modelMaintenance;

        public ModelMaintenance ModelMaintenance
        {
            get { return modelMaintenance; }
            set { modelMaintenance = value; }
        }
        FleetMaintenance fleetMaintenance;

        public FleetMaintenance FleetMaintenance
        {
            get { return fleetMaintenance; }
            set { fleetMaintenance = value; }
        }
        VehicleRental vehicleRental;

        public VehicleRental VehicleRental
        {
            get { return vehicleRental; }
            set { vehicleRental = value; }
        }
        VehicleReception vehicleReception;

        public VehicleReception VehicleReception
        {
            get { return vehicleReception; }
            set { vehicleReception = value; }
        }
        VehicleChangeBranch changeBranchForm;

        public VehicleChangeBranch ChangeBranchForm
        {
            get { return changeBranchForm; }
            set { changeBranchForm = value; }
        }
        
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
            BranchMaintenance.ShowDialog();
        }

        private void FleetView_Load(object sender, EventArgs e)
        {            
            LoadBranchCombo();
            LoadCategoryCombo();            
        }

        private void LoadBranchCombo()
        {
            this.branches = BranchData.GetAll();
            cboBranch.DataSource = branches;
            cboBranch.DisplayMember = "Name";
            cboBranch.ValueMember = "Id";
            cboBranch.Text = "All";
        }

        private void LoadCategoryCombo()
        {
            this.categories = CategoryData.GetAll();
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
            CategoryMaintenance.ShowDialog();
        }

        private void modelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelMaintenance.ShowDialog();
        }

        private void fleetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FleetMaintenance.ShowDialog();
        }

        private void changeBranch_Click(object sender, EventArgs e)
        {
            if (SelectionMade())
            {
                ChangeBranchForm.Vehicle = Selected;
                ChangeBranchForm.ShowDialog();
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
                VehicleRental.Vehicle = Selected;
                VehicleRental.ShowDialog();
            }
            else
            {
                AskUserToMakeSelection();
            }
            display_Click(null, null);
        }

        private void display_Click(object sender, EventArgs e)
        {
            Nullable<Operational> operational =
                this.cboOperational.Text.Equals("All") ? null :
                (Nullable<Operational>)this.cboOperational.SelectedItem;
            Nullable<RentalState> rentalState = 
                this.cboAvailable.Text.Equals("All") ? null : 
                (Nullable<RentalState>)this.cboAvailable.SelectedItem;
            Nullable<Int32> branchId = 
                this.cboBranch.Text.Equals("All") ? null : 
                (Nullable <Int32>)(this.cboBranch.SelectedValue);
            Nullable<Int32> categoryId = 
                this.cboCategory.Text.Equals("All") ? null : (Nullable<Int32>)(this.cboCategory.SelectedValue);

            var forDisplay = from resulting in vehicleData.Queryable 
                             where
                                    (resulting.Operational == operational || operational == null) &
                                    (resulting.RentalState == rentalState || rentalState == null  ) &
                                    (resulting.Branch.Id == branchId  || branchId == null ) &
                                    (resulting.Model.CategoryId == categoryId|| categoryId == null )                             
                                select resulting;

            this.vehicles = forDisplay.ToList<Vehicle>();
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
                                   System.Enum.GetName(RentalState.Available.GetType(), vehicle.RentalState),
                                   System.Enum.GetName(Operational.InOperation.GetType(), vehicle.Operational),
                                   vehicle.Model.Name, 
                                   vehicle.Branch.Name, 
                                   vehicle.Model.Category.DailyPrice.ToString(), 
                                   vehicle.Model.Category.WeeklyPrice.ToString(), 
                                   vehicle.Model.Category.MonthlyPrice.ToString(), 
                                   vehicle.Mileage.ToString(),                                    
                                   System.Enum.GetName(TankLevel.Empty.GetType(), vehicle.TankLevel),
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
            VehicleData.Update(Selected);
        }

        private void receive_Click(object sender, EventArgs e)
        {
            if (SelectionMade())
            {                
                VehicleReception.Vehicle = Selected;
                VehicleReception.ShowDialog();
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
            VehicleData.Update(Selected);
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
            VehicleData.Update(Selected);
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
            VehicleData.Update(Selected);
        }

        private bool UserConfirms()
        {
            return MessageBox.Show("Are you sure?", "Confirm",
                MessageBoxButtons.OKCancel) == DialogResult.OK;
        }
    }
}
