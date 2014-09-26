using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RentAWheel
{
    class ModelData
    {
        private const String connectionString = "Data Source=TESLATEAM;" +
        "Initial Catalog=RENTAWHEELS;" +
        "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123";

        private const string selectAllFromModelJoinCategorySql = "Select Model.ModelId As ModelId, " +
        "Model.ModelName as ModelName, " +
        "Category.CategoryId as CategoryId, " +
        "Category.CategoryName as CategoryName, " +
        "Category.DailyPrice as DailyPrice, " +
        "Category.WeeklyPrice as WeeklyPrice, " +
        "Category.MonthlyPrice as MonthlyPrice " +
        "from Model Inner Join Category " +
        "On Model.CategoryId = Category.CategoryId";

        private const string selectAllFromCategoriesSql = "Select * from Category";
        private const string deleteModelSql = "Delete Model Where ModelId = @ModelId";
        private const string insertModelSql = "Insert Into Model (ModelName,CategoryId) Values(@ModelName, @CategoryId)";
        private const string updateModelSql = "Update Model  Set ModelName = @ModelName, CategoryId = @CategoryId Where ModelId = @ModelId";
        private const string delectModelJoinCategorySql = "Select Model.ModelId As ModelId, Model.ModelName as ModelName, Category.CategoryId as CategoryId, Category.CategoryName as CategoryName, Category.DailyPrice as DailyPrice, Category.WeeklyPrice as WeeklyPrice, Category.MonthlyPrice as MonthlyPricefrom Model Inner Join Category On Model.CategoryId = Category.CategoryId";

        private const string modelTableIdColumnName = "ModelId";
        private const string modelTableNameColumName = "ModelName";
        private const string ModelTableCategoryColumnName = "CategoryName";

        private const string modelNameParameter = "@ModelName";
        private const string categoryIdParameter = "@CategoryId";
        private const string modelIdParameter = "@ModelId";

        private const int singleTableInDatasetIndex = 0;

        public IList<Model> GetAll() {
            IList<Model> models = new List<Model>();
            IDbCommand command = new SqlCommand();
            DataSet modelsSet = FillDataset(command, selectAllFromModelJoinCategorySql);
            DataTable modelsTable = modelsSet.Tables[singleTableInDatasetIndex];
            foreach(DataRow row in modelsTable.Rows){
                models.Add(
                    ModelFromRow(row));                                    
            }
            return models;
        }

        public static Model ModelFromRow(DataRow row)
        {
            return new Model(
                        Convert.ToInt32(row[modelTableIdColumnName]),
                        Convert.ToString(row[modelTableNameColumName]),
                            new Category(Convert.ToInt32(row[CategoryData.categoryTableIdColumnName]),
                                Convert.ToString(row[CategoryData.categoryTableNameColumnName]),
                                Convert.ToDecimal(row[CategoryData.categoryTableDailyPriceColumnName]),
                                Convert.ToDecimal(row[CategoryData.categoryTableWeeklyPriceColumnName]),
                                Convert.ToDecimal(row[CategoryData.categoryTableMonthlyPriceColumnName])));
        }
        
        public void Update(Model model)
        {
            IDbCommand command = new SqlCommand();
            AddParameter(command, modelNameParameter, DbType.String, model.Name);
            AddParameter(command, categoryIdParameter,
                DbType.String, model.Category.Id);
            AddParameter(command, modelIdParameter, DbType.Int32, model.Id);
            ExecuteNonQuery(command, updateModelSql);
        }

        public void Insert(Model model)
        {
            IDbCommand command = new SqlCommand();
            AddParameter(command, modelNameParameter, DbType.String, model.Name);
            AddParameter(command, categoryIdParameter,
                DbType.String, model.Category.Id);
            ExecuteNonQuery(command, insertModelSql);
        }

        public void Delete(Model model)
        {
            IDbCommand command = new SqlCommand();
            AddParameter(command, modelIdParameter, DbType.String, model.Id);
            ExecuteNonQuery(command, deleteModelSql);
        }

        private IDataReader ExecuteReader(out IDbConnection connection, string sql)
        {
            IDbCommand command = new SqlCommand();
            connection = PrepareDataObjects(command, sql);
            return command.ExecuteReader();
        }

        public void ExecuteNonQuery(IDbCommand command, string sql)
        {
            IDbConnection connection = PrepareDataObjects(command, sql);
            command.ExecuteNonQuery();
            connection.Close();
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

        private DataSet FillDataset(IDbCommand command, string sql)
        {
            IDbConnection connection = PrepareDataObjects(command, sql);
            IDbDataAdapter adapter = new SqlDataAdapter();
            DataSet branches = new DataSet();
            adapter.SelectCommand = command;
            adapter.Fill(branches);
            connection.Close();
            return branches;
        }
    }
}
