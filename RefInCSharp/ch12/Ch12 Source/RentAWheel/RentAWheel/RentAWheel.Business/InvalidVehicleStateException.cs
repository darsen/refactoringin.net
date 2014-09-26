using System;

namespace RentAWheel.Business
{
    public class InvalidVehicleStateException : ApplicationException
    {

        public InvalidVehicleStateException(string message)
            : base(message)
        {
        }

    }

}
