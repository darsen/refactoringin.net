using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class VehicleChangeBranch : Form
    {
        private const String connectionString = "Data Source=TESLATEAM;" +
        "Initial Catalog=RENTAWHEELS;" +
        "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123";
        
        private const string selectAllFromBranchSql = "Select * from Branch";
        private const string updateVehicleSql = "Update Vehicle " + "Set BranchId = @BranchId WHERE LicensePlate = @SelectedLP";

        private const string branchIdParameterName = "@BranchId";
        private const string selectedLicensePlateParameterName = "@SelectedLP";
        private Hashtable branchIdFromName;

        public VehicleChangeBranch()
        {
            InitializeComponent();
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
            IDbCommand command = new SqlCommand();
            AddParameter(command, branchIdParameterName, DbType.Int32, 
                Convert.ToInt32(branchIdFromName[branch.Text]));
            AddParameter(command, selectedLicensePlateParameterName, 
                DbType.String, licensePlate.Text);
            ExecuteNonQuery(command, updateVehicleSql);
        }

        private void VehicleChangeBranch_Load(object sender, EventArgs e)
        {
            LoadBranchCombo();
        }

        private void LoadBranchCombo() {
            IDbConnection connection = null;
            IDataReader reader = ExecuteReader(out connection, selectAllFromBranchSql);
            branchIdFromName = new Hashtable();
            while (reader.Read())
            {
                branch.Items.Add(reader[1]);
                branchIdFromName.Add(reader[1], reader[0]);
            }
            branch.SelectedIndex = 0;
            reader.Close();
            connection.Close();
        
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
    }
}
