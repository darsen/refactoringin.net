using System.Data.SqlClient;

namespace RentAWheel.Data.Implementation
{
    public class MSSQLDataObjectsProvider : AbstractDataObjectsProvider
    {
        public override System.Data.IDbDataAdapter InstantiateAdapter()
        {
            return new SqlDataAdapter();
        }

        public override System.Data.IDbConnection InstantiateConnection()
        {
            return new SqlConnection();
        }

        public override System.Data.IDbCommand InstantiateCommand() 
        {
            return new SqlCommand();
        }
    } 
}
