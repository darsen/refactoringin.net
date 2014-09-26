using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentAWheel
{
    public abstract class AbstractDataObjectsProvider
    {
        public abstract System.Data.IDbDataAdapter InstantiateAdapter();

        public abstract System.Data.IDbConnection InstantiateConnection();

        public abstract System.Data.IDbCommand InstantiateCommand();
    }
}
