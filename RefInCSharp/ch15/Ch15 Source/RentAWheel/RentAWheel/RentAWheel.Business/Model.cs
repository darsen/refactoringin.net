using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace RentAWheel.Business
{
    [Table]
    public class Model
    {
        private EntityRef<Category> category;

        [Column()]
        public int CategoryId;

        public Model() 
        {
            //required by Linq2Sql
        }

        public Model(int id, string name, Category category) 
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true,
            Name = "ModelId")]
        public int Id
        {
            get;
            set;
        }

        [Column(Name = "ModelName")]
        public string Name
        {
            get;
            set;
        }        

        [Association(Storage="category", ThisKey="CategoryId")]
        public Category Category
        {
            get { return category.Entity; }
            set { category.Entity = value; }
        }
    }
}
