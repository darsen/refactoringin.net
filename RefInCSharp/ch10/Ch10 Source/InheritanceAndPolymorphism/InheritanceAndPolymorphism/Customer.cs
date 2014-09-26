using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class Customer : ICustomer
    {
        //...
        private PurchaseHistory purchaseHistory = new PurchaseHistory();

        public PurchaseHistory PurchaseHistory
        {
            get { return purchaseHistory; }
            set { purchaseHistory = value; }
        }
        public virtual decimal DiscountPercent()
        {
            if (this.PurchaseHistory.TotalPurchases > 10)
            {
                return 3;
            }
            else if (this.PurchaseHistory.TotalPurchases > 100)
            {
                return 5;
            }
            else
            {
                return 0;
            }
        }
    }
}
