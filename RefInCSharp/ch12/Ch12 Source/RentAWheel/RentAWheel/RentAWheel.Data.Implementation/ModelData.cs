using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RentAWheel.Business;

namespace RentAWheel.Data.Implementation
{
    public class ModelData : AbstractData<Model>
    {
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

        public override IList<Model> GetAll() {
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

        public override void Update(Model model)
        {
            IDbCommand command = new SqlCommand();
            AddParameter(command, modelNameParameter, DbType.String, model.Name);
            AddParameter(command, categoryIdParameter,
                DbType.String, model.Category.Id);
            AddParameter(command, modelIdParameter, DbType.Int32, model.Id);
            ExecuteNonQuery(command, updateModelSql);
        }

        public override void Insert(Model model)
        {
            IDbCommand command = new SqlCommand();
            AddParameter(command, modelNameParameter, DbType.String, model.Name);
            AddParameter(command, categoryIdParameter,
                DbType.String, model.Category.Id);
            ExecuteNonQuery(command, insertModelSql);
        }

        public override void Delete(Model model)
        {
            IDbCommand command = new SqlCommand();
            AddParameter(command, modelIdParameter, DbType.String, model.Id);
            ExecuteNonQuery(command, deleteModelSql);
        }      
    }
}
