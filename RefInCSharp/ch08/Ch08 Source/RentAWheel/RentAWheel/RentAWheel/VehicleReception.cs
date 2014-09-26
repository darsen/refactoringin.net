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
        private const String connectionString = "Data Source=TESLATEAM;" +
        "Initial Catalog=RENTAWHEELS;" +
        "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123";
        
        private const string receiveVehicleSql = "Update Vehicle Set Available = 3,Mileage = @Mileage, Tank = @Tank WHERE LicensePlate = @SelectedLP";

        private const string mileageParameterName = "@Mileage";
        private const string tankParameterName = "@Tank";
        private const string selectedLicesePlateParameter = "@SelectedLP";

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
            if (UserConfirms())
            {
                ReceiveVehicle();
                this.Close();
            }
            
        }

        private void ReceiveVehicle() {
            IDbCommand command = new SqlCommand();
            int tankLevelValue = 0;
            tankLevelValue = TankLevelValue(this.tank.Text);
            AddParameter(command, mileageParameterName, DbType.Int32, Convert.ToInt32(mileage.Text));
            AddParameter(command, tankParameterName, DbType.Int32, tankLevelValue);
            AddParameter(command, selectedLicesePlateParameter, DbType.String, licensePlate.Text);
            ExecuteNonQuery(command, receiveVehicleSql);        
        }

        private int TankLevelValue(string level)
        {
            int tankLevelValue = 0;            
            switch (level)
            {
                case "Empty":
                    tankLevelValue = 0;
                    break;
                case "1/4":
                    tankLevelValue = 1;
                    break;
                case "1/2":
                    tankLevelValue = 2;
                    break;
                case "3/4":
                    tankLevelValue = 3;
                    break;
                case "Full":
                    tankLevelValue = 4;
                    break;
            }
            return tankLevelValue;
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

        private void VehicleReception_Shown(object sender, EventArgs e)
        {               
            mileage.Text = String.Empty;
            tank.Text = String.Empty;
        }

        private bool UserConfirms()
        {
            return MessageBox.Show("Are you sure?", "Confirm",
                MessageBoxButtons.OKCancel) == DialogResult.OK;
        }
    }
}
