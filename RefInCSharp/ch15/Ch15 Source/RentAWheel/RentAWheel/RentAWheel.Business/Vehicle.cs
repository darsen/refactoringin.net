using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace RentAWheel.Business
{
    [Table(Name="Vehicle")]
    public class Vehicle
    {
        private string licensePlate;
        private EntityRef<Model> model;
        private EntityRef<Branch> branch;
        private Operational operational;
        private RentalState rentalState;
        private int mileage;
        private TankLevel tankLevel;
        private EntityRef<Customer> customer;
                
        [Column()]
        public int ModelId;

        [Column()]
        public int BranchId;

        public Vehicle()
        {
            //required by Linq2Sql
        }

        public Vehicle(string licensePlate, Model model, Branch branch, 
            TankLevel tankLevel, int mileage, Customer customer)
        {
            this.LicensePlate = licensePlate;
            this.model.Entity = model;
            this.branch.Entity = branch;
            this.TankLevel = tankLevel;
            this.Mileage = mileage;
            this.customer.Entity = customer;
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = false, Name = "LicensePlate")]
        public string LicensePlate
        {
            get { return licensePlate; }
            set { licensePlate = value; }
        }

        [Association(Storage="model", ThisKey="ModelId")]
        public Model Model
        {
            get { return model.Entity; }
            set { model.Entity = value; }
        }

        [Association(Storage="branch", ThisKey="BranchId")]
        public Branch Branch
        {
            get { return branch.Entity; }
            set { branch.Entity = value; }
        }

        [Column]
        public Operational Operational
        {
            get { return operational; }
            set { operational = value; }
        }

        [Column(Name="Available")]
        public RentalState RentalState
        {
            get { return rentalState; }
            set { rentalState = value; }
        }

        [Column]
        public int Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }

        [Column(Name="Tank")]
        public TankLevel TankLevel
        {
            get { return tankLevel; }
            set { tankLevel = value; }
        }

        [Association(Storage="customer",ThisKey ="LicensePlate")]
        public Customer Customer
        {
            get { return customer.Entity; }
            set { customer.Entity = value; }
        }

        public void Rent()
        {
            if (this.Operational.Equals(Operational.InMaintenence))
            {
                throw new InvalidVehicleStateException(
                    "Vehicle in maintenance. Cannot be handed over.");
            }
            if (!this.RentalState.Equals(RentalState.Available))
            {
                throw new InvalidVehicleStateException(
                    "Vehicle not available. Cannot be rented");
            }
            this.RentalState = RentalState.Rented;
        }

        public void HandOver()
        {
            if (this.Operational.Equals(Operational.InMaintenence))
            {
                throw new InvalidVehicleStateException(
                    "Vehicle in maintenance. Cannot be handed over.");
            }
            if (!this.RentalState.Equals(RentalState.Rented))
            {
                throw new InvalidVehicleStateException(
                    "Vehicle not rented. Cannot be handed over");
            }
            this.RentalState = RentalState.HandedOver;

        }

        public void Receive()
        {
            if (this.Operational.Equals(Operational.InMaintenence))
            {
                throw new InvalidVehicleStateException(
                    "Vehicle in maintenance. Cannot be handed over.");
            }
            if (!this.RentalState.Equals(RentalState.HandedOver))
            {
                throw new InvalidVehicleStateException(
                    "Vehicle not handed over. Cannot be handed received");
            }
            this.RentalState = RentalState.PaymentPending;

        }

        public void Charge()
        {
            if (this.Operational.Equals(Operational.InMaintenence))
            {
                throw new InvalidVehicleStateException(
                    "Vehicle in maintenance. Cannot be handed over.");
            }
            if (!this.RentalState.Equals(RentalState.PaymentPending))
            {
                throw new InvalidVehicleStateException(
                    "Vehicle not received. Cannot be charged");
            }
            this.Customer = null;
            this.RentalState = RentalState.Available;

        }

        public void ToMaintenence()
        {
            if (this.RentalState.Equals(RentalState.Available))
            {
                this.Operational = Operational.InMaintenence;
            }
            else
            {
                throw new InvalidVehicleStateException(
                    "Vehicle in use. Cannot be sent to maintenance.");
            }
        }

        public void FromMaintenence()
        {
            if (this.Operational.Equals(Operational.InMaintenence))
            {
                this.Operational = Operational.InOperation;
            }
            else
            {
                throw new InvalidVehicleStateException(
                    "Vehicle not in maintenance. Cannot be received from maintenance.");
            }
        }
    }
}
