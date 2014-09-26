using System.Data.Linq.Mapping;

namespace RentAWheel.Business
{
    [Table]
    public class Branch
    {
        public Branch() 
        { 
             //required by Linq2Sql
        }

        public Branch(int id, string name) {
            this.Id = id;
            this.Name = name;
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "BranchId")]
        public int Id
        {
            get;
            set;
        }

        [Column(Name = "BranchName")]
        public string Name
        {
            get;
            set;
        }
    }
}
