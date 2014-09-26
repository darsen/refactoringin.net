using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class BranchMaintenance : Form
    {
        private DataTable branches;
        private int currentRowIndex;

        public BranchMaintenance()
        {
            InitializeComponent();
        }

        private void new_Click(object sender, EventArgs e)
        {
            id.Text = "";
            name.Text = "";
        }

        private void BranchMaintenance_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(
                "Data Source=TESLATEAM;" +
                "Initial Catalog=RENTAWHEELS;" +
                "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand command = new SqlCommand();
            DataSet branchData = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            //Create Sql String 
            string sql = "Select * from Branch";
            try
            {
                connection.Open();
                //Set connection to command
                command.Connection = connection;
                //set Sql string to command object
                command.CommandText = sql;
                //execute command
                adapter.SelectCommand = command;
                //fill DataSet
                adapter.Fill(branchData);
                //close connection
                connection.Close();
                this.branches = branchData.Tables[0];
                if (branches.Rows.Count > 0)
                {
                    currentRowIndex = 0;
                    DataRow row = branches.Rows[currentRowIndex];
                    id.Text = row["BranchId"].ToString();
                    name.Text = row["Name"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("A problem occurred and the application cannot recover! " +
                "Please contact the technical support.");
            }
        }

        private void right_Click(object sender, EventArgs e)
        {
            if (branches.Rows.Count > currentRowIndex + 1)
            {
                currentRowIndex++;
                DataRow row = branches.Rows[currentRowIndex];
                id.Text = row["BranchId"].ToString();
                name.Text = row["Name"].ToString();
            }
        }

        private void left_Click(object sender, EventArgs e)
        {
            if (currentRowIndex - 1 >= 0 & branches.Rows.Count > 0)
            {
                currentRowIndex--;
                DataRow row = branches.Rows[currentRowIndex];
                id.Text = row["BranchId"].ToString();
                name.Text = row["Name"].ToString();
            }
        }

        private void first_Click(object sender, EventArgs e)
        {
            if (branches.Rows.Count > 0)
            {
                currentRowIndex = 0;
                DataRow row = branches.Rows[currentRowIndex];
                id.Text = row["BranchId"].ToString();
                name.Text = row["Name"].ToString();
            }
        }

        private void last_Click(object sender, EventArgs e)
        {
            if (branches.Rows.Count > 0)
            {
                currentRowIndex = branches.Rows.Count - 1;
                DataRow row = branches.Rows[currentRowIndex];
                id.Text = row["BranchId"].ToString();
                name.Text = row["Name"].ToString();
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            string sql;
            SqlConnection connection = new SqlConnection(
               "Data Source=TESLATEAM;" +
               "Initial Catalog=RENTAWHEELS;" +
               "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand command = new SqlCommand();
            if (id.Text.Equals(""))
            {
                //Create Sql String with parameter @SelectedLP
                sql = "Insert Into Branch (Name) " +
                "Values(@Name)";
                //add parameter name
                command.Parameters.AddWithValue("@Name", name.Text);
            }
            else
            {
                //Create Sql String with parameter @SelectedLP
                sql = "Update Branch  Set Name = @Name " +
                "Where BranchId = @Id";
                //add parameter name
                command.Parameters.AddWithValue("@Name", name.Text);
                //add parameter Id
                command.Parameters.AddWithValue("@Id", Convert.ToInt16(id.Text));
            }
            try
            {
                //open connection
                connection.Open();
                //Set connection to command
                command.Connection = connection;
                //set Sql string to command object
                command.CommandText = sql;
                //exexute command
                command.ExecuteNonQuery();
                //close connection
                connection.Close();
            }
            catch
            {
                MessageBox.Show("A problem occurred and the application cannot recover! " +
                "Please contact the technical support.");
            }
            BranchMaintenance_Load(null, null);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(
              "Data Source=TESLATEAM;" +
              "Initial Catalog=RENTAWHEELS;" +
              "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand command = new SqlCommand();
            //add parameter name
            string sql = "Delete Branch " +
            "Where BranchId = @Id";
            command.Parameters.AddWithValue(
                "@Id", Convert.ToInt16(id.Text));
            try
            {
                //open connection
                connection.Open();
                //Set connection to command
                command.Connection = connection;
                //set Sql string to command object
                command.CommandText = sql;
                //exexute command
                command.ExecuteNonQuery();
                //close connection
                connection.Close();
            }
            catch
            {
                MessageBox.Show("A problem occurred and the application cannot recover! " +
                "Please contact the technical support.");
            }
            BranchMaintenance_Load(null, null);
        }

        private void reload_Click(object sender, EventArgs e)
        {
            BranchMaintenance_Load(null, null);
        }
    }
}

