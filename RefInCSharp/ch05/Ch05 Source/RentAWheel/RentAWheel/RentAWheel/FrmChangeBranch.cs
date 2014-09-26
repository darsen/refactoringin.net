using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class FrmChangeBranch : Form
    {
        //Maintain BranchId - BranchName relation
        private Hashtable branchIdTable;
        public FrmChangeBranch()
        {
            InitializeComponent();
        }



        private void TxtCurrentBranch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnChangeBranch_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm",
            MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SqlConnection oCn = new SqlConnection(
                  "Data Source=TESLATEAM;" +
                  "Initial Catalog=RENTAWHEELS;" +
                  "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123");
                SqlCommand oCmd;
                string strSql = "Update Vehicle " +
                        "Set BranchId = @BranchId " +
                        "WHERE LicensePlate = @SelectedLP";
                oCmd = new SqlCommand();
                try
                {   //open connection
                    oCn.Open();
                    //Set connection to command
                    oCmd.Connection = oCn;
                    //set Sql string to command object
                    oCmd.CommandText = strSql;
                    //Add parameter to command
                    oCmd.Parameters.AddWithValue(
                       "@BranchId", branchIdTable[cboBranch.Text]);
                    oCmd.Parameters.AddWithValue(
                        "@SelectedLP", txtLP.Text);
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
            }
        }

        private void FrmChangeBranch_Load(object sender, EventArgs e)
        {
            branchIdTable = new Hashtable();
            SqlConnection oCn = new SqlConnection(
                "Data Source=TESLATEAM;" +
                "Initial Catalog=RENTAWHEELS;" +
                "User ID=RENTAWHEELS_LOGIN;" +
                "Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand oCmd;
            string strSql = "Select * from Branch";
            oCmd = new SqlCommand();
            SqlDataReader oReader;
            try
            {//open connection
                oCn.Open();
                //Set connection to command
                oCmd.Connection = oCn;
                //set Sql string to command object
                oCmd.CommandText = strSql;
                oReader = oCmd.ExecuteReader();
                while (oReader.Read())
                {
                    cboBranch.Items.Add(oReader[1]);
                    //Add Id object to table with name as key
                    branchIdTable.Add(oReader[1], oReader[0]);
                }
                cboBranch.SelectedIndex = 0;
                //close reader
                oReader.Close();
                //close connection
                oCn.Close();
            }
            catch
            {
                MessageBox.Show("A problem occurred and the application cannot recover! " +
                "Please contact the technical support.");
            }
        }
    }
}
