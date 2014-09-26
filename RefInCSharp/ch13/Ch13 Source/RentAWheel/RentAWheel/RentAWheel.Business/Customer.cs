using System.Data.Linq.Mapping;

namespace RentAWheel.Business
{    
    [Table(Name="Vehicle")]
    public class Customer
    {
        [Column(IsPrimaryKey=true)]
        public string LicensePlate;

        [Column(Name = "CustomerFirstName")]
        public string FirstName
        {
            get;
            set;
        }

        [Column(Name = "CustomerLastName")]
        public string LastName
        {
            get;
            set;
        }

        [Column(Name = "CustomerDocNumber")]
        public string DocNumber
        {
            get;
            set;
        }

        [Column(Name = "CustomerDocType")]
        public string DocType
        {
            get;
            set;
        }

    }
}
