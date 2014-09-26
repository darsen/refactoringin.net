using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class FrmFleetView : Form
    {
        FrmBranch frmBranch = new FrmBranch();
        FrmCat frmCategory = new FrmCat();
        FrmModel frmModel = new FrmModel();
        FrmFlt frmFleet = new FrmFlt();
        FrmRt frmRent = new FrmRt();
        FrmRcv frmReceive = new FrmRcv();
        FrmChangeBranch frmChangeBranch = new FrmChangeBranch();

        //Maintain BranchId - BranchName relation
        Hashtable branchIdTable;
        //Maintain CategoryId - CategoryName relation
        Hashtable categoryIdTable;

        public FrmFleetView()
        {
            InitializeComponent();
        }

        private void branchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBranch.ShowDialog();
        }

        private void FrmFleetView_Load(object sender, EventArgs e)
        {
            SqlConnection oCn = new SqlConnection(
               "Data Source=TESLATEAM;" +
               "Initial Catalog=RENTAWHEELS;" +
               "User ID=RENTAWHEELS_LOGIN;" + 
               "Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand oCmdCombo = new SqlCommand();
            categoryIdTable = new Hashtable();
            branchIdTable = new Hashtable();
            //Create Sql String 
            string strSqlCombos = "Select * from Category " +
                "Select * from Branch";
            try
            {
                oCn.Open();
                //Set connection to command
                oCmdCombo.Connection = oCn;
                //set Sql string to command object
                oCmdCombo.CommandText = strSqlCombos;
                //execute command
                SqlDataReader oRd = oCmdCombo.ExecuteReader();
                //Fill Combo Categories
                while (oRd.Read())
                {
                    cboCategory.Items.Add(oRd[1]);
                    //Add Id object to table with name as key
                    categoryIdTable.Add(oRd[1], oRd[0]);
                }
                //Fill Combo Branches
                oRd.NextResult();
                while (oRd.Read())
                {
                    cboBranch.Items.Add(oRd[1]);
                    //Add Id object to table with name as key
                    branchIdTable.Add(oRd[1], oRd[0]);
                }

            }
            catch
            {
                MessageBox.Show("A problem occurred and the application cannot recover! " +
                "Please contact the technical support.");
            }
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            frmCategory.ShowDialog();
        }

        private void modelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModel.ShowDialog();
        }

        private void fleetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFleet.ShowDialog();
        }

        private void btnChangeBranch_Click(object sender, EventArgs e)
        {
            //Check that user has made a selection
            if (dGridFleetView.SelectedRows.Count > 0)
            {
                //Read value from first cell as Vehicle Id                
                string selectedLP =
                dGridFleetView.SelectedRows[0].
                Cells[0].Value.ToString();
                //set selectedLP as a value of TxtLP in FrmChangeBranch
                frmChangeBranch.txtLP.Text = selectedLP;
                frmChangeBranch.ShowDialog();
            }
            else
            {
                //Warn user if no selection made in table and exit
                MessageBox.Show("Please select vehicle first!");
            }            
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            //Check that user has made a selection
            if (dGridFleetView.SelectedRows.Count > 0)
            {
                //Read value from first cell as Vehicle Id                
                string selectedLP =
                dGridFleetView.SelectedRows[0].
                Cells[0].Value.ToString();
                frmRent.txtLP.Text = selectedLP;
                frmRent.ShowDialog();
            }
            else
            {
                //Warn user if no selection made in table and exit
                MessageBox.Show("Please select vehicle first!");
            }            
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            //Declare variables
            SqlConnection oCn = new SqlConnection(
             "Data Source=TESLATEAM;" +
             "Initial Catalog=RENTAWHEELS;" +
             "User ID=RENTAWHEELS_LOGIN;" + 
             "Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand oCmd = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            SqlDataReader oRd;
            string strSql;
            //clear grid
            this.dGridFleetView.Rows.Clear();
            //Create Sql String 
            strSql = "Select Vehicle.LicensePlate as LicensePlate," +
            "Category.Name as CategoryName," +
            "Vehicle.Available as Available," +
            "Vehicle.Operational as Operational," +
            "Model.Name as ModelName," +
            "Branch.Name as BranchName," +
            "Category.DailyPrice as DailyPrice," +
            "Category.WeeklyPrice as WeeklyPrice," +
            "Category.MonthlyPrice as MonthlyPrice," +
            "Vehicle.Mileage as Mileage," +
            "Vehicle.Tank as Tank," +
            "Vehicle.CustomerFirstName as FirstName," +
            "Vehicle.CustomerLastName as LastName," +
            "Vehicle.CustomerDocNumber as DocNumber," +
            "Vehicle.CustomerDocType as DocType " +
            "from Vehicle " +
            "Inner Join Model ON " +
            "Vehicle.ModelId = Model.ModelId " +
            "Inner Join Branch ON " +
            "Vehicle.BranchId = Branch.BranchId " +
            "Inner Join Category ON " +
            "Model.CategoryId = Category.CategoryId";
            if (cboAvailable.Text != "All" |
                cboBranch.Text != "All" |
                cboCategory.Text != "All" |
                cboOperational.Text != "All")
            {
                strSql += " Where ";
                if (cboAvailable.Text != "All")
                {
                    strSql += "Vehicle.Available = @Available And ";
                    int available = 0;
                    switch (cboAvailable.Text)
                    {
                        case "Available":
                            available = 0;
                            break;
                        case "Hand Over":
                            available = 1;
                            break;
                        case "Rented":
                            available = 2;
                            break;
                        case "Charge":
                            available = 3;
                            break;
                    }
                    oCmd.Parameters.AddWithValue(
                    "@Available", available);
                }
                if (cboBranch.Text != "All")
                {
                    strSql += "Vehicle.BranchId = @BranchId And ";
                    oCmd.Parameters.AddWithValue(
                        "@BranchId", this.branchIdTable[cboBranch.Text]);
                }
                if (cboCategory.Text != "All")
                {
                    strSql += "Model.CategoryId = @CategoryId And ";
                    oCmd.Parameters.AddWithValue("@CategoryId",
                        this.categoryIdTable[cboCategory.Text]);
                }
                if (cboOperational.Text != "All")
                {
                    strSql += "Vehicle.Operational = @Operational And ";
                    int operational = 0;
                    switch (cboOperational.Text)
                    {
                        case "In Operation":
                            operational = 0;
                            break;
                        case "In Maintenance":
                            operational = 1;
                            break;
                    }
                    oCmd.Parameters.AddWithValue(
                    "@Operational", operational);
                }
                strSql = strSql.Substring(0, strSql.Length - 5);
            }
            //open connection
            oCn.Open();
            //Set connection to command
            oCmd.Connection = oCn;
            //set Sql string to command object
            oCmd.CommandText = strSql;
            //execute command
            oRd = oCmd.ExecuteReader();
            //Fill Combo Categories
            while (oRd.Read())
            {
                string[] row = new string[]{
                    oRd["LicensePlate"].ToString(), 
                    oRd["CategoryName"].ToString(), 
                    availableText(Convert.ToInt16(oRd["Available"])), 
                    Convert.ToInt16(oRd["Operational"]).Equals(0) ?
                    "In Operation" : "In Maintenance", 
                    oRd["ModelName"].ToString(), 
                    oRd["BranchName"].ToString(), 
                    oRd["DailyPrice"].ToString(), 
                    oRd["WeeklyPrice"].ToString(), 
                    oRd["MonthlyPrice"].ToString(), 
                    oRd["Mileage"].ToString(),  
                    oRd["Tank"].ToString(),  
                    Convert.IsDBNull(oRd["FirstName"]) ? " ": oRd["FirstName"].ToString(),  
                    Convert.IsDBNull(oRd["LastName"]) ? " ": oRd["LastName"].ToString(),  
                    Convert.IsDBNull(oRd["DocNumber"]) ? " ": oRd["DocNumber"].ToString(), 
                    Convert.IsDBNull(oRd["DocType"]) ? " ": oRd["DocType"].ToString() 
                    };
                this.dGridFleetView.Rows.Add(row);
            }
            //close reader
            oRd.Close();
            oCn.Close();

        }

        private string availableText(int available)
        {
            string strAvailable = "";
            switch (available)
            {
                case 0:
                    strAvailable = "Available";
                    break;
                case 1:
                    strAvailable = "Hand Over";
                    break;
                case 2:
                    strAvailable = "Rented";
                    break;
                case 3:
                    strAvailable = "Charge";
                    break;
            }
            return strAvailable;
        }

        private void dGridFleetView_SelectionChanged(object sender, EventArgs e)
        {
            if (dGridFleetView.RowCount > 0 & dGridFleetView.SelectedRows.Count > 0)
            {
                string selectedAvailable =
                dGridFleetView.SelectedRows[0].Cells[2].Value.ToString();
                switch (selectedAvailable)
                {
                    case "Available":
                        btnRent.Enabled = true;
                        btnHandOver.Enabled = false;
                        btnReceive.Enabled = false;
                        btnCharge.Enabled = false;
                        break;
                    case "Hand Over":
                        btnRent.Enabled = false;
                        btnHandOver.Enabled = true;
                        btnReceive.Enabled = false;
                        btnCharge.Enabled = false;
                        break;
                    case "Rented":
                        btnRent.Enabled = false;
                        btnHandOver.Enabled = false;
                        btnReceive.Enabled = true;
                        btnCharge.Enabled = false;
                        break;
                    case "Charge":
                        btnRent.Enabled = false;
                        btnHandOver.Enabled = false;
                        btnReceive.Enabled = false;
                        btnCharge.Enabled = true;
                        break;
                }
            }
        }

        private void btnHandOver_Click(object sender, EventArgs e)
        {
            string selectedLP = null;
            if (MessageBox.Show("Are you sure?", "Confirm",
            MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //Check that user has made a selection
                if (dGridFleetView.SelectedRows.Count > 0)
                {
                    //Read value from first cell as Vehicle Id                
                    selectedLP =
                    dGridFleetView.SelectedRows[0].
                    Cells[0].Value.ToString();
                }
                else
                {
                    //Warn user if no selection made in table and exit
                    MessageBox.Show("Please select vehicle first!");
                }
                SqlConnection oCn = new SqlConnection(
                  "Data Source=TESLATEAM;" +
                  "Initial Catalog=RENTAWHEELS;" +
                  "User ID=RENTAWHEELS_LOGIN;" + 
                  "Password=RENTAWHEELS_PASSWORD_123");
                SqlCommand oCmd;
                string strSql = "Update Vehicle " +
                        "Set Available = 2 " +
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
                        "@SelectedLP", selectedLP);
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

        private void btnReceive_Click(object sender, EventArgs e)
        {   
            //Check that user has made a selection
            if (dGridFleetView.SelectedRows.Count > 0)
            {                
                //Read value from first cell as Vehicle Id                
                string selectedLP = 
                dGridFleetView.SelectedRows[0].
                Cells[0].Value.ToString();
                frmReceive.txtLP.Text = selectedLP;
                frmReceive.ShowDialog();
            }
            else
            {
                //Warn user if no selection made in table and exit
                MessageBox.Show("Please select vehicle first!");
            }
        }

        private void btnCharge_Click(object sender, EventArgs e)
        {
            string selectedLP = null;
            if (MessageBox.Show("Are you sure?", "Confirm",
            MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //Check that user has made a selection
                if (dGridFleetView.SelectedRows.Count > 0)
                {
                    //Read value from first cell as Vehicle Id                
                    selectedLP =
                    dGridFleetView.SelectedRows[0].
                    Cells[0].Value.ToString();
                }
                else
                {
                    //Warn user if no selection made in table and exit
                    MessageBox.Show("Please select vehicle first!");
                }
                SqlConnection oCn = new SqlConnection(
                  "Data Source=TESLATEAM;" +
                  "Initial Catalog=RENTAWHEELS;" +
                  "User ID=RENTAWHEELS_LOGIN;" +
                  "Password=RENTAWHEELS_PASSWORD_123");
                SqlCommand oCmd;
                string strSql = "Update Vehicle " +
                        "Set Available = 0, " +
                        "Mileage = 0," +
                        "Tank = 0, " +
                        "CustomerFirstName = ''," +
                        "CustomerLastName = ''," +
                        "CustomerDocNumber = ''," +
                        "CustomerDocType = '' " +
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
                        "@SelectedLP", selectedLP);
                    //exexute command
                    oCmd.ExecuteNonQuery();
                    //close connection
                    oCn.Close();
                }
                catch
                {
                    MessageBox.Show("A problem occurred and " +
                        "the application cannot recover! " +
                        "Please contact the technical support.");
                }
            }
        }

        private void btnToMaintenance_Click(object sender, EventArgs e)
        {
            string selectedLP = null;
            if (MessageBox.Show("Are you sure?", "Confirm",
            MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //Check that user has made a selection
                if (dGridFleetView.SelectedRows.Count > 0)
                {
                    //Read value from first cell as Vehicle Id                
                    selectedLP =
                    dGridFleetView.SelectedRows[0].
                    Cells[0].Value.ToString();
                }
                else
                {
                    //Warn user if no selection made in table and exit
                    MessageBox.Show("Please select vehicle first!");
                }
                SqlConnection oCn = new SqlConnection(
                  "Data Source=TESLATEAM;" +
                  "Initial Catalog=RENTAWHEELS;" +
                  "User ID=RENTAWHEELS_LOGIN;" +
                  "Password=RENTAWHEELS_PASSWORD_123");
                SqlCommand oCmd;
                string strSql = "Update Vehicle " +
                        "Set Operational = 1 " +
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
                        "@SelectedLP", selectedLP);
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

        private void btnFromMaintenance_Click(object sender, EventArgs e)
        {
            string selectedLP = null;
            if (MessageBox.Show("Are you sure?", "Confirm",
            MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //Check that user has made a selection
                if (dGridFleetView.SelectedRows.Count > 0)
                {
                    //Read value from first cell as Vehicle Id                
                    selectedLP =
                    dGridFleetView.SelectedRows[0].
                    Cells[0].Value.ToString();
                }
                else
                {
                    //Warn user if no selection made in table and exit
                    MessageBox.Show("Please select vehicle first!");
                }
                SqlConnection oCn = new SqlConnection(
                  "Data Source=TESLATEAM;" +
                  "Initial Catalog=RENTAWHEELS;" +
                  "User ID=RENTAWHEELS_LOGIN;" +
                  "Password=RENTAWHEELS_PASSWORD_123");
                SqlCommand oCmd;
                string strSql = "Update Vehicle " +
                        "Set Operational = 0 " +
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
                        "@SelectedLP", selectedLP);
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

        private void button1_Click(object sender, EventArgs e)
        {
            //Test SqlConnection
            SqlConnection oCn = new SqlConnection(
                 "Data Source=TESLATEAM;" +
                 "Initial Catalog=RENTAWHEELS;" +
                 "User ID=RENTAWHEELS_LOGIN;" +
                 "Password=RENTAWHEELS_PASSWORD_123");
            oCn.Open();
        }
    }
}
