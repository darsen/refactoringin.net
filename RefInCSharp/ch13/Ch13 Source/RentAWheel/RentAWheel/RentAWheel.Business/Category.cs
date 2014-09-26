using System.Data.Linq.Mapping;

namespace RentAWheel.Business
{
    [Table]
    public class Category
    {
        public Category()
        {
            //required by Linq2Sql
        }

        public Category(int id, string name, decimal dailyPrice, 
            decimal weeklyPrice, decimal monthlyPrice) 
        {
                this.Id = id;
                this.Name = name;
                this.DailyPrice = dailyPrice;
                this.WeeklyPrice = weeklyPrice;
                this.MonthlyPrice = monthlyPrice;
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "CategoryId")]
        public int Id
        {
            get;
            set;
        }

        [Column(Name = "CategoryName")]
        public string Name
        {
            get;
            set;
        }

        [Column]
        public decimal DailyPrice
        {
            get;
            set;
        }

        [Column]
        public decimal WeeklyPrice
        {
            get;
            set;
        }

        [Column]
        public decimal MonthlyPrice
        {
            get;
            set;
        }
    }
}
