using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class FleetView : Form
    {
        private const String connectionString = "Data Source=TESLATEAM;" +
        "Initial Catalog=RENTAWHEELS;" +
        "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123";

        private readonly string selectAllFromCategoryAndBranchSql = "Select * from Category " + Environment.NewLine + "Select * from Branch";
        private const string selectAllFromBranchSql = "Select * from Branch";
        private const string selectAllFromCategorySql = "Select * from Category";
        private const string handOverVehicleSql = "Update Vehicle Set Available = 2 WHERE LicensePlate = @SelectedLP";
        private const string chargeVehicleSql = "Update Vehicle " + "Set Available = 0, " + "Mileage = 0," + "Tank = 0, " + "CustomerFirstName = ''," + "CustomerLastName = ''," + "CustomerDocNumber = ''," + "CustomerDocType = '' " + "WHERE LicensePlate = @SelectedLP";

        private const string vehicleToMaintenanceSql = "Update Vehicle " + "Set Operational = 1 " + "WHERE LicensePlate = @SelectedLP";

        private const string vehicleFromMaintenanceSql = "Update Vehicle " + "Set Operational = 0 " + "WHERE LicensePlate = @SelectedLP";
        
        private const string selectedLicensePlateParameterName = "@SelectedLP";
        private const string availableParameterName = "@Available";
        private const string branchIdParameterName = "@BranchId";
        private const string categoryIdParameterName = "@CategoryId";
        private const string operationalParameterName = "@Operational";

        private const string licencePlateColumn = "LicensePlate";
        private const string categoryNameColumn = "CategoryName";
        private const string availableColumn = "Available";
        private const string operationalColumn = "Operational";
        private const string modelNameColumn = "ModelName";
        private const string branchNameColumn = "BranchName";
        private const string dailyPriceColumn = "DailyPrice";
        private const string weeklyPriceColumn = "WeeklyPrice";
        private const string monthlyPriceColumn = "MonthlyPrice";
        private const string mileageColumn = "Mileage";
        private const string tankColumn = "Tank";
        private const string firstNameColumn = "FirstName";
        private const string lastNameColumn = "LastName";
        private const string documentNumberColumn = "DocNumber";
        private const string documentTypeColumn = "DocType";

        BranchMaintenance branchMaintenance = new BranchMaintenance();
        VehicleCategoriesMaintenance categoryMaintenance = new VehicleCategoriesMaintenance();
        ModelMaintenance modelMaintenance = new ModelMaintenance();
        FleetMaintenance fleetMaintenance = new FleetMaintenance();
        VehicleRental vehicleRental = new VehicleRental();
        VehicleReception vehicleReception = new VehicleReception();
        VehicleChangeBranch changeBranchForm = new VehicleChangeBranch();
        
        Hashtable branchIdFromName;        
        Hashtable categoryIdFromName;

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
            IDbConnection connection = null;
            IDataReader branchReader = ExecuteReader(out connection, selectAllFromBranchSql);
            branchIdFromName = new Hashtable();
            FillCombo(branchReader, cboBranch, branchIdFromName);
            branchReader.Close();
            connection.Close();
        }

        private void LoadCategoryCombo()
        {
            IDbConnection connection = null;
            IDataReader branchReader = ExecuteReader(out connection, selectAllFromCategorySql);
            this.categoryIdFromName = new Hashtable();
            FillCombo(branchReader, cboCategory, this.categoryIdFromName);
            branchReader.Close();
            connection.Close();
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
                changeBranchForm.licensePlate.Text = SelectedLicensePlate();
                string currentBranch = 
                fleetViewGrid.SelectedRows[0].
                Cells[5].Value.ToString();                        
                changeBranchForm.currentBranch.Text = currentBranch;
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
                vehicleRental.licensePlate.Text = SelectedLicensePlate();                                    
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
            string selectVehiclesByCriteria = null;
            IDbCommand command = new SqlCommand();
            ConstructDisplaySqlAndCommand(ref selectVehiclesByCriteria, ref command);

            IDbConnection connection = null;
            IDataReader reader = ExecuteReader(ref connection, command, selectVehiclesByCriteria);
            fillGrid(reader);
            reader.Close();
            connection.Close();

        }
        
        private void ConstructDisplaySqlAndCommand(ref string selectVehiclesByCriteria, 
            ref IDbCommand command)
        {
            selectVehiclesByCriteria = "Select Vehicle.LicensePlate as LicensePlate," + 
                "Category.Name as CategoryName," + 
                "Vehicle.Available as Available," + 
                "Vehicle.Operational as Operational," + 
                "Model.Name as ModelName," + 
                "Branch.Name as BranchName," + 
                "Category.DailyPrice as DailyPrice," + 
                "Category.WeeklyPrice as WeeklyPrice," + 
                "Category.MonthlyPrice as MonthlyPrice," + 
                "Vehicle.Mileage as Mileage," + 
                "Vehicle.Tank as Tank," + 
                "Vehicle.CustomerFirstName as FirstName," + 
                "Vehicle.CustomerLastName as LastName," + 
                "Vehicle.CustomerDocNumber as DocNumber," + 
                "Vehicle.CustomerDocType as DocType " + 
                "from Vehicle " + "Inner Join Model ON " + 
                "Vehicle.ModelId = Model.ModelId " + 
                "Inner Join Branch ON " + 
                "Vehicle.BranchId = Branch.BranchId " + 
                "Inner Join Category ON " + 
                "Model.CategoryId = Category.CategoryId";

            if ((cboAvailable.Text != "All" | 
                cboBranch.Text != "All" | 
                cboCategory.Text != "All" | 
                cboOperational.Text != "All"))
            {
                selectVehiclesByCriteria += " Where ";
                if ((cboAvailable.Text != "All"))
                {
                    selectVehiclesByCriteria += "Vehicle.Available = @Available And ";
                    int available = availableValue();
                    AddParameter(command, availableParameterName, 
                        DbType.Int32, available);
                }
                if (cboBranch.Text != "All")
                {
                    selectVehiclesByCriteria += "Vehicle.BranchId = @BranchId And ";
                    AddParameter(command, branchIdParameterName, 
                        DbType.String, this.branchIdFromName[cboBranch.Text]);
                }
                if (cboCategory.Text != "All")
                {
                    selectVehiclesByCriteria += "Model.CategoryId = @CategoryId And ";
                    AddParameter(command, categoryIdParameterName, 
                        DbType.Int32, Convert.ToInt32(this.categoryIdFromName[cboCategory.Text]));
                }
                if (cboOperational.Text != "All")
                {
                    selectVehiclesByCriteria += "Vehicle.Operational = @Operational And ";
                    AddParameter(command, operationalParameterName, 
                        DbType.Int32, operationalValue());
                }
                selectVehiclesByCriteria = RemoveTrailing_AND_(selectVehiclesByCriteria);
            }
        }

        private void fillGrid(IDataReader reader)
        {
            while (reader.Read())
            {
                string[] row = { reader[licencePlateColumn].ToString(), 
                                   reader[categoryNameColumn].ToString(), 
                                   availableText(Convert.ToInt32(reader[availableColumn])), 
                                   Convert.ToInt32(reader[operationalColumn]) == 0 ? "In Operation" : "In Maintenance", 
                                   reader[modelNameColumn].ToString(), 
                                   reader[branchNameColumn].ToString(), 
                                   reader[dailyPriceColumn].ToString(), 
                                   reader[weeklyPriceColumn].ToString(), 
                                   reader[monthlyPriceColumn].ToString(), 
                                   DBNull.Value.Equals(reader[mileageColumn]) ? " " : reader[mileageColumn].ToString(), 
                                   DBNull.Value.Equals(reader[tankColumn]) ? " " : reader[tankColumn].ToString(), 
                                   DBNull.Value.Equals(reader[firstNameColumn]) ? " " : reader[firstNameColumn].ToString(), 
                                   DBNull.Value.Equals(reader[lastNameColumn]) ? " " : reader[lastNameColumn].ToString(), 
                                   DBNull.Value.Equals(reader[documentNumberColumn]) ? " " : reader[documentNumberColumn].ToString(), 
                                   DBNull.Value.Equals(reader[documentTypeColumn]) ? " " : reader[documentTypeColumn].ToString() 
                               };
                this.fleetViewGrid.Rows.Add(row);
            }
        }


        private static string RemoveTrailing_AND_(string sql)
        {
            return sql.Substring(0, sql.Length - 5);
        }

        private int operationalValue()
        {
            int operational = 0;
            switch (cboOperational.Text)
            {
                case "In Operation":
                    operational = 0;
                    break;
                case "In Maintenance":
                    operational = 1;
                    break;
            }
            return operational;
        }

        private string availableText(int available)
        {
            string availableString = String.Empty;
            switch (available)
            {
                case 0:
                    availableString = "Available";
                    break;
                case 1:
                    availableString = "Hand Over";
                    break;
                case 2:
                    availableString = "Rented";
                    break;
                case 3:
                    availableString = "Charge";
                    break;
            }
            return availableString;
        }

        private int availableValue()
        {
            int available = 0;
            switch (cboAvailable.Text)
            {
                case availableColumn:
                    available = 0;
                    break;
                case "Hand Over":
                    available = 1;
                    break;
                case "Rented":
                    available = 2;
                    break;
                case "Charge":
                    available = 3;
                    break;
            }
            return available;
        }

        private void gridFleetView_SelectionChanged(object sender, EventArgs e)
        {
            if (fleetViewGrid.RowCount > 0 & fleetViewGrid.SelectedRows.Count > 0 &
                fleetViewGrid.Rows[0].Cells[0].Value != null)
            {
                string selectedAvailable =
                fleetViewGrid.SelectedRows[0].Cells[2].Value.ToString();
                switch (selectedAvailable)
                {
                    case "Available":
                        rent.Enabled = true;
                        handOver.Enabled = false;
                        receive.Enabled = false;
                        charge.Enabled = false;
                        break;
                    case "Hand Over":
                        rent.Enabled = false;
                        handOver.Enabled = true;
                        receive.Enabled = false;
                        charge.Enabled = false;
                        break;
                    case "Rented":
                        rent.Enabled = false;
                        handOver.Enabled = false;
                        receive.Enabled = true;
                        charge.Enabled = false;
                        break;
                    case "Charge":
                        rent.Enabled = false;
                        handOver.Enabled = false;
                        receive.Enabled = false;
                        charge.Enabled = true;
                        break;
                }
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
            IDbCommand command = new SqlCommand();
            AddParameter(command, selectedLicensePlateParameterName,
                DbType.String, SelectedLicensePlate());
            ExecuteNonQuery(command, handOverVehicleSql);
        }

        private void receive_Click(object sender, EventArgs e)
        {
            if (SelectionMade())
            {                
                vehicleReception.licensePlate.Text = SelectedLicensePlate();
                vehicleReception.ShowDialog();
            }
            else
            {
                AskUserToMakeSelection();
            }
            display_Click(null, null);
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
            IDbCommand command = new SqlCommand();
            AddParameter(command, selectedLicensePlateParameterName,
                DbType.String, SelectedLicensePlate());
            ExecuteNonQuery(command, chargeVehicleSql);
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
            IDbCommand command = new SqlCommand();
            AddParameter(command, selectedLicensePlateParameterName,
                DbType.String, SelectedLicensePlate());
            ExecuteNonQuery(command, vehicleToMaintenanceSql);
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
            IDbCommand command = new SqlCommand();
            AddParameter(command, selectedLicensePlateParameterName, 
                DbType.String, SelectedLicensePlate());
            ExecuteNonQuery(command, vehicleFromMaintenanceSql);
        }

        private bool UserConfirms()
        {
            return MessageBox.Show("Are you sure?", "Confirm",
                MessageBoxButtons.OKCancel) == DialogResult.OK;
        }

        private void AddParameter(IDbCommand command, string parameterName,
        DbType parameterType, object paramaterValue)
        {
            IDbDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.DbType = parameterType;
            parameter.Value = paramaterValue;
            command.Parameters.Add(parameter);
        }

        private IDbConnection PrepareDataObjects(IDbCommand command, string sql)
        {
            IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();
            command.Connection = connection;
            command.CommandText = sql;
            return connection;
        }

        private DataSet FillDataset(IDbCommand command, string sql)
        {
            IDbConnection connection = PrepareDataObjects(command, sql);
            IDbDataAdapter adapter = new SqlDataAdapter();
            DataSet branches = new DataSet();
            adapter.SelectCommand = command;
            adapter.Fill(branches);
            connection.Close();
            return branches;
        }

        public void ExecuteNonQuery(IDbCommand command, string sql)
        {
            IDbConnection connection = PrepareDataObjects(command, sql);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private IDataReader ExecuteReader(out IDbConnection connection, string sql)
        {
            IDbCommand command = new SqlCommand();
            connection = PrepareDataObjects(command, sql);
            return command.ExecuteReader();
        }

        private IDataReader ExecuteReader(ref IDbConnection connection, 
            IDbCommand command, string sql)
        {
            connection = PrepareDataObjects(command, sql);
            return command.ExecuteReader();
        }
    }
}
