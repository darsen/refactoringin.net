using System.Data;
using System.Data.SqlClient;

namespace Users
{
    public class MsSqlProviderFactory: DataProviderFactory
    {

        public override IDbCommand CreateCommand() {
            return new SqlCommand();
        }

        public override IDbConnection CreateConnection() {
            return new SqlConnection();
        }
    }
}
