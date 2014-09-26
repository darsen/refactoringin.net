
namespace RentAWheel.Business
{
    public class Branch
    {
        private int id;
        private string name;

        public Branch(int id, string name) {
            this.id = id;
            this.name = name;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }     

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
