using System.Data;
using System.Data.OleDb;

namespace Users
{
    public class OleDbProviderFactory: DataProviderFactory
    {
        public override IDbCommand CreateCommand() {
            return new OleDbCommand();
        }

        public override IDbConnection CreateConnection() {
            return new OleDbConnection();
        }
    }    
}
