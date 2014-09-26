using System.Data;
using System.Data.OracleClient;

namespace Users
{
    public class OracleProviderFactory:DataProviderFactory
    {

        public override IDbCommand CreateCommand() {
            return new OracleCommand();
        }

        public override IDbConnection CreateConnection() {
            return new OracleConnection();
        }
    }    
}
