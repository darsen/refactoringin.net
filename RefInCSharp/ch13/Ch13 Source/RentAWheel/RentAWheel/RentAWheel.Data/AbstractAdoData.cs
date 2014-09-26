using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace RentAWheel.Data
{
    public abstract class AbstractAdoData<Persisted> 
        :         AbstractData<Persisted>
    {
        private DbProviderFactory databaseProviderFactory;

        public AbstractAdoData(ConnectionStringSettings settings) :base(settings)
        {
            this.DatabaseProviderFactory =
                    DbProviderFactories.GetFactory(
                    ConnectionStringSettings.ProviderName);   
        }

        protected DbProviderFactory DatabaseProviderFactory
        {
            get { return databaseProviderFactory; }
            set { databaseProviderFactory = value; }
        }

        private IDbConnection CreateConnection()
        {
            IDbConnection connection = 
                DatabaseProviderFactory.CreateConnection();
            connection.ConnectionString = 
                ConnectionStringSettings.ConnectionString;
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
            IDbDataAdapter adapter = DatabaseProviderFactory.CreateDataAdapter();
            DataSet branches = new DataSet();
            adapter.SelectCommand = command;
            adapter.Fill(branches);
            connection.Close();
            return branches;
        }

        protected void ExecuteNonQuery(IDbCommand command, string sql)
        {
            IDbConnection connection = PrepareDataObjects(command, sql);
            command.ExecuteNonQuery();
            connection.Close();
        }

        protected IDataReader ExecuteReader(out IDbConnection connection, 
            string sql)
        {
            IDbCommand command = 
                DatabaseProviderFactory.CreateCommand();
            connection = PrepareDataObjects(command, sql);
            return command.ExecuteReader();
        } 

        public abstract IList<Persisted> GetAll();

        public abstract void Delete(Persisted persisted);

        public abstract void Update(Persisted persisted);

        public abstract void Insert(Persisted persisted);
 
    }
}
