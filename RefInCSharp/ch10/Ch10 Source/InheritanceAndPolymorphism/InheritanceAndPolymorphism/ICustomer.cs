using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public interface ICustomer
    {
        PurchaseHistory PurchaseHistory
        {
            get;
            set;
        }

        decimal DiscountPercent();
    }
}
