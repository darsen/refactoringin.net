using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class FleetMaintenance : Form
    {
        private const String connectionString = "Data Source=TESLATEAM;" +
        "Initial Catalog=RENTAWHEELS;" +
        "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123";

        private const string selectAllFromBranchSql = "Select * from Branch";
        private const string selectAllFromModelSql = "Select * from Model";
        private const string deleteVehicleSql = "Delete From Vehicle Where LicensePlate = @LicensePlate";
        private const string insertVehicleSql = "Insert Into Vehicle (LicensePlate, ModelId,BranchId) Values(@LicensePlate, @ModelId, @BranchId)";

        private const string licensePlateParameterName = "@LicensePlate";
        private const string modelIdParameterName = "@ModelId";
        private const string branchIdParameterName = "@BranchId";


        private const string vehicleTableLicensePlateColumnName = "LicensePlate";
        private const string branchTableNameColumnName = "BranchName";
        private const string modelTableNameColumnName = "ModelName";
        private const string selectVehicleJoinBranchJoinModelSql = "Select Vehicle.LicensePlate AS LicensePlate, Branch.Name as BranchName, Model.Name as ModelName from Vehicle Inner Join Branch On Vehicle.BranchId = Branch.BranchId Inner Join Model On Vehicle.ModelId = Model.ModelId";

        private const int singleTableInDatasetIndex = 0;

        
        private Hashtable branchIdFromName;        
        private Hashtable modelIdFromName;        
        private DataTable vehicles;        
        private int currentRowIndex;

        public FleetMaintenance()
        {
            InitializeComponent();
        }

        private void FleetMaintenance_Load(object sender, EventArgs e)
        {
            LoadBranchCombo();
            LoadModelCombo();
            LoadVehiclesTable();
        }

        private void LoadVehiclesTable()
        {
            IDbCommand vehiclesCommand = new SqlCommand();
            DataSet vehicles = FillDataset(vehiclesCommand, 
                selectVehicleJoinBranchJoinModelSql);
            this.vehicles = vehicles.Tables[singleTableInDatasetIndex];
            if ((this.vehicles.Rows.Count > 0))
            {
                currentRowIndex = 0;
                DisplayCurrentRow();
            }
        }

        private void LoadModelCombo()
        {
            IDbConnection connection = null;
            IDataReader modelReader = ExecuteReader(out connection, selectAllFromModelSql);
            modelIdFromName = new Hashtable();
            FillCombo(modelReader, model, modelIdFromName);
            modelReader.Close();
            connection.Close();
        }

        private void LoadBranchCombo()
        {
            IDbConnection connection = null;
            IDataReader branchReader = ExecuteReader(out connection, selectAllFromBranchSql);
            branchIdFromName = new Hashtable();
            FillCombo(branchReader,branch,branchIdFromName);
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

        private void right_Click(object sender, EventArgs e)
        {
            if (vehicles.Rows.Count > currentRowIndex + 1)
            {
                currentRowIndex++;
                DisplayCurrentRow();
            }
        }

        private void left_Click(object sender, EventArgs e)
        {
            if (currentRowIndex - 1 >= 0 & vehicles.Rows.Count > 0)
            {
                currentRowIndex--;
                DisplayCurrentRow();
            }
        }

        private void first_Click(object sender, EventArgs e)
        {
            if (vehicles.Rows.Count > 0)
            {
                currentRowIndex = 0;
                DisplayCurrentRow();
            }
        }

        private void last_Click(object sender, EventArgs e)
        {
            if (vehicles.Rows.Count > 0)
            {
                currentRowIndex = vehicles.Rows.Count - 1;
                DisplayCurrentRow();
            }
        }

        private void DisplayCurrentRow()
        {
            DataRow row = vehicles.Rows[currentRowIndex];
            licensePlate.Text = row["LicensePlate"].ToString();
            branch.Text = row["BranchName"].ToString();
            model.Text = row["ModelName"].ToString();
        }

        private void new_Click(object sender, EventArgs e)
        {
            licensePlate.Text = String.Empty;
            branch.Text = String.Empty;
            model.Text = String.Empty;
        }

        private void save_Click(object sender, EventArgs e)
        {
            InsertOrUpdateVehicle();                                          
            FleetMaintenance_Load(null, null);
        }

        private void InsertOrUpdateVehicle()
        {            
            IDbConnection connection = new SqlConnection(connectionString);
            IDbCommand deleteCommand = new SqlCommand();
            IDbCommand insertCommand = new SqlCommand();
            AddParameter(deleteCommand, licensePlateParameterName, 
                DbType.String, this.licensePlate.Text);
            AddParameter(insertCommand, licensePlateParameterName, 
                DbType.String, this.licensePlate.Text);
            AddParameter(insertCommand, modelIdParameterName, 
                DbType.Int32, modelIdFromName[model.Text]);
            AddParameter(insertCommand, branchIdParameterName, 
                DbType.Int32, branchIdFromName[branch.Text]);
            connection.Open();
            IDbTransaction transaction = connection.BeginTransaction();
            deleteCommand.Transaction = transaction;
            insertCommand.Transaction = transaction;
            ExecuteNonQueryTransactional(connection, deleteCommand, deleteVehicleSql);
            ExecuteNonQueryTransactional(connection, insertCommand, insertVehicleSql);
            transaction.Commit();
            connection.Close();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DeleteVehicle();
            FleetMaintenance_Load(null, null);
        }

        private void DeleteVehicle()
        {
            IDbCommand command = new SqlCommand();
            AddParameter(command, licensePlateParameterName, 
                DbType.String, this.licensePlate.Text);
            ExecuteNonQuery(command, deleteVehicleSql);
        }

        private void reload_Click(object sender, EventArgs e)
        {
            FleetMaintenance_Load(null, null);
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

        private IDataReader ExecuteReader(out IDbConnection connection, string sql)
        {
            IDbCommand command = new SqlCommand();
            connection = PrepareDataObjects(command, sql);
            return command.ExecuteReader();
        }

        public void ExecuteNonQuery(IDbCommand command, string sql)
        {
            IDbConnection connection = PrepareDataObjects(command, sql);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void ExecuteNonQueryTransactional(IDbConnection connection, 
            IDbCommand command, string sql)
        {
            connection = PrepareDataObjectsTransactional(connection, command, sql);
            command.ExecuteNonQuery();
        }

        private IDbConnection PrepareDataObjectsTransactional(IDbConnection connection, 
            IDbCommand command, string sql)
        {
            command.Connection = connection;
            command.CommandText = sql;
            return connection;
        }

    }
}

