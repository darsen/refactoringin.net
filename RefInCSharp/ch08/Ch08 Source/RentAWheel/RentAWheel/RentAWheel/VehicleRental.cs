using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class VehicleRental : Form
    {
        private const String connectionString = "Data Source=TESLATEAM;" +
        "Initial Catalog=RENTAWHEELS;" +
        "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123";

        private const string customerFirstNameParameter = "@CustomerFirstName";
        private const string customerLastNameParameter = "@CustomerLastName";
        private const string customerDocNumberParameter = "@CustomerDocNumber";
        private const string customerDocTypeParameter = "@CustomerDocType";
        private const string selectedLicencePlateParameter = "@SelectedLP";

        private const string rentVehicleSql = "Update Vehicle Set Available = 1, CustomerFirstName = @CustomerFirstName,CustomerLastName = @CustomerLastName,CustomerDocNumber = @CustomerDocNumber,CustomerDocType = @CustomerDocType WHERE LicensePlate = @SelectedLP";
            
        public VehicleRental()
        {
            InitializeComponent();
        }

        private void rent_Click(object sender, EventArgs e)
        {
            if (UserConfirms())
            {
                RentVehicle();
                this.Close();
            }
        }
        
        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RentVehicle()
        {
            IDbCommand command = default(IDbCommand);
            command = new SqlCommand();
            AddParameter(command, customerFirstNameParameter, DbType.String, firstName.Text);
            AddParameter(command, customerLastNameParameter, DbType.String, lastName.Text);
            AddParameter(command, customerDocNumberParameter, DbType.String, documentNumber.Text);
            AddParameter(command, customerDocTypeParameter, DbType.String, documentType.Text);
            AddParameter(command, selectedLicencePlateParameter, DbType.String, licensePlate.Text);
            ExecuteNonQuery(command, rentVehicleSql);
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

        private void VehicleRental_Shown(object sender, EventArgs e)
        {
            firstName.Text = String.Empty;
            lastName.Text = String.Empty;
            documentNumber.Text = String.Empty;
            documentType.Text = String.Empty;
        }

        private bool UserConfirms()
        {
            return MessageBox.Show("Are you sure?", "Confirm",
                MessageBoxButtons.OKCancel) == DialogResult.OK;
        }
    }
}
