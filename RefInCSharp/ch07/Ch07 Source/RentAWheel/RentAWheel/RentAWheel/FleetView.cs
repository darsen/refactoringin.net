using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class FleetView : Form
    {
        BranchMaintenance branchMaintenance = new BranchMaintenance();
        VehicleCategoriesMaintenance categoryMaintenance = new VehicleCategoriesMaintenance();
        ModelMaintenance modelMaintenance = new ModelMaintenance();
        FleetMaintenance fleetMaintenance = new FleetMaintenance();
        VehicleRental vehicleRental = new VehicleRental();
        VehicleReception vehicleReception = new VehicleReception();
        VehicleChangeBranch changeBranchForm = new VehicleChangeBranch();

        //Maintain BranchId - BranchName relation
        Hashtable branchIdTable;
        //Maintain CategoryId - CategoryName relation
        Hashtable categoryIdTable;

        public FleetView()
        {
            InitializeComponent();
        }

        private void branchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            branchMaintenance.ShowDialog();
        }

        private void FleetView_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(
               "Data Source=TESLATEAM;" +
               "Initial Catalog=RENTAWHEELS;" +
               "User ID=RENTAWHEELS_LOGIN;" + 
               "Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand commandCombo = new SqlCommand();
            categoryIdTable = new Hashtable();
            branchIdTable = new Hashtable();
            //Create Sql String 
            string sqlCombos = "Select * from Category " +
                "Select * from Branch";
            try
            {
                connection.Open();
                //Set connection to command
                commandCombo.Connection = connection;
                //set Sql string to command object
                commandCombo.CommandText = sqlCombos;
                //execute command
                SqlDataReader reader = commandCombo.ExecuteReader();
                //Fill Combo Categories
                while (reader.Read())
                {
                    cboCategory.Items.Add(reader[1]);
                    //Add Id object to table with name as key
                    categoryIdTable.Add(reader[1], reader[0]);
                }
                //Fill Combo Branches
                reader.NextResult();
                while (reader.Read())
                {
                    cboBranch.Items.Add(reader[1]);
                    //Add Id object to table with name as key
                    branchIdTable.Add(reader[1], reader[0]);
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
            categoryMaintenance.ShowDialog();
        }

        private void modelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modelMaintenance.ShowDialog();
        }

        private void fleetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fleetMaintenance.ShowDialog();
        }

        private void changeBranch_Click(object sender, EventArgs e)
        {
            //Check that user has made a selection
            if (feetViewGrid.SelectedRows.Count > 0)
            {
                //Read value from first cell as Vehicle Id                
                string selectedLicensePlate =
                feetViewGrid.SelectedRows[0].
                Cells[0].Value.ToString();
                changeBranchForm.licensePlate.Text = selectedLicensePlate;
                changeBranchForm.ShowDialog();
            }
            else
            {
                //Warn user if no selection made in table and exit
                MessageBox.Show("Please select vehicle first!");
            }            
        }

        private void rent_Click(object sender, EventArgs e)
        {
            //Check that user has made a selection
            if (feetViewGrid.SelectedRows.Count > 0)
            {
                //Read value from first cell as Vehicle Id                
                string selectedLicensePlate =
                feetViewGrid.SelectedRows[0].
                Cells[0].Value.ToString();
                vehicleRental.licensePlate.Text = selectedLicensePlate;
                vehicleRental.ShowDialog();
            }
            else
            {
                //Warn user if no selection made in table and exit
                MessageBox.Show("Please select vehicle first!");
            }            
        }

        private void display_Click(object sender, EventArgs e)
        {
            //Declare variables
            SqlConnection connection = new SqlConnection(
             "Data Source=TESLATEAM;" +
             "Initial Catalog=RENTAWHEELS;" +
             "User ID=RENTAWHEELS_LOGIN;" + 
             "Password=RENTAWHEELS_PASSWORD_123");
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlDataReader reader;
            string sql;
            //clear grid
            this.feetViewGrid.Rows.Clear();
            //Create Sql String 
            sql = "Select Vehicle.LicensePlate as LicensePlate," +
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
                sql += " Where ";
                if (cboAvailable.Text != "All")
                {
                    sql += "Vehicle.Available = @Available And ";
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
                    command.Parameters.AddWithValue(
                    "@Available", available);
                }
                if (cboBranch.Text != "All")
                {
                    sql += "Vehicle.BranchId = @BranchId And ";
                    command.Parameters.AddWithValue(
                        "@BranchId", this.branchIdTable[cboBranch.Text]);
                }
                if (cboCategory.Text != "All")
                {
                    sql += "Model.CategoryId = @CategoryId And ";
                    command.Parameters.AddWithValue("@CategoryId",
                        this.categoryIdTable[cboCategory.Text]);
                }
                if (cboOperational.Text != "All")
                {
                    sql += "Vehicle.Operational = @Operational And ";
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
                    command.Parameters.AddWithValue(
                    "@Operational", operational);
                }
                sql = sql.Substring(0, sql.Length - 5);
            }
            //open connection
            connection.Open();
            //Set connection to command
            command.Connection = connection;
            //set Sql string to command object
            command.CommandText = sql;
            //execute command
            reader = command.ExecuteReader();
            //Fill Combo Categories
            while (reader.Read())
            {
                string[] row = new string[]{
                    reader["LicensePlate"].ToString(), 
                    reader["CategoryName"].ToString(), 
                    availableText(Convert.ToInt16(reader["Available"])), 
                    Convert.ToInt16(reader["Operational"]).Equals(0) ?
                    "In Operation" : "In Maintenance", 
                    reader["ModelName"].ToString(), 
                    reader["BranchName"].ToString(), 
                    reader["DailyPrice"].ToString(), 
                    reader["WeeklyPrice"].ToString(), 
                    reader["MonthlyPrice"].ToString(), 
                    reader["Mileage"].ToString(),  
                    reader["Tank"].ToString(),  
                    Convert.IsDBNull(reader["FirstName"]) ? " ": reader["FirstName"].ToString(),  
                    Convert.IsDBNull(reader["LastName"]) ? " ": reader["LastName"].ToString(),  
                    Convert.IsDBNull(reader["DocNumber"]) ? " ": reader["DocNumber"].ToString(), 
                    Convert.IsDBNull(reader["DocType"]) ? " ": reader["DocType"].ToString() 
                    };
                this.feetViewGrid.Rows.Add(row);
            }
            //close reader
            reader.Close();
            connection.Close();

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

        private void gridFleetView_SelectionChanged(object sender, EventArgs e)
        {
            if (feetViewGrid.RowCount > 0 & feetViewGrid.SelectedRows.Count > 0)
            {
                string selectedAvailable =
                feetViewGrid.SelectedRows[0].Cells[2].Value.ToString();
                switch (selectedAvailable)
                {
                    case "Available":
                        rent.Enabled = true;
                        handOver.Enabled = false;
                        receive.Enabled = false;
                        charge.Enabled = false;
                        break;
                    case "Hand Over":
                        rent.Enabled = false;
                        handOver.Enabled = true;
                        receive.Enabled = false;
                        charge.Enabled = false;
                        break;
                    case "Rented":
                        rent.Enabled = false;
                        handOver.Enabled = false;
                        receive.Enabled = true;
                        charge.Enabled = false;
                        break;
                    case "Charge":
                        rent.Enabled = false;
                        handOver.Enabled = false;
                        receive.Enabled = false;
                        charge.Enabled = true;
                        break;
                }
            }
        }

        private void handOver_Click(object sender, EventArgs e)
        {
            string selectedLicensePlate = null;
            if (MessageBox.Show("Are you sure?", "Confirm",
            MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //Check that user has made a selection
                if (feetViewGrid.SelectedRows.Count > 0)
                {
                    //Read value from first cell as Vehicle Id                
                    selectedLicensePlate =
                    feetViewGrid.SelectedRows[0].
                    Cells[0].Value.ToString();
                }
                else
                {
                    //Warn user if no selection made in table and exit
                    MessageBox.Show("Please select vehicle first!");
                }
                SqlConnection connection = new SqlConnection(
                  "Data Source=TESLATEAM;" +
                  "Initial Catalog=RENTAWHEELS;" +
                  "User ID=RENTAWHEELS_LOGIN;" + 
                  "Password=RENTAWHEELS_PASSWORD_123");
                SqlCommand command;
                string sql = "Update Vehicle " +
                        "Set Available = 2 " +
                        "WHERE LicensePlate = @SelectedLP";
                command = new SqlCommand();
                try
                {//open connection
                    connection.Open();
                    //Set connection to command
                    command.Connection = connection;
                    //set Sql string to command object
                    command.CommandText = sql;
                    //Add parameter to command          
                    command.Parameters.AddWithValue(
                        "@SelectedLP", selectedLicensePlate);
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
            }
        }

        private void receive_Click(object sender, EventArgs e)
        {   
            //Check that user has made a selection
            if (feetViewGrid.SelectedRows.Count > 0)
            {                
                //Read value from first cell as Vehicle Id                
                string selectedLicensePlate = 
                feetViewGrid.SelectedRows[0].
                Cells[0].Value.ToString();
                vehicleReception.licensePlate.Text = selectedLicensePlate;
                vehicleReception.ShowDialog();
            }
            else
            {
                //Warn user if no selection made in table and exit
                MessageBox.Show("Please select vehicle first!");
            }
        }

        private void charge_Click(object sender, EventArgs e)
        {
            string selectedLicensePlate = null;
            if (MessageBox.Show("Are you sure?", "Confirm",
            MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //Check that user has made a selection
                if (feetViewGrid.SelectedRows.Count > 0)
                {
                    //Read value from first cell as Vehicle Id                
                    selectedLicensePlate =
                    feetViewGrid.SelectedRows[0].
                    Cells[0].Value.ToString();
                }
                else
                {
                    //Warn user if no selection made in table and exit
                    MessageBox.Show("Please select vehicle first!");
                }
                SqlConnection connection = new SqlConnection(
                  "Data Source=TESLATEAM;" +
                  "Initial Catalog=RENTAWHEELS;" +
                  "User ID=RENTAWHEELS_LOGIN;" +
                  "Password=RENTAWHEELS_PASSWORD_123");
                SqlCommand command;
                string sql = "Update Vehicle " +
                        "Set Available = 0, " +
                        "Mileage = 0," +
                        "Tank = 0, " +
                        "CustomerFirstName = ''," +
                        "CustomerLastName = ''," +
                        "CustomerDocNumber = ''," +
                        "CustomerDocType = '' " +
                        "WHERE LicensePlate = @SelectedLP";
                command = new SqlCommand();
                try
                {//open connection
                    connection.Open();
                    //Set connection to command
                    command.Connection = connection;
                    //set Sql string to command object
                    command.CommandText = sql;
                    //Add parameter to command          
                    command.Parameters.AddWithValue(
                        "@SelectedLP", selectedLicensePlate);
                    //exexute command
                    command.ExecuteNonQuery();
                    //close connection
                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("A problem occurred and " +
                        "the application cannot recover! " +
                        "Please contact the technical support.");
                }
            }
        }

        private void toMaintenance_Click(object sender, EventArgs e)
        {
            string selectedLicensePlate = null;
            if (MessageBox.Show("Are you sure?", "Confirm",
            MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //Check that user has made a selection
                if (feetViewGrid.SelectedRows.Count > 0)
                {
                    //Read value from first cell as Vehicle Id                
                    selectedLicensePlate =
                    feetViewGrid.SelectedRows[0].
                    Cells[0].Value.ToString();
                    SqlConnection connection = new SqlConnection(
                    "Data Source=TESLATEAM;" +
                    "Initial Catalog=RENTAWHEELS;" +
                    "User ID=RENTAWHEELS_LOGIN;" +
                    "Password=RENTAWHEELS_PASSWORD_123");
                    SqlCommand command;
                    string sql = "Update Vehicle " +
                            "Set Operational = 1 " +
                            "WHERE LicensePlate = @SelectedLP";
                    command = new SqlCommand();
                    try
                    {//open connection
                        connection.Open();
                        //Set connection to command
                        command.Connection = connection;
                        //set Sql string to command object
                        command.CommandText = sql;
                        //Add parameter to command          
                        command.Parameters.AddWithValue(
                            "@SelectedLP", selectedLicensePlate);
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
                }
                else
                {
                    //Warn user if no selection made in table and exit
                    MessageBox.Show("Please select vehicle first!");
                }
            }
        }

        private void fromMaintenance_Click(object sender, EventArgs e)
        {
            string selectedLicensePlate = null;
            if (MessageBox.Show("Are you sure?", "Confirm",
            MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //Check that user has made a selection
                if (feetViewGrid.SelectedRows.Count > 0)
                {
                    //Read value from first cell as Vehicle Id                
                    selectedLicensePlate =
                    feetViewGrid.SelectedRows[0].
                    Cells[0].Value.ToString();
                }
                else
                {
                    //Warn user if no selection made in table and exit
                    MessageBox.Show("Please select vehicle first!");
                }
                SqlConnection connection = new SqlConnection(
                  "Data Source=TESLATEAM;" +
                  "Initial Catalog=RENTAWHEELS;" +
                  "User ID=RENTAWHEELS_LOGIN;" +
                  "Password=RENTAWHEELS_PASSWORD_123");
                SqlCommand command;
                string sql = "Update Vehicle " +
                        "Set Operational = 0 " +
                        "WHERE LicensePlate = @SelectedLP";
                command = new SqlCommand();
                try
                {//open connection
                    connection.Open();
                    //Set connection to command
                    command.Connection = connection;
                    //set Sql string to command object
                    command.CommandText = sql;
                    //Add parameter to command          
                    command.Parameters.AddWithValue(
                        "@SelectedLP", selectedLicensePlate);
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
            }
        }

    }
}
