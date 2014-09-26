using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class VehicleChangeBranch : Form
    {
        //Maintain BranchId - BranchName relation
        private Hashtable branchIdTable;
        public VehicleChangeBranch()
        {
            InitializeComponent();
        }

        private void changeBranch_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm",
            MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SqlConnection connection = new SqlConnection(
                  "Data Source=TESLATEAM;" +
                  "Initial Catalog=RENTAWHEELS;" +
                  "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123");
                SqlCommand command;
                string sql = "Update Vehicle " +
                        "Set BranchId = @BranchId " +
                        "WHERE LicensePlate = @SelectedLP";
                command = new SqlCommand();
                try
                {   //open connection
                    connection.Open();
                    //Set connection to command
                    command.Connection = connection;
                    //set Sql string to command object
                    command.CommandText = sql;
                    //Add parameter to command
                    command.Parameters.AddWithValue(
                       "@BranchId", branchIdTable[branch.Text]);
                    command.Parameters.AddWithValue(
                        "@SelectedLP", licensePlate.Text);
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
            }
        }

        private void VehicleChangeBranch_Load(object sender, EventArgs e)
        {
            branchIdTable = new Hashtable();
            SqlConnection connection = new SqlConnection(
                "Data Source=TESLATEAM;" +
                "Initial Catalog=RENTAWHEELS;" +
                "User ID=RENTAWHEELS_LOGIN;" +
                "Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand command;
            string sql = "Select * from Branch";
            command = new SqlCommand();
            SqlDataReader reader;
            try
            {//open connection
                connection.Open();
                //Set connection to command
                command.Connection = connection;
                //set Sql string to command object
                command.CommandText = sql;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    branch.Items.Add(reader[1]);
                    //Add Id object to table with name as key
                    branchIdTable.Add(reader[1], reader[0]);
                }
                branch.SelectedIndex = 0;
                //close reader
                reader.Close();
                //close connection
                connection.Close();
            }
            catch
            {
                MessageBox.Show("A problem occurred and the application cannot recover! " +
                "Please contact the technical support.");
            }
        }
    }
}
