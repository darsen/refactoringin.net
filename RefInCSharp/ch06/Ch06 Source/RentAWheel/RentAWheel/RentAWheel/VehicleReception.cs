using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class VehicleReception : Form
    {
        public VehicleReception()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void receive_Click(object sender, EventArgs e)
        {
            int tankLevel = 0;
            switch (tank.Text)
            {
                case "Empty":
                    tankLevel = 0;
                    break;
                case "1/4":
                    tankLevel = 1;
                    break;
                case "1/2":
                    tankLevel = 2;
                    break;
                case "3/4":
                    tankLevel = 3;
                    break;
                case "Full":
                    tankLevel = 4;
                    break;
            }
            SqlConnection connection = new SqlConnection(
                "Data Source=TESLATEAM;" +
                "Initial Catalog=RENTAWHEELS;" +
                 "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand command = new SqlCommand();
            //add parameter name
            string sql = "Update Vehicle " +
                    "Set Available = 3," +
                    "Mileage = @Mileage," +
                    "Tank = @Tank " +
                    "WHERE LicensePlate = @SelectedLP";
           //Add parameter to command
            command.Parameters.AddWithValue(
                "@Mileage", mileage.Text);
            command.Parameters.AddWithValue(
                "@Tank", tankLevel);
            command.Parameters.AddWithValue(
                 "@SelectedLP", licensePlate.Text);
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
            this.Close();
        }

        private void VehicleReception_Load(object sender, EventArgs e)
        {

        }
    }
}
