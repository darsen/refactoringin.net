using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace RentAWheel
{
    public abstract class AbstractData<Persisted>
    {
        private String connectionString;

        private AbstractDataObjectsProvider provider;

        public AbstractData(String connectionString,
            AbstractDataObjectsProvider provider) {
            this.connectionString = connectionString;
            this.provider = provider;
        }

        private String ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        private AbstractDataObjectsProvider Provider
        {
            get { return provider; }
            set { provider = value; }
        }

        private IDbConnection CreateConnection()
         {
             IDbConnection connection = Provider.InstantiateConnection();
             connection.ConnectionString = this.ConnectionString;
             return connection;
         }

        private IDbConnection PrepareDataObjects(IDbCommand command, string sql)
        {
            IDbConnection connection = CreateConnection();
            connection.Open();
            command.Connection = connection;
            command.CommandText = sql;
            return connection;
        }

        protected void AddParameter(IDbCommand command, string parameterName,
        DbType parameterType, object paramaterValue)
        {
            IDbDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.DbType = parameterType;
            parameter.Value = paramaterValue;
            command.Parameters.Add(parameter);
        }

        protected DataSet FillDataset(IDbCommand command, string sql)
        {
            IDbConnection connection = PrepareDataObjects(command, sql);
            IDbDataAdapter adapter = provider.InstantiateAdapter();
            DataSet branches = new DataSet();
            adapter.SelectCommand = command;
            adapter.Fill(branches);
            connection.Close();
            return branches;
        }

        public void ExecuteNonQuery(IDbCommand command, string sql)
        {
            IDbConnection connection = PrepareDataObjects(command, sql);
            command.ExecuteNonQuery();
            connection.Close();
        }

        protected IDataReader ExecuteReader(out IDbConnection connection, string sql)
        {
            IDbCommand command = provider.InstantiateCommand();
            connection = PrepareDataObjects(command, sql);
            return command.ExecuteReader();
        } 

        public abstract IList<Persisted> GetAll();

        public abstract void Delete(Persisted persisted);

        public abstract void Update(Persisted persisted);

        public abstract void Insert(Persisted persisted);
    }
}
