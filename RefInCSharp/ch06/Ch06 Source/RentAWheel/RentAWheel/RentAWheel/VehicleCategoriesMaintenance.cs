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
        private DataTable models;
        private int currentRowIndex;

        public VehicleCategoriesMaintenance()
        {
            InitializeComponent();
        }

        private void right_Click(object sender, EventArgs e)
        {
            if (models.Rows.Count > currentRowIndex + 1)
            {
                currentRowIndex++;
                DataRow row = models.Rows[currentRowIndex];
                id.Text = row["CategoryId"].ToString();
                name.Text = row["Name"].ToString();
                dailyPrice.Text = row["DailyPrice"].ToString();
                weeklyPrice.Text = row["WeeklyPrice"].ToString();
                monthlyPrice.Text = row["MonthlyPrice"].ToString();
            }
        }

        private void left_Click(object sender, EventArgs e)
        {
            if (currentRowIndex - 1 >= 0 & models.Rows.Count > 0)
            {
                currentRowIndex--;
                DataRow row = models.Rows[currentRowIndex];
                id.Text = row["CategoryId"].ToString();
                name.Text = row["Name"].ToString();
                dailyPrice.Text = row["DailyPrice"].ToString();
                weeklyPrice.Text = row["WeeklyPrice"].ToString();
                monthlyPrice.Text = row["MonthlyPrice"].ToString();
            }
        }

        private void first_Click(object sender, EventArgs e)
        {
            if (models.Rows.Count > 0)
            {
                currentRowIndex = 0;
                DataRow row = models.Rows[currentRowIndex];
                id.Text = row["CategoryId"].ToString();
                name.Text = row["Name"].ToString();
                dailyPrice.Text = row["DailyPrice"].ToString();
                weeklyPrice.Text = row["WeeklyPrice"].ToString();
                monthlyPrice.Text = row["MonthlyPrice"].ToString();
            }
        }

        private void last_Click(object sender, EventArgs e)
        {
            if (models.Rows.Count > 0)
            {
                currentRowIndex = models.Rows.Count - 1;
                DataRow row = models.Rows[currentRowIndex];
                id.Text = row["CategoryId"].ToString();
                name.Text = row["Name"].ToString();
                dailyPrice.Text = row["DailyPrice"].ToString();
                weeklyPrice.Text = row["WeeklyPrice"].ToString();
                monthlyPrice.Text = row["MonthlyPrice"].ToString();
            }
        }


        private void new_Click(object sender, EventArgs e)
        {
            id.Text = "";
            name.Text = "";
            dailyPrice.Text = "";
            weeklyPrice.Text = "";
            monthlyPrice.Text = "";
        }

        private void VehicleCategoriesMaintenance_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(
               "Data Source=TESLATEAM;" +
               "Initial Catalog=RENTAWHEELS;" +
               "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand command = new SqlCommand();
            DataSet branchData = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            //Create Sql String 
            string sql = "Select * from Category";
            try
            {
                connection.Open();
                //Set connection to command
                command.Connection = connection;
                //set Sql string to command object
                command.CommandText = sql;
                //execute command
                adapter.SelectCommand = command;
                //fill DataSet
                adapter.Fill(branchData);
                //close connection
                connection.Close();
                models = branchData.Tables[0];
                if (models.Rows.Count > 0)
                {
                    currentRowIndex = 0;
                    DataRow row = models.Rows[currentRowIndex];
                    id.Text = row["CategoryId"].ToString();
                    name.Text = row["Name"].ToString();
                    dailyPrice.Text = row["DailyPrice"].ToString();
                    weeklyPrice.Text = row["WeeklyPrice"].ToString();
                    monthlyPrice.Text = row["MonthlyPrice"].ToString();

                }
            }
            catch
            {
                MessageBox.Show("A problem occurred and the application cannot recover! " +
                "Please contact the technical support.");
            }
        }

        private void reload_Click(object sender, EventArgs e)
        {
            VehicleCategoriesMaintenance_Load(null, null);
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
                //Create Sql String with parameters
                sql = "Insert Into Category " +
                "(Name, MonthlyPrice, DailyPrice, WeeklyPrice) " +
                "Values(@Name,@MonthlyPrice, " +
                "@DailyPrice, @WeeklyPrice)";
                //add parameters
                command.Parameters.AddWithValue("@Name", name.Text);
                command.Parameters.AddWithValue(
                    "@DailyPrice", Convert.ToDecimal(dailyPrice.Text));
                command.Parameters.AddWithValue(
                "@WeeklyPrice", Convert.ToDecimal(weeklyPrice.Text));
                command.Parameters.AddWithValue(
                "@MonthlyPrice", Convert.ToDecimal(monthlyPrice.Text));
            }
            else
            {
                //Create Sql String with parameter @SelectedLP
                sql = "Update Category  Set Name = @Name, " +
                "DailyPrice = @DailyPrice, " +
                "WeeklyPrice = @WeeklyPrice, " +
                "MonthlyPrice = @MonthlyPrice " +
                "Where CategoryId = @CategoryId";
                //add parameters
                command.Parameters.AddWithValue("@Name", name.Text);
                command.Parameters.AddWithValue(
                    "@DailyPrice", Convert.ToDecimal(dailyPrice.Text));
                command.Parameters.AddWithValue(
                    "@WeeklyPrice", Convert.ToDecimal(weeklyPrice.Text));
                command.Parameters.AddWithValue(
                    "@MonthlyPrice", Convert.ToDecimal(monthlyPrice.Text));
                command.Parameters.AddWithValue("@CategoryId",
                    Convert.ToInt16(id.Text));
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
            VehicleCategoriesMaintenance_Load(null, null);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(
             "Data Source=TESLATEAM;" +
             "Initial Catalog=RENTAWHEELS;" +
             "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand command = new SqlCommand();
            //add parameter name
            string sql = "Delete Category " +
            "Where CategoryId = @Id";
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
            VehicleCategoriesMaintenance_Load(null, null);
        }




    }
}
