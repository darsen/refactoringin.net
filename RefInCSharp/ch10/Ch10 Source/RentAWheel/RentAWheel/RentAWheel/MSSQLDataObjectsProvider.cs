using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RentAWheel
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
