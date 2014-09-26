using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class ModelMaintenance : Form
    {
        private const String connectionString = "Data Source=TESLATEAM;" +
        "Initial Catalog=RENTAWHEELS;" +
        "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123";

        private const string selectAllFromModelJoinCategorySql = "Select Model.ModelId As ModelId, " +
        "Model.Name as ModelName, " +
        "Category.Name as CategoryName " +
        "from Model Inner Join Category " +
        "On Model.CategoryId = Category.CategoryId";

        private const string selectAllFromCategoriesSql = "Select * from Category";
        private const string deleteModelSql = "Delete Model Where ModelId = @ModelId";
        private const string insertModelSql = "Insert Into Model (Name,CategoryId) Values(@ModelName, @CategoryId)";
        private const string updateModelSql = "Update Model  Set Name = @ModelName, CategoryId = @CategoryId Where ModelId = @ModelId";
        private const string delectModelJoinCategorySql = "Select Model.ModelId As ModelId, Model.Name as ModelName, Category.Name as CategoryName from Model Inner Join Category On Model.CategoryId = Category.CategoryId";

        private const string modelTableIdColumnName = "ModelId";
        private const string modelTableNameColumName = "ModelName";
        private const string ModelTableCategoryColumnName = "CategoryName";

        private const string modelNameParameter = "@ModelName";
        private const string categoryIdParameter = "@CategoryId";
        private const string modelIdParameter = "@ModelId";

        private Hashtable categoryIdFromName;
        private DataTable models;
        private int currentRowIndex;

        private const int singleTableInDatasetIndex = 0;

        public ModelMaintenance()
        {
            InitializeComponent();
        }

        private void right_Click(object sender, EventArgs e)
        {
            if (models.Rows.Count > currentRowIndex + 1)
            {
                currentRowIndex++;
                DisplayCurrentRow();
            }
        }

        private void left_Click(object sender, EventArgs e)
        {
            if (currentRowIndex - 1 >= 0 & models.Rows.Count > 0)
            {
                currentRowIndex--;
                DisplayCurrentRow();
            }
        }

        private void first_Click(object sender, EventArgs e)
        {
            if (models.Rows.Count > 0)
            {
                currentRowIndex = 0;
                DisplayCurrentRow();
            }
        }

        private void last_Click(object sender, EventArgs e)
        {
            if (models.Rows.Count > 0)
            {
                currentRowIndex = models.Rows.Count - 1;
                DisplayCurrentRow();
            }
        }

        private void DisplayCurrentRow()
        {
            DataRow row = models.Rows[currentRowIndex];
            id.Text = row[modelTableIdColumnName].ToString();
            name.Text = row[modelTableNameColumName].ToString();
            category.Text = row[ModelTableCategoryColumnName].ToString();
        }

        private void new_Click(object sender, EventArgs e)
        {
            id.Text = String.Empty;
            name.Text = String.Empty;
            category.Text = String.Empty;
        }

        private void save_Click(object sender, EventArgs e)
        {
            InsertOrUpdateModel();
            ModelMaintenance_Load(null, null);
        }

        private void InsertOrUpdateModel()
        {
            IDbCommand command = new SqlCommand();            
            if ((String.IsNullOrEmpty(id.Text)))
            {
                AddParameter(command, modelNameParameter, DbType.String, name.Text);
                AddParameter(command, categoryIdParameter, 
                    DbType.String, categoryIdFromName[category.Text]);
                ExecuteNonQuery(command, insertModelSql);
            }
            else
            {                
                AddParameter(command, modelNameParameter, DbType.String, name.Text);
                AddParameter(command, categoryIdParameter, 
                    DbType.String, categoryIdFromName[category.Text]);
                AddParameter(command, modelIdParameter, DbType.Int32, Convert.ToInt32(id.Text));
                ExecuteNonQuery(command, updateModelSql);
            }
        }

        private void ModelMaintenance_Load(object sender, EventArgs e)
        {            
            LoadCategoryCombo();
            LoadModels();
            if (models.Rows.Count > 0)
            {
                currentRowIndex = 0;
                DisplayCurrentRow();
            }  
        }

        private void LoadCategoryCombo()
        {
            IDbConnection connection = null;
            IDataReader categoryReader = ExecuteReader(out connection, selectAllFromCategoriesSql);
            categoryIdFromName = new Hashtable();
            while (categoryReader.Read())
            {
                category.Items.Add(categoryReader[1]);
                //Add Id object to table with name as key
                categoryIdFromName.Add(categoryReader[1], categoryReader[0]);
            }
            categoryReader.Close();
            connection.Close();
        }

        private void LoadModels()
        {
            IDbCommand command = new SqlCommand();
            DataSet models = FillDataset(command, selectAllFromModelJoinCategorySql);
            this.models = models.Tables[singleTableInDatasetIndex];
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DeleteModel();
            ModelMaintenance_Load(null, null);
        }

        private void DeleteModel()
        {
            IDbCommand command = new SqlCommand();
            AddParameter(command, modelIdParameter, DbType.String, id.Text);
            ExecuteNonQuery(command, deleteModelSql);
        }

        private void reload_Click(object sender, EventArgs e)
        {
            ModelMaintenance_Load(null, null);
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
