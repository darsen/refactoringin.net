using System;
using System.Data;
using System.Windows.Forms;

namespace Users
{
    public partial class UserMaintenance : Form
    {
        public UserMaintenance()
        {
            InitializeComponent();
        }

        private const String DeleteUserSql =
            "Delete [User] where [Id] = @Id";

        private void delete_Click(object sender, EventArgs e)
        {
            DataProviderFactory factory = 
                DataProviderFactory.CreateDataProviderFactory(
                DataProviderFactory.DatabaseProviderName);
            IDbConnection connection;
            connection = factory.CreateConnection();
            connection.ConnectionString = DataProviderFactory.ConnectionString;
            IDbCommand command;
            command = factory.CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = DeleteUserSql;
            connection.Open();
            IDataParameter id = command.CreateParameter();
            id.ParameterName = "@Id";
            id.Value = this.id.Text;
            id.DbType = DbType.Int16;
            command.Parameters.Add(id);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
