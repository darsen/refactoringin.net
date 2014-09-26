using System;

namespace RentAWheel.Business
{
    public class Model
    {
        private Int32 id;
        private string name;
        private Category category;

        public Model(int id, string name, Category category) {
            this.id = id;
            this.name = name;
            this.Category = category;
        }
        
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }        

        public string Name
        {
            get { return name; }
            set { name = value; }
        }        

        public Category Category
        {
            get { return category; }
            set { category = value; }
        }
    }
}
