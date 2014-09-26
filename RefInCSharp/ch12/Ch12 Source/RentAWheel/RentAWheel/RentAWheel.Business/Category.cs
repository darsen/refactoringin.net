
namespace RentAWheel.Business
{
    public class Category
    {
        private int id;
        private string name;
        private decimal dailyPrice;
        private decimal weeklyPrice;
        private decimal monthlyPrice;

        public Category(int id, string name, decimal dailyPrice, 
            decimal weeklyPrice, decimal monthlyPrice) {
                this.id = id;
                this.name = name;
                this.dailyPrice = dailyPrice;
                this.weeklyPrice = weeklyPrice;
                this.monthlyPrice = monthlyPrice;
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

        public decimal DailyPrice
        {
            get { return dailyPrice; }
            set { dailyPrice = value; }
        }       

        public decimal WeeklyPrice
        {
            get { return weeklyPrice; }
            set { weeklyPrice = value; }
        }
        
        public decimal MonthlyPrice
        {
            get { return monthlyPrice; }
            set { monthlyPrice = value; }
        }
    }
}
