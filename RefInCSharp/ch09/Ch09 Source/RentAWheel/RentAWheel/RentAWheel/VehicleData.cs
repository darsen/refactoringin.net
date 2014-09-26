using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RentAWheel
{
    class VehicleData
    {

        private const String connectionString = "Data Source=TESLATEAM;" +
        "Initial Catalog=RENTAWHEELS;" +
        "User ID=RENTAWHEELS_LOGIN;Password=RENTAWHEELS_PASSWORD_123";

        private const string selectAllFromBranchSql = "Select * from Branch";
        private const string selectAllFromModelSql = "Select * from Model";
        private const string deleteVehicleSql = "Delete From Vehicle Where LicensePlate = @LicensePlate";
        private const string insertVehicleSql = "Insert Into Vehicle (LicensePlate, ModelId,BranchId, Tank, Mileage) Values(@LicensePlate, @ModelId, @BranchId, @Tank, @Mileage)";
        private const string updateVehicleSql = "Update Vehicle Set ModelId = @ModelId, BranchId = @BranchId,  Available = @Available, Operational = @Operational, Mileage = @Mileage, Tank = @Tank, CustomerFirstName = @CustomerFirstName, CustomerLastName = @CustomerLastName, CustomerDocNumber = @CustomerDocNumber, CustomerDocType = @CustomerDocType Where LicensePlate = @LicensePlate";

        private const string licensePlateParameterName = "@LicensePlate";
        private const string modelIdParameterName = "@ModelId";
        private const string branchIdParameterName = "@BranchId";

        private const string availableParameterName = "@Available";
        private const string operationalParameterName = "@Operational";
        private const string mileageParameterName = "@Mileage";
        private const string tankParameterName = "@Tank";
        private const string customerFirstNameParameterName = "@CustomerFirstName";
        private const string customerLastNameParameterName = "@CustomerLastName";
        private const string customerDocNumberParameterName = "@CustomerDocNumber";
        private const string customerDocTypeParameterName = "@CustomerDocType";
        private const string categoryIdParameterName = "@CategoryId";

        private const string vehicleTableLicensePlateColumnName = "LicensePlate";
        private const string vehicleTableTankLevelColumnName = "Tank";
        private const string vehicleTableMileageColumnName = "Mileage";
        private const string vehicleTableRentalState  = "Available";
        private const string vehicleTableOperational = "Operational";

        private const string branchTableNameColumnName = "BranchName";
        private const string modelTableNameColumnName = "ModelName";
        private const string customerFirstName = "CustomerFirstName";
        private const string customerLastName = "CustomerLastName";
        private const string customerDocNumber = "CustomerDocNumber";
        private const string customerDocType = "CustomerDocType";

        //private const string selectVehicleJoinBranchJoinModelJoinCategorySql = "Select Vehicle.LicensePlate AS LicensePlate, Vehicle.Tank as TankLevel, Vehicle.Mileage as Mileage, Branch.BranchId as BranchId, Branch.Name as BranchName, Model.ModelId As ModelId, Model.Name as ModelName, Category.CategoryId as CategoryId, Category.Name as CategoryName, Category.DailyPrice as DailyPrice, Category.WeeklyPrice as WeeklyPrice, Category.MonthlyPrice as MonthlyPrice from Vehicle Inner Join Branch On Vehicle.BranchId = Branch.BranchId Inner Join Model On Vehicle.ModelId = Model.ModelId Inner Join Category on Model.CategoryId = Category.CategoryId";

        private const string selectVehicleJoinBranchJoinModelJoinCategorySql = "Select * from Vehicle Inner Join Branch On Vehicle.BranchId = Branch.BranchId Inner Join Model On Vehicle.ModelId = Model.ModelId Inner Join Category on Model.CategoryId = Category.CategoryId";

        private const int singleTableInDatasetIndex = 0;

        public IList<Vehicle> GetAll()
        {
            IDbCommand command = new SqlCommand();
            DataSet vehiclesSet = FillDataset(command, selectVehicleJoinBranchJoinModelJoinCategorySql);
            DataTable vehiclesTable = vehiclesSet.Tables[singleTableInDatasetIndex];
            return VehiclesFromTable(vehiclesTable);
        }

        private static IList<Vehicle> VehiclesFromTable(DataTable vehiclesTable)
        {
            IList<Vehicle> vehicles = new List<Vehicle>();
            foreach (DataRow row in vehiclesTable.Rows)
            {   
                Vehicle vehicle =  new Vehicle(
                            row[vehicleTableLicensePlateColumnName].ToString(),
                            ModelData.ModelFromRow(row),
                            BranchData.BranchFromRow(row),
                            Convert.IsDBNull(row[vehicleTableTankLevelColumnName]) ? 0 : (TankLevel)Convert.ToInt32(row[vehicleTableTankLevelColumnName]),
                            Convert.IsDBNull(row[vehicleTableMileageColumnName]) ? 0 : Convert.ToInt32(row[vehicleTableMileageColumnName]),
                            CustomerFromRow(row)
                            );
                vehicle.Operational = Convert.IsDBNull(row[vehicleTableOperational]) ? 0 : (Operational)Convert.ToInt32(row[vehicleTableOperational]);
                vehicle.RentalState = Convert.IsDBNull(row[vehicleTableRentalState]) ? 0 : (RentalState)Convert.ToInt32(row[vehicleTableRentalState]);
                vehicles.Add(vehicle);
            }
            return vehicles;
        }

        public void Delete(Vehicle vehicle) {
            IDbCommand command = new SqlCommand();
            AddParameter(command, licensePlateParameterName,
                DbType.String, vehicle.LicensePlate);
            ExecuteNonQuery(command, deleteVehicleSql);        
        }

        public void InsertOrUpdate(Vehicle vehicle)
        {
            IDbConnection connection = new SqlConnection(connectionString);
            IDbCommand deleteCommand = new SqlCommand();
            IDbCommand insertCommand = new SqlCommand();
            AddParameter(deleteCommand, licensePlateParameterName,
                DbType.String, vehicle.LicensePlate);
            AddParameter(insertCommand, licensePlateParameterName,
                DbType.String, vehicle.LicensePlate);
            AddParameter(insertCommand, modelIdParameterName,
                DbType.Int32, vehicle.Model.Id);
            AddParameter(insertCommand, branchIdParameterName,
                DbType.Int32, vehicle.Branch.Id);
            connection.Open();
            IDbTransaction transaction = connection.BeginTransaction();
            deleteCommand.Transaction = transaction;
            insertCommand.Transaction = transaction;
            ExecuteNonQueryTransactional(connection, deleteCommand, deleteVehicleSql);
            ExecuteNonQueryTransactional(connection, insertCommand, insertVehicleSql);
            transaction.Commit();
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

        private void ExecuteNonQueryTransactional(IDbConnection connection,
            IDbCommand command, string sql)
        {
            connection = PrepareDataObjectsTransactional(connection, command, sql);
            command.ExecuteNonQuery();
        }

        private IDbConnection PrepareDataObjectsTransactional(IDbConnection connection,
            IDbCommand command, string sql)
        {
            command.Connection = connection;
            command.CommandText = sql;
            return connection;
        }

        public IList<Vehicle> GetByCriteria(Nullable<Operational> operational, Nullable<RentalState> rentalState, Nullable<Int32> branchId, Nullable<Int32> categoryId)
        {
            if ((operational == null & rentalState == null & branchId == null & categoryId == null))
            {
                return this.GetAll();
            }
            IDbCommand command = new SqlCommand();
            string sql = selectVehicleJoinBranchJoinModelJoinCategorySql + " WHERE ";
            if (rentalState != null)
            {
                sql += "Vehicle.Available = @Available And ";
                AddParameter(command, availableParameterName, DbType.Int32, rentalState);
            }
            if (branchId != null)
            {
                sql += "Vehicle.BranchId = @BranchId And ";
                AddParameter(command, branchIdParameterName, DbType.String, branchId);
            }
            if (categoryId != null)
            {
                sql += "Model.CategoryId = @CategoryId And ";
                AddParameter(command, categoryIdParameterName, DbType.Int32, categoryId);
            }
            if (operational != null)
            {
                sql += "Vehicle.Operational = @Operational And ";
                AddParameter(command, operationalParameterName, DbType.Int32, (int)operational);
            }
            sql = RemoveTrailing_AND_(sql);
            DataSet dataSet = FillDataset(command, sql);
            DataTable table = dataSet.Tables[0];
            IList<Vehicle> vehicles = VehiclesFromTable(table);
            return vehicles;
        }

        private static string RemoveTrailing_AND_(string sql)
        {
            return sql.Substring(0, sql.Length - 5);
        }

        private static Customer CustomerFromRow(DataRow row)
        {
            Customer customer = null;
            if (CustomerExist(row))
            {
                customer = new Customer();
                customer.FirstName = row[customerFirstName].ToString();
                customer.LastName = row[customerLastName].ToString();
                customer.DocType = row[customerDocType].ToString();
                customer.DocNumber = row[customerDocNumber].ToString();
            }
            return customer;
        }

        private static bool CustomerExist(DataRow row)
        {
            return !Convert.IsDBNull(row[customerDocNumber]);
        }

        public void Update(Vehicle vehicle)
        {
            IDbCommand command = new SqlCommand();
            AddCommonParameters(vehicle, command);
            AddParameter(command, availableParameterName, DbType.Int32, vehicle.RentalState);
            AddParameter(command, operationalParameterName, DbType.Int32, vehicle.Operational);
            string firstName = string.Empty;
            string lastName = string.Empty;
            string docNumber = string.Empty;
            string docType = string.Empty;
            if ((vehicle.Customer != null))
            {
                firstName = vehicle.Customer.FirstName;
                lastName = vehicle.Customer.LastName;
                docNumber = vehicle.Customer.DocNumber;
                docType = vehicle.Customer.DocType;
            }
            AddParameter(command, customerFirstNameParameterName, DbType.String, firstName);
            AddParameter(command, customerLastNameParameterName, DbType.String, lastName);
            AddParameter(command, customerDocNumberParameterName, DbType.String, docNumber);
            AddParameter(command, customerDocTypeParameterName, DbType.String, docType);
            ExecuteNonQuery(command, updateVehicleSql);
        }

        private void AddCommonParameters(Vehicle vehicle, IDbCommand command)
        {
            AddParameter(command, licensePlateParameterName, DbType.String, vehicle.LicensePlate);
            AddParameter(command, modelIdParameterName, DbType.Int32, vehicle.Model.Id);
            AddParameter(command, branchIdParameterName, DbType.Int32, vehicle.Branch.Id);
            AddParameter(command, tankParameterName, DbType.Int32, vehicle.TankLevel);
            AddParameter(command, mileageParameterName, DbType.Int32, vehicle.Mileage);
        }

        public void Insert(Vehicle vehicle)
        {
            IDbCommand command = new SqlCommand();
            AddCommonParameters(vehicle, command);
            ExecuteNonQuery(command, insertVehicleSql);
        }
    }
}
