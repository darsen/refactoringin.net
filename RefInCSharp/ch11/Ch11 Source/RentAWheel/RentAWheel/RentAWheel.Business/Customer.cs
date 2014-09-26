
namespace RentAWheel.Business
{
    public class Customer
    {

        private string firstName;
        private string lastName;
        private string docNumber;
        private string docType;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string DocNumber
        {
            get { return docNumber; }
            set { docNumber = value; }
        }

        public string DocType
        {
            get { return docType; }
            set { docType = value; }
        }

    }
}
