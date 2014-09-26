using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class ModelMaintenance : Form
    {
        private Hashtable categoryIdTable;
        private DataTable models;
        private int currentRowIndex;

        public ModelMaintenance()
        {
            InitializeComponent();
        }

        private void right_Click(object sender, EventArgs e)
        {
            if (models.Rows.Count > currentRowIndex + 1)
            {
                currentRowIndex++;
                DataRow row = models.Rows[currentRowIndex];
                id.Text = row["ModelId"].ToString();
                name.Text = row["ModelName"].ToString();
                category.Text = row["CategoryName"].ToString();
            }
        }

        private void left_Click(object sender, EventArgs e)
        {
            if (currentRowIndex - 1 >= 0 & models.Rows.Count > 0)
            {
                currentRowIndex--;
                DataRow row = models.Rows[currentRowIndex];
                id.Text = row["ModelId"].ToString();
                name.Text = row["ModelName"].ToString();
                category.Text = row["CategoryName"].ToString();
            }
        }

        private void first_Click(object sender, EventArgs e)
        {
            if (models.Rows.Count > 0)
            {
                currentRowIndex = 0;
                DataRow row = models.Rows[currentRowIndex];
                id.Text = row["ModelId"].ToString();
                name.Text = row["ModelName"].ToString();
                category.Text = row["CategoryName"].ToString();
            }
        }

        private void last_Click(object sender, EventArgs e)
        {
            if (models.Rows.Count > 0)
            {
                currentRowIndex = models.Rows.Count - 1;
                DataRow row = models.Rows[currentRowIndex];
                id.Text = row["ModelId"].ToString();
                name.Text = row["ModelName"].ToString();
                category.Text = row["CategoryName"].ToString();
            }
        }

        private void new_Click(object sender, EventArgs e)
        {
            id.Text = "";
            name.Text = "";
            category.Text = "";
        }

        private void save_Click(object sender, EventArgs e)
        {
            string sql;
            SqlConnection connection = new SqlConnection(
               "Data Source=TESLATEAM;" +
               "Initial Catalog=RENTAWHEELS;" +
               "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand command = new SqlCommand();
            if (id.Text.Equals(""))
            {
                //Create Sql String with parameter
                sql = "Insert Into Model (Name,CategoryId) " +
                    "Values(@ModelName, @CategoryId)";
                //add parameters
                command.Parameters.AddWithValue(
                    "@ModelName", name.Text);
                command.Parameters.AddWithValue(
                    "@CategoryId", this.categoryIdTable[category.Text]);
            }
            else
            {
                //Create Sql String with parameter
                sql = "Update Model  Set Name = @ModelName, " +
                "CategoryId = @CategoryId " +
                "Where ModelId = @ModelId";
                //add parameters
                command.Parameters.AddWithValue(
                   "@ModelName", name.Text);
                command.Parameters.AddWithValue(
                    "@CategoryId", this.categoryIdTable[category.Text]);
                command.Parameters.AddWithValue("@ModelId", id.Text);
            }
            try
            {
                //open connection
                connection.Open();
                //Set connection to command
                command.Connection = connection;
                //set Sql string to command object
                command.CommandText = sql;
                //exexute command
                command.ExecuteNonQuery();
                //close connection
                connection.Close();
            }
            catch
            {
                MessageBox.Show("A problem occurred and the application cannot recover! " +
                "Please contact the technical support.");
            }
            ModelMaintenance_Load(null, null);
        }

        private void ModelMaintenance_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(
               "Data Source=TESLATEAM;" +
               "Initial Catalog=RENTAWHEELS;" +
               "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand commandCombo = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            //LOAD COMBO -->
            //Create Sql String             
            string sqlCombo = "Select * from Category";
            try
            {
                //open connection
                connection.Open();
                //Set connection to command
                commandCombo.Connection = connection;
                //set Sql string to command object
                commandCombo.CommandText = sqlCombo;
                //execute command
                SqlDataReader reader = commandCombo.ExecuteReader();
                categoryIdTable = new Hashtable();
                while (reader.Read())
                {
                    category.Items.Add(reader[1]);
                    //Add Id object to table with name as key
                    categoryIdTable.Add(reader[1], reader[0]);
                }
                //close reader
                reader.Close();
                //END LOAD COMBO -->

                //LOAD DATASET -->
                //create data set
                DataSet modelData = new DataSet();
                SqlCommand command = new SqlCommand();
                //Create Sql String with parameter @SelectedLP
                string sql = "Select Model.ModelId As ModelId, " +
                        "Model.Name as ModelName, " +
                        "Category.Name as CategoryName " +
                        "from Model Inner Join Category " +
                        "On Model.CategoryId = Category.CategoryId";
                //Set connection to command
                command.Connection = connection;
                //set Sql string to command object
                command.CommandText = sql;
                //execute command
                adapter.SelectCommand = command;
                //fill DataSet
                adapter.Fill(modelData);
                //close connection
                connection.Close();
                //destroy objects        
                models = modelData.Tables[0];
                if (models.Rows.Count > 0)
                {
                    DataRow row = models.Rows[0];
                    id.Text = row["ModelId"].ToString();
                    name.Text = row["ModelName"].ToString();
                    category.Text = row["CategoryName"].ToString();
                    currentRowIndex = 0;
                }
                //END LOAD DATASET -->
            }
            catch
            {
                MessageBox.Show("A problem occurred and the application cannot recover! " +
                "Please contact the technical support.");
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(
              "Data Source=TESLATEAM;" +
              "Initial Catalog=RENTAWHEELS;" +
              "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand command = new SqlCommand();
            //add parameter name
            string sql = "Delete Model " +
            "Where ModelId = @Id";
            command.Parameters.AddWithValue("@Id", Convert.ToInt16(id.Text));
            try
            {
                //open connection
                connection.Open();
                //Set connection to command
                command.Connection = connection;
                //set Sql string to command object
                command.CommandText = sql;
                //exexute command
                command.ExecuteNonQuery();
                //close connection
                connection.Close();
            }
            catch
            {
                MessageBox.Show("A problem occurred and the application cannot recover! " +
                "Please contact the technical support.");
            }
            ModelMaintenance_Load(null, null);
        }

        private void reload_Click(object sender, EventArgs e)
        {
            ModelMaintenance_Load(null, null);
        }


    }
}
