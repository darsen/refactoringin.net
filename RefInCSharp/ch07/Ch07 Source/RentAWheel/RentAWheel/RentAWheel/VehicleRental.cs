using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class VehicleRental : Form
    {
        public VehicleRental()
        {
            InitializeComponent();
        }

        private void rent_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm",
            MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SqlConnection connection = new SqlConnection(
                  "Data Source=TESLATEAM;" +
                  "Initial Catalog=RENTAWHEELS;" +
                  "User ID=RENTAWHEELS_LOGIN;" +
                  "Password=RENTAWHEELS_PASSWORD_123");
                SqlCommand command;
                string sql = "Update Vehicle " +
                            "Set Available = 1," +
                            "CustomerFirstName = @CustomerFirstName," +
                            "CustomerLastName = @CustomerLastName," +
                            "CustomerDocNumber = @CustomerDocNumber," +
                            "CustomerDocType = @CustomerDocType " +
                            "WHERE LicensePlate = @SelectedLP";
                command = new SqlCommand();
                try
                {//open connection
                    connection.Open();
                    //Set connection to command
                    command.Connection = connection;
                    //set Sql string to command object
                    command.CommandText = sql;
                    //Add parameter to command
                    command.Parameters.AddWithValue(
                        "@CustomerFirstName", firstName.Text);
                    command.Parameters.AddWithValue(
                        "@CustomerLastName", lastName.Text);
                    command.Parameters.AddWithValue(
                        "@CustomerDocNumber", documentNumber.Text);
                    command.Parameters.AddWithValue(
                        "@CustomerDocType", documentType.Text);
                    command.Parameters.AddWithValue(
                        "@SelectedLP", licensePlate.Text);
                    //exexute command
                    command.ExecuteNonQuery();
                    //close connection
                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("A problem occurred" +
                    "and the application cannot recover! " +
                    "Please contact the technical support.");
                }
                this.Close();
            }

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VehicleRental_Load(object sender, EventArgs e)
        {

        }

    }
}
