using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class FrmBranch : Form
    {
        private DataTable dtBranch;
        private int currentRowIndex;

        public FrmBranch()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
        }

        private void FrmBranch_Load(object sender, EventArgs e)
        {
            SqlConnection oCn = new SqlConnection(
                "Data Source=TESLATEAM;" +
                "Initial Catalog=RENTAWHEELS;" +
                "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand oCmd = new SqlCommand();
            DataSet dsBranch = new DataSet();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            //Create Sql String 
            string strSql = "Select * from Branch";
            try
            {
                oCn.Open();
                //Set connection to command
                oCmd.Connection = oCn;
                //set Sql string to command object
                oCmd.CommandText = strSql;
                //execute command
                oAdapter.SelectCommand = oCmd;
                //fill DataSet
                oAdapter.Fill(dsBranch);
                //close connection
                oCn.Close();
                dtBranch = dsBranch.Tables[0];
                if (dtBranch.Rows.Count > 0)
                {
                    currentRowIndex = 0;
                    DataRow drRow = dtBranch.Rows[currentRowIndex];
                    txtId.Text = drRow["BranchId"].ToString();
                    txtName.Text = drRow["Name"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("A problem occurred and the application cannot recover! " +
                "Please contact the technical support.");
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (dtBranch.Rows.Count > currentRowIndex + 1)
            {
                currentRowIndex++;
                DataRow drRow = dtBranch.Rows[currentRowIndex];
                txtId.Text = drRow["BranchId"].ToString();
                txtName.Text = drRow["Name"].ToString();
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (currentRowIndex - 1 >= 0 & dtBranch.Rows.Count > 0)
            {
                currentRowIndex--;
                DataRow drRow = dtBranch.Rows[currentRowIndex];
                txtId.Text = drRow["BranchId"].ToString();
                txtName.Text = drRow["Name"].ToString();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (dtBranch.Rows.Count > 0)
            {
                currentRowIndex = 0;
                DataRow drRow = dtBranch.Rows[currentRowIndex];
                txtId.Text = drRow["BranchId"].ToString();
                txtName.Text = drRow["Name"].ToString();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (dtBranch.Rows.Count > 0)
            {
                currentRowIndex = dtBranch.Rows.Count - 1;
                DataRow drRow = dtBranch.Rows[currentRowIndex];
                txtId.Text = drRow["BranchId"].ToString();
                txtName.Text = drRow["Name"].ToString();
            }
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
                //Create Sql String with parameter @SelectedLP
                strSql = "Insert Into Branch (Name) " +
                "Values(@Name)";
                //add parameter name
                oCmd.Parameters.AddWithValue("@Name", txtName.Text);
            }
            else
            {
                //Create Sql String with parameter @SelectedLP
                strSql = "Update Branch  Set Name = @Name " +
                "Where BranchId = @Id";
                //add parameter name
                oCmd.Parameters.AddWithValue("@Name", txtName.Text);
                //add parameter Id
                oCmd.Parameters.AddWithValue("@Id", Convert.ToInt16(txtId.Text));
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
            FrmBranch_Load(null, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection oCn = new SqlConnection(
              "Data Source=TESLATEAM;" +
              "Initial Catalog=RENTAWHEELS;" +
              "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand oCmd = new SqlCommand();
            //add parameter name
            string strSql = "Delete Branch " +
            "Where BranchId = @Id";
            oCmd.Parameters.AddWithValue(
                "@Id", Convert.ToInt16(txtId.Text));
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
            FrmBranch_Load(null, null);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            FrmBranch_Load(null, null);
        }
    }
}

