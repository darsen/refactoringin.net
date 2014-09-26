using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class FrmModel : Form
    {
        private Hashtable categoryIdTable;
        private DataTable dtModel;
        private int currentRowIndex;

        public FrmModel()
        {
            InitializeComponent();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (dtModel.Rows.Count > currentRowIndex + 1)
            {
                currentRowIndex++;
                DataRow drRow = dtModel.Rows[currentRowIndex];
                txtId.Text = drRow["ModelId"].ToString();
                txtName.Text = drRow["ModelName"].ToString();
                cboCategory.Text = drRow["CategoryName"].ToString();
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (currentRowIndex - 1 >= 0 & dtModel.Rows.Count > 0)
            {
                currentRowIndex--;
                DataRow drRow = dtModel.Rows[currentRowIndex];
                txtId.Text = drRow["ModelId"].ToString();
                txtName.Text = drRow["ModelName"].ToString();
                cboCategory.Text = drRow["CategoryName"].ToString();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (dtModel.Rows.Count > 0)
            {
                currentRowIndex = 0;
                DataRow drRow = dtModel.Rows[currentRowIndex];
                txtId.Text = drRow["ModelId"].ToString();
                txtName.Text = drRow["ModelName"].ToString();
                cboCategory.Text = drRow["CategoryName"].ToString();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (dtModel.Rows.Count > 0)
            {
                currentRowIndex = dtModel.Rows.Count - 1;
                DataRow drRow = dtModel.Rows[currentRowIndex];
                txtId.Text = drRow["ModelId"].ToString();
                txtName.Text = drRow["ModelName"].ToString();
                cboCategory.Text = drRow["CategoryName"].ToString();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            cboCategory.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strSql;
            SqlConnection oCn = new SqlConnection(
               "Data Source=TESLATEAM;" +
               "Initial Catalog=RENTAWHEELS;" +
               "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand oCmd = new SqlCommand();
            if (txtId.Text.Equals(""))
            {
                //Create Sql String with parameter
                strSql = "Insert Into Model (Name,CategoryId) " +
                    "Values(@ModelName, @CategoryId)";
                //add parameters
                oCmd.Parameters.AddWithValue(
                    "@ModelName", txtName.Text);
                oCmd.Parameters.AddWithValue(
                    "@CategoryId", this.categoryIdTable[cboCategory.Text]);
            }
            else
            {
                //Create Sql String with parameter
                strSql = "Update Model  Set Name = @ModelName, " +
                "CategoryId = @CategoryId " +
                "Where ModelId = @ModelId";
                //add parameters
                oCmd.Parameters.AddWithValue(
                   "@ModelName", txtName.Text);
                oCmd.Parameters.AddWithValue(
                    "@CategoryId", this.categoryIdTable[cboCategory.Text]);
                oCmd.Parameters.AddWithValue("@ModelId", txtId.Text);
            }
            try
            {
                //open connection
                oCn.Open();
                //Set connection to command
                oCmd.Connection = oCn;
                //set Sql string to command object
                oCmd.CommandText = strSql;
                //exexute command
                oCmd.ExecuteNonQuery();
                //close connection
                oCn.Close();
            }
            catch
            {
                MessageBox.Show("A problem occurred and the application cannot recover! " +
                "Please contact the technical support.");
            }
            FrmModel_Load(null, null);
        }

        private void FrmModel_Load(object sender, EventArgs e)
        {
            SqlConnection oCn = new SqlConnection(
               "Data Source=TESLATEAM;" +
               "Initial Catalog=RENTAWHEELS;" +
               "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand oCmdCombo = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            //LOAD COMBO -->
            //Create Sql String             
            string strSqlCombo = "Select * from Category";
            try
            {
                //open connection
                oCn.Open();
                //Set connection to command
                oCmdCombo.Connection = oCn;
                //set Sql string to command object
                oCmdCombo.CommandText = strSqlCombo;
                //execute command
                SqlDataReader oReader = oCmdCombo.ExecuteReader();
                categoryIdTable = new Hashtable();
                while (oReader.Read())
                {
                    cboCategory.Items.Add(oReader[1]);
                    //Add Id object to table with name as key
                    categoryIdTable.Add(oReader[1], oReader[0]);
                }
                //close reader
                oReader.Close();
                //END LOAD COMBO -->

                //LOAD DATASET -->
                //create data set
                DataSet dsModel = new DataSet();
                SqlCommand oCmd = new SqlCommand();
                //Create Sql String with parameter @SelectedLP
                string strSql = "Select Model.ModelId As ModelId, " +
                        "Model.Name as ModelName, " +
                        "Category.Name as CategoryName " +
                        "from Model Inner Join Category " +
                        "On Model.CategoryId = Category.CategoryId";
                //Set connection to command
                oCmd.Connection = oCn;
                //set Sql string to command object
                oCmd.CommandText = strSql;
                //execute command
                oAdapter.SelectCommand = oCmd;
                //fill DataSet
                oAdapter.Fill(dsModel);
                //close connection
                oCn.Close();
                //destroy objects        
                dtModel = dsModel.Tables[0];
                if (dtModel.Rows.Count > 0)
                {
                    DataRow drRow = dtModel.Rows[0];
                    txtId.Text = drRow["ModelId"].ToString();
                    txtName.Text = drRow["ModelName"].ToString();
                    cboCategory.Text = drRow["CategoryName"].ToString();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection oCn = new SqlConnection(
              "Data Source=TESLATEAM;" +
              "Initial Catalog=RENTAWHEELS;" +
              "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand oCmd = new SqlCommand();
            //add parameter name
            string strSql = "Delete Model " +
            "Where ModelId = @Id";
            oCmd.Parameters.AddWithValue("@Id", Convert.ToInt16(txtId.Text));
            try
            {
                //open connection
                oCn.Open();
                //Set connection to command
                oCmd.Connection = oCn;
                //set Sql string to command object
                oCmd.CommandText = strSql;
                //exexute command
                oCmd.ExecuteNonQuery();
                //close connection
                oCn.Close();
            }
            catch
            {
                MessageBox.Show("A problem occurred and the application cannot recover! " +
                "Please contact the technical support.");
            }
            FrmModel_Load(null, null);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            FrmModel_Load(null, null);
        }


    }
}
