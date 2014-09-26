using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class SeniorCitizen : Customer
    {

        private bool requiresAssistance;

        public override decimal DiscountPercent()
        {
            return 50;
        }

        public bool RequiresAssistance
        {
            get { return requiresAssistance; }
            set { requiresAssistance = value; }
        }
    }
}
