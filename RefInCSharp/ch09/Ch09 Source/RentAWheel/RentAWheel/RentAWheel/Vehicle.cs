using System;

namespace RentAWheel
{
    public class Vehicle
    {
        private string licensePlate;
        private Model model;
        private Branch branch;
        private Operational operationalValue;
        private RentalState rentalStateValue;
        private int mileage;
        private TankLevel tankLevel;
        private Customer customer;

        public Vehicle(string licensePlate, Model model, Branch branch, 
            TankLevel tankLevel, int mileage, Customer customer)
        {
            this.licensePlate = licensePlate;
            this.model = model;
            this.branch = branch;
            this.tankLevel = tankLevel;
            this.mileage = mileage;
            this.customer = customer;
        }

        public string LicensePlate
        {
            get { return licensePlate; }
            set { licensePlate = value; }
        }

        public Model Model
        {
            get { return model; }
            set { model = value; }
        }

        public Branch Branch
        {
            get { return branch; }
            set { branch = value; }
        }

        public Operational Operational
        {
            get { return operationalValue; }
            set { operationalValue = value; }
        }

        public RentalState RentalState
        {
            get { return rentalStateValue; }
            set { rentalStateValue = value; }
        }

        public int Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }

        public TankLevel TankLevel
        {
            get { return tankLevel; }
            set { tankLevel = value; }
        }

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
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
