using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class BranchMaintenance : Form
    {
        private const String connectionString = "Data Source=TESLATEAM;" + 
            "Initial Catalog=RENTAWHEELS;" +              
            "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123";

        private const string branchTableIdColumnName = "BranchId";
        private const string branchTableNameColumnName = "Name";

        private const string selectAllFromBranchSql = 
            "Select * from Branch";
        private const string deleteBranchSql = 
            "Delete Branch Where BranchId = @Id";
        private const string insertBranchSql = 
            "Insert Into Branch (Name) Values(@Name)";
        private const string updateBranchSql = 
            "Update Branch  Set Name = @Name Where BranchId = @Id";

        private const string idParameterName = "@Id";
        private const string nameParameterName = "@Name";

        private const int singleTableInDatasetIndex = 0;

        private DataTable branches;
        private int currentRowIndex;

        public BranchMaintenance()
        {
            InitializeComponent();
        }

        private void new_Click(object sender, EventArgs e)
        {
            id.Text = String.Empty;
            name.Text = String.Empty;
        }

        private void BranchMaintenance_Load(object sender, EventArgs e)
        {
            LoadBranches();
            if ((this.branches.Rows.Count > 0))
            {
                currentRowIndex = 0;
                DisplayCurrentRow();
            }
        }

        private void LoadBranches()
        {
            IDbCommand command = new SqlCommand();
            DataSet branches = FillDataset(command, selectAllFromBranchSql);
            this.branches = branches.Tables[singleTableInDatasetIndex];
        }

        private void right_Click(object sender, EventArgs e)
        {
            if (branches.Rows.Count > currentRowIndex + 1)
            {
                currentRowIndex++;
                DisplayCurrentRow();
            }
        }

        private void left_Click(object sender, EventArgs e)
        {
            if (currentRowIndex - 1 >= 0 & branches.Rows.Count > 0)
            {
                currentRowIndex--;
                DisplayCurrentRow();
            }
        }

        private void first_Click(object sender, EventArgs e)
        {
            if (branches.Rows.Count > 0)
            {
                currentRowIndex = 0;
                DisplayCurrentRow();
            }
        }

        private void last_Click(object sender, EventArgs e)
        {
            if (branches.Rows.Count > 0)
            {
                currentRowIndex = branches.Rows.Count - 1;
                DisplayCurrentRow();
            }
        }

        private void DisplayCurrentRow()
        {
            DataRow row = branches.Rows[currentRowIndex];
            id.Text = row["BranchId"].ToString();
            name.Text = row["Name"].ToString();
        }

        private void save_Click(object sender, EventArgs e)
        {
            SaveBranch();           
            BranchMaintenance_Load(null, null);
        }

        private void SaveBranch()
        {
            IDbCommand command = new SqlCommand();
            if (String.IsNullOrEmpty(id.Text))
            {
                AddParameter(command, nameParameterName, 
                    DbType.String, name.Text.ToString());
                ExecuteNonQuery(command, insertBranchSql);
            }
            else
            {
                AddParameter(command, nameParameterName, 
                    DbType.String, name.Text.ToString());
                AddParameter(command, idParameterName, 
                    DbType.Int32, Convert.ToInt32(this.id.Text));
                ExecuteNonQuery(command, updateBranchSql);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DeleteBranch();
            BranchMaintenance_Load(null, null);
        }

        private void DeleteBranch() {
            IDbCommand command = new SqlCommand();
            AddParameter(command, idParameterName, 
                DbType.Int32, Convert.ToInt32(this.id.Text));
            ExecuteNonQuery(command, deleteBranchSql);
        }

        private void reload_Click(object sender, EventArgs e)
        {
            BranchMaintenance_Load(null, null);
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
    }
}

