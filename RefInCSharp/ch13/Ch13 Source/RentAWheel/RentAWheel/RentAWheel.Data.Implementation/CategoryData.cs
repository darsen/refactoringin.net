using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RentAWheel.Business;
using System.Configuration;

namespace RentAWheel.Data.Implementation
{
    public class CategoryData : AbstractAdoData<Category>, IData<Category>
    {
        public CategoryData(ConnectionStringSettings settings)
            : base(settings)
        { 
        
        }

        private const string selectAllFromCategorySql = "Select Category.CategoryId as CategoryId, Category.CategoryName as CategoryName, Category.DailyPrice as DailyPrice, Category.WeeklyPrice as WeeklyPrice, Category.MonthlyPrice as MonthlyPrice from Category";
        private const string insertCategorySql = "Insert Into Category (CategoryName, MonthlyPrice, DailyPrice, WeeklyPrice) Values(@Name,@MonthlyPrice, @DailyPrice, @WeeklyPrice)";
        private const string updateCategorySql = "Update Category  Set CategoryName = @Name, DailyPrice = @DailyPrice, WeeklyPrice = @WeeklyPrice, MonthlyPrice = @MonthlyPrice Where CategoryId = @CategoryId";
        private const string deleteCategorySql = "Delete Category Where CategoryId = @Id";

        private const string nameParameterName = "@Name";
        private const string dailyPriceParameterName = "@DailyPrice";
        private const string weeklyPriceParameterName = "@WeeklyPrice";
        private const string monthlyPriceParameterName = "@MonthlyPrice";
        private const string categoryIdParameterName = "@CategoryId";
        private const string idParameterName = "@Id";

        public const string categoryTableIdColumnName = "CategoryId";
        public const string categoryTableNameColumnName = "CategoryName";
        public const string categoryTableDailyPriceColumnName = "DailyPrice";
        public const string categoryTableWeeklyPriceColumnName = "WeeklyPrice";
        public const string categoryTableMonthlyPriceColumnName = "MonthlyPrice";

        private const int singleTableInDatasetIndex = 0;

        public override IList<Category> GetAll()
        {
            IList<Category> categories = new List<Category>();
            IDbCommand command = new SqlCommand();
            DataSet categoriesSet = FillDataset(command, selectAllFromCategorySql);
            DataTable categoriesTable = categoriesSet.Tables[singleTableInDatasetIndex];
            foreach(DataRow row in categoriesTable.Rows){
                categories.Add(
                    CategoryFromRow(row));
            }
            return categories;
        }

        private static Category CategoryFromRow(DataRow row)
        {
            return new Category(Convert.ToInt32(row[categoryTableIdColumnName]),
                                    Convert.ToString(row[categoryTableNameColumnName]),
                                    Convert.ToDecimal(row[categoryTableDailyPriceColumnName]),
                                    Convert.ToDecimal(row[categoryTableWeeklyPriceColumnName]),
                                    Convert.ToDecimal(row[categoryTableMonthlyPriceColumnName]));
        }

        public override void Update(Category category)
        {
            IDbCommand command = new SqlCommand();
            AddCommonParameters(category, command);
            AddParameter(command, categoryIdParameterName, DbType.Int32,
                Convert.ToInt32(category.Id));
            ExecuteNonQuery(command, updateCategorySql);
        }

        public override void Insert(Category category)
        {
            IDbCommand command = new SqlCommand();
            AddCommonParameters(category, command);
            ExecuteNonQuery(command, insertCategorySql);
        }

        private void AddCommonParameters(Category category, IDbCommand command)
        {
            AddParameter(command, nameParameterName,
                DbType.String, category.Name);
            AddParameter(command, dailyPriceParameterName, DbType.Decimal,
                Convert.ToDecimal(category.DailyPrice));
            AddParameter(command, weeklyPriceParameterName, DbType.Decimal,
                Convert.ToDecimal(category.WeeklyPrice));
            AddParameter(command, monthlyPriceParameterName, DbType.Decimal,
                Convert.ToDecimal(category.MonthlyPrice));
        }

        public override void Delete(Category category)
        {
            IDbCommand command = new SqlCommand();
            AddParameter(command, idParameterName,
                DbType.Int32, category.Id);
            ExecuteNonQuery(command, deleteCategorySql);
        }       
    }
}
