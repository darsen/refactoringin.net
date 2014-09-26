using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class FleetMaintenance : Form
    {
        //Maintain BranchId - BranchName relation
        private Hashtable branchIdFromName;
        //Maintain ModelId - ModelName relation
        private Hashtable modelIdFromName;
        //table Vehicles
        private DataTable vehicles;
        //Index of displayed row
        private int currentRowIndex;

        public FleetMaintenance()
        {
            InitializeComponent();
        }

        private void FleetMaintenance_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(
               "Data Source=TESLATEAM;" +
               "Initial Catalog=RENTAWHEELS;" +
               "User ID=RENTAWHEELS_LOGIN;" + 
               "Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand commandCombo = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            //LOAD BRANCH COMBO -->
            //Create Sql String             
            string sqlCombo = "Select * from Branch";
            try
            {
                //open connection
                connection.Open();
                //Set connection to command
                commandCombo.Connection = connection;
                //set Sql string to command object
                commandCombo.CommandText = sqlCombo;
                //execute command
                SqlDataReader reader = commandCombo.ExecuteReader();
                branchIdFromName = new Hashtable();
                while (reader.Read())
                {
                    branch.Items.Add(reader[1]);
                    //Add Id object to table with name as key
                    branchIdFromName.Add(reader[1], reader[0]);
                }
                //close reader
                reader.Close();
                //END LOAD COMBO -->

                //LOAD MODEL COMBO -->
                //Create Sql String             
                sqlCombo = "Select * from Model";
                //Set connection to command
                commandCombo.Connection = connection;
                //set Sql string to command object
                commandCombo.CommandText = sqlCombo;
                //execute command
                reader = commandCombo.ExecuteReader();
                modelIdFromName = new Hashtable();
                while (reader.Read())
                {
                    model.Items.Add(reader[1]);
                    //Add Id object to table with name as key
                    modelIdFromName.Add(reader[1], reader[0]);
                }
                //close reader
                reader.Close();
                //END LOAD COMBO -->

                //LOAD DATASET -->
                //create data set
                DataSet modelData = new DataSet();
                SqlCommand command = new SqlCommand();
                //Create Sql String with parameter @SelectedLP
                string sql = "Select Vehicle.LicensePlate AS LicensePlate, " +
                "Branch.Name as BranchName, " +
                "Model.Name as ModelName " +
                "from Vehicle " +
                "Inner Join Branch On " +
                "Vehicle.BranchId = Branch.BranchId " +
                "Inner Join Model On " +
                "Vehicle.ModelId = Model.ModelId";
                //Set connection to command
                command.Connection = connection;
                //set Sql string to command object
                command.CommandText = sql;
                //execute command
                adapter.SelectCommand = command;
                //fill DataSet
                adapter.Fill(modelData);
                //close connection
                connection.Close();
                //destroy objects        
                vehicles = modelData.Tables[0];
                if (vehicles.Rows.Count > 0)
                {
                    DataRow row = vehicles.Rows[0];
                    licensePlate.Text = row["LicensePlate"].ToString();
                    branch.Text = row["BranchName"].ToString();
                    model.Text = row["ModelName"].ToString();
                    currentRowIndex = 0;
                }
                //END LOAD DATASET -->
            }
            catch
            {
                MessageBox.Show("A problem occurred and the application cannot recover! " +
                "Please contact the technical support.");
            }
        }

        private void right_Click(object sender, EventArgs e)
        {
            if (vehicles.Rows.Count > currentRowIndex + 1)
            {
                currentRowIndex++;
                DataRow row = vehicles.Rows[currentRowIndex];
                licensePlate.Text = row["LicensePlate"].ToString();
                branch.Text = row["BranchName"].ToString();
                model.Text = row["ModelName"].ToString();
            }
        }

        private void left_Click(object sender, EventArgs e)
        {
            if (currentRowIndex - 1 >= 0 & vehicles.Rows.Count > 0)
            {
                currentRowIndex--;
                DataRow row = vehicles.Rows[currentRowIndex];
                licensePlate.Text = row["LicensePlate"].ToString();
                branch.Text = row["BranchName"].ToString();
                model.Text = row["ModelName"].ToString();
            }
        }

        private void first_Click(object sender, EventArgs e)
        {
            if (vehicles.Rows.Count > 0)
            {
                currentRowIndex = 0;
                DataRow row = vehicles.Rows[currentRowIndex];
                licensePlate.Text = row["LicensePlate"].ToString();
                branch.Text = row["BranchName"].ToString();
                model.Text = row["ModelName"].ToString();
            }
        }

        private void last_Click(object sender, EventArgs e)
        {
            if (vehicles.Rows.Count > 0)
            {
                currentRowIndex = vehicles.Rows.Count - 1;
                DataRow row = vehicles.Rows[currentRowIndex];
                licensePlate.Text = row["LicensePlate"].ToString();
                branch.Text = row["BranchName"].ToString();
                model.Text = row["ModelName"].ToString();
            }
        }

        private void new_Click(object sender, EventArgs e)
        {
            licensePlate.Text = "";
            branch.Text = "";
            model.Text = "";
        }

        private void save_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(
               "Data Source=TESLATEAM;" +
               "Initial Catalog=RENTAWHEELS;" +
               "User ID=RENTAWHEELS_LOGIN;" + 
               "Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand commandDelete = new SqlCommand();
            SqlCommand commandInsert = new SqlCommand();
            string sqlDelete = "Delete From Vehicle " + 
                 "Where LicensePlate = @LicensePlate";
            //Create Sql String for insert
            string sqlInsert = "Insert Into Vehicle " + 
            "(LicensePlate, ModelId,BranchId) " + 
            "Values(@LicensePlate, @ModelId, @BranchId)";
            //add parameter for delete
            commandDelete.Parameters.AddWithValue( 
            "@LicensePlate", licensePlate.Text);
            //add parameters for insert
            commandInsert.Parameters.AddWithValue( 
                "@LicensePlate", licensePlate.Text);
            commandInsert.Parameters.AddWithValue( 
            "@ModelId", modelIdFromName[model.Text]);
            commandInsert.Parameters.AddWithValue( 
                "@BranchId", branchIdFromName[branch.Text]);
            //open connection
            connection.Open();
            //Set connection to command
            commandDelete.Connection = connection;
            commandInsert.Connection = connection;
            //set Sql string to command object
            commandDelete.CommandText = sqlDelete;
            commandInsert.CommandText = sqlInsert;
            //start transaction
            SqlTransaction oTrx = connection.BeginTransaction();
            //enlist commands with transaction
            commandDelete.Transaction = oTrx;
            commandInsert.Transaction = oTrx;
            //execute command: first delete and then insert record
            commandDelete.ExecuteNonQuery();
            commandInsert.ExecuteNonQuery();
            oTrx.Commit();
            //close connection
            connection.Close();                                              
            FleetMaintenance_Load(null, null);
        }

        private void delete_Click(object sender, EventArgs e)
        {            
            SqlConnection connection = new SqlConnection(
               "Data Source=TESLATEAM;" +
               "Initial Catalog=RENTAWHEELS;" +
               "User ID=RENTAWHEELS_LOGIN;" + 
               "Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand commandDelete = new SqlCommand();            
            string sqlDelete = "Delete From Vehicle " +
                 "Where LicensePlate = @LicensePlate";           
            //add parameter for delete
            commandDelete.Parameters.AddWithValue(
            "@LicensePlate", licensePlate.Text);            
            //open connection
            connection.Open();
            //Set connection to command
            commandDelete.Connection = connection;            
            //set Sql string to command object
            commandDelete.CommandText = sqlDelete;                   
            //execute command: delete 
            commandDelete.ExecuteNonQuery();
            //close connection
            connection.Close();
            FleetMaintenance_Load(null, null);
        }

        private void reload_Click(object sender, EventArgs e)
        {
            FleetMaintenance_Load(null, null);
        }

    }
}

