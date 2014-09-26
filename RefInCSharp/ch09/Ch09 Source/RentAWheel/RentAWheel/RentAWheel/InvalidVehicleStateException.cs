using System;

namespace RentAWheel
{
    public class InvalidVehicleStateException : ApplicationException
    {

        public InvalidVehicleStateException(string message)
            : base(message)
        {
        }

    }

}
