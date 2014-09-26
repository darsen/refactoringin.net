using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using RentAWheel.Business;

namespace RentAWheel.Data.Implementation
{
    public class BranchData : AbstractAdoData<Branch>, IData<Branch>
    {
        public BranchData(ConnectionStringSettings settings)
            : base(settings)
        { 
        
        }

        private const string branchTableIdColumnName = "BranchId";
        private const string branchTableNameColumnName = "BranchName";

        private const string selectAllFromBranchSql =
            "Select BranchId as BranchId, BranchName as BranchName from Branch";
        private const string deleteBranchSql =
            "Delete Branch Where BranchId = @Id";
        private const string insertBranchSql =
            "Insert Into Branch (BranchName) Values(@Name)";
        private const string updateBranchSql =
            "Update Branch  Set BranchName = @Name Where BranchId = @Id";

        private const string idParameterName = "@Id";
        private const string nameParameterName = "@Name";

        private const int singleTableInDatasetIndex = 0;

        public override IList<Branch> GetAll()
        {
            IList<Branch> branches = new List<Branch>();
            IDbCommand command = new SqlCommand();
            DataSet branchesSet = 
                FillDataset(command, selectAllFromBranchSql);
            DataTable branchesTable = 
                branchesSet.Tables[singleTableInDatasetIndex];
            foreach(DataRow row in branchesTable.Rows){
                branches.Add(BranchFromRow(row));
            }
            return branches;                    
        }

        public static Branch BranchFromRow(DataRow row)
        {
            return new Branch(
                Convert.ToInt32(row[branchTableIdColumnName]),
                Convert.ToString(row[branchTableNameColumnName]));
        }

        public override void Delete(Branch branch)
        {
            IDbCommand command = new SqlCommand();
            AddParameter(command, idParameterName,
                DbType.Int32, branch.Id);
            ExecuteNonQuery(command, deleteBranchSql);
        }

        public override void Update(Branch branch)
        {
            IDbCommand command = new SqlCommand();
            AddParameter(command, nameParameterName,
                DbType.String, branch.Name);
            AddParameter(command, idParameterName,
                DbType.Int32, branch.Id);
            ExecuteNonQuery(command, updateBranchSql);
        }

        public override void Insert(Branch branch)
        {
            IDbCommand command = new SqlCommand();
            AddParameter(command, nameParameterName,
                DbType.String, branch.Name);
            ExecuteNonQuery(command, insertBranchSql);
        }       
    }
}
