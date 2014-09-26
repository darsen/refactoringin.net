using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class VehicleCategoriesMaintenance : Form
    {
        private const String connectionString = "Data Source=TESLATEAM;" +
        "Initial Catalog=RENTAWHEELS;" +
        "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123";

        private const string selectAllFromCategorySql = "Select * from Category";
        private const string insertCategorySql = "Insert Into Category (Name, MonthlyPrice, DailyPrice, WeeklyPrice) Values(@Name,@MonthlyPrice, @DailyPrice, @WeeklyPrice)";
        private const string updateCategorySql = "Update Category  Set Name = @Name, DailyPrice = @DailyPrice, WeeklyPrice = @WeeklyPrice, MonthlyPrice = @MonthlyPrice Where CategoryId = @CategoryId";
        private const string deleteCategorySql = "Delete Category Where CategoryId = @Id";

        private const string nameParameterName = "@Name";
        private const string dailyPriceParameterName = "@DailyPrice";
        private const string weeklyPriceParameterName = "@WeeklyPrice";
        private const string monthlyPriceParameterName = "@MonthlyPrice";
        private const string categoryIdParameterName = "@CategoryId";
        private const string idParameterName = "@Id";

        private const string categoryTableIdColumnName = "CategoryId";
        private const string categoryTableNameColumnName = "Name";
        private const string categoryTableDailyPriceColumnName = "DailyPrice";
        private const string categoryTableWeeklyPriceColumnName = "WeeklyPrice";
        private const string categoryTableMonthlyPriceColumnName = "MonthlyPrice";

        private const int singleTableInDatasetIndex = 0;

        private DataTable categories;
        private int currentRowIndex;

        public VehicleCategoriesMaintenance()
        {
            InitializeComponent();
        }

        private void right_Click(object sender, EventArgs e)
        {
            if (categories.Rows.Count > currentRowIndex + 1)
            {
                currentRowIndex++;
                DisplayCurrentRow();
            }
        }

        private void left_Click(object sender, EventArgs e)
        {
            if (currentRowIndex - 1 >= 0 & categories.Rows.Count > 0)
            {
                currentRowIndex--;
                DisplayCurrentRow();
            }
        }

        private void first_Click(object sender, EventArgs e)
        {
            if (categories.Rows.Count > 0)
            {
                currentRowIndex = 0;
                DisplayCurrentRow();
            }
        }

        private void last_Click(object sender, EventArgs e)
        {
            if (categories.Rows.Count > 0)
            {
                currentRowIndex = categories.Rows.Count - 1;
                DisplayCurrentRow();
            }
        }

        private void DisplayCurrentRow()
        {
            DataRow row = categories.Rows[currentRowIndex];
            id.Text = row[categoryTableIdColumnName].ToString();
            name.Text = row[categoryTableNameColumnName].ToString();
            dailyPrice.Text = row[categoryTableDailyPriceColumnName].ToString();
            weeklyPrice.Text = row[categoryTableWeeklyPriceColumnName].ToString();
            monthlyPrice.Text = row[categoryTableMonthlyPriceColumnName].ToString();
        }


        private void new_Click(object sender, EventArgs e)
        {
            id.Text = String.Empty;
            name.Text = String.Empty;
            dailyPrice.Text = String.Empty;
            weeklyPrice.Text = String.Empty;
            monthlyPrice.Text = String.Empty;
        }

        private void VehicleCategoriesMaintenance_Load(object sender, EventArgs e)
        {   
            LoadCategories();
            if (categories.Rows.Count > 0)
            {
                DisplayCurrentRow();
            }            
        }

        private void LoadCategories() {
            IDbCommand command = new SqlCommand();
            DataSet categories = FillDataset(command, selectAllFromCategorySql);
            this.categories = categories.Tables[singleTableInDatasetIndex];
            if ((this.categories.Rows.Count > 0))
            {
                currentRowIndex = 0;
                DisplayCurrentRow();
            }
        
        }

        private void reload_Click(object sender, EventArgs e)
        {
            VehicleCategoriesMaintenance_Load(null, null);
        }

        private void save_Click(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(id.Text)))
            {
                InsertCategory();
            }
            else
            {
                UpdateCategory();
            }
            VehicleCategoriesMaintenance_Load(null, null);
        }

        private void UpdateCategory()
        {
            IDbCommand command = new SqlCommand();
            AddCommonParameters(command);
            AddParameter(command, categoryIdParameterName, DbType.Int32, 
                Convert.ToInt32(this.id.Text));
            ExecuteNonQuery(command, updateCategorySql);
        }

        private void InsertCategory()
        {
            IDbCommand command = new SqlCommand();
            AddCommonParameters(command);
            ExecuteNonQuery(command, insertCategorySql);
        }

        private void AddCommonParameters(IDbCommand command)
        {
            AddParameter(command, nameParameterName, 
                DbType.String, name.Text);
            AddParameter(command, dailyPriceParameterName, DbType.Decimal, 
                Convert.ToDecimal(this.dailyPrice.Text));
            AddParameter(command, weeklyPriceParameterName, DbType.Decimal, 
                Convert.ToDecimal(this.weeklyPrice.Text));
            AddParameter(command, monthlyPriceParameterName, DbType.Decimal, 
                Convert.ToDecimal(this.monthlyPrice.Text));
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DeleteCategory();
            VehicleCategoriesMaintenance_Load(null, null);
        }

        private void DeleteCategory() {
            IDbCommand command = new SqlCommand();
            AddParameter(command, idParameterName, 
                DbType.Int32, Convert.ToInt32(id.Text));            
            ExecuteNonQuery(command, deleteCategorySql);            
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

        public void ExecuteNonQuery(IDbCommand command, string sql)
        {
            IDbConnection connection = PrepareDataObjects(command, sql);
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}
