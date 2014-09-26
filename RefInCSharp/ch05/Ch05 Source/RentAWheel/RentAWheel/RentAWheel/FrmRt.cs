using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class FrmRt : Form
    {
        public FrmRt()
        {
            InitializeComponent();
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

private void btnRent_Click(object sender, EventArgs e)
{
    if (MessageBox.Show("Are you sure?", "Confirm",
    MessageBoxButtons.OKCancel) == DialogResult.OK)
    {
        SqlConnection oCn = new SqlConnection(
          "Data Source=TESLATEAM;" +
          "Initial Catalog=RENTAWHEELS;" +
          "User ID=RENTAWHEELS_LOGIN;" +
          "Password=RENTAWHEELS_PASSWORD_123");
        SqlCommand oCmd;
        string strSql = "Update Vehicle " +
                    "Set Available = 1," +
                    "CustomerFirstName = @CustomerFirstName," +
                    "CustomerLastName = @CustomerLastName," +
                    "CustomerDocNumber = @CustomerDocNumber," +
                    "CustomerDocType = @CustomerDocType " +
                    "WHERE LicensePlate = @SelectedLP";
        oCmd = new SqlCommand();
        try
        {//open connection
            oCn.Open();
            //Set connection to command
            oCmd.Connection = oCn;
            //set Sql string to command object
            oCmd.CommandText = strSql;
            //Add parameter to command
            oCmd.Parameters.AddWithValue(
                "@CustomerFirstName", txtFirstName.Text);
            oCmd.Parameters.AddWithValue(
                "@CustomerLastName", txtLastName.Text);
            oCmd.Parameters.AddWithValue(
                "@CustomerDocNumber", txtDocumentNo.Text);
            oCmd.Parameters.AddWithValue(
                "@CustomerDocType", txtDocumentType.Text);
            oCmd.Parameters.AddWithValue(
                "@SelectedLP", txtLP.Text);
            //exexute command
            oCmd.ExecuteNonQuery();
            //close connection
            oCn.Close();
        }
        catch
        {
            MessageBox.Show("A problem occurred" + 
            "and the application cannot recover! " +
            "Please contact the technical support.");
        }
        this.Close();
    }

}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmRt_Load(object sender, EventArgs e)
        {

        }
    }
}
