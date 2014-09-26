using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InheritanceAndPolymorphism
{
    public partial class PurchaseForm : Form
    {
        private ICustomer customer;
        
        public PurchaseForm()
        {
            InitializeComponent();
        }

        public ICustomer Customer {
            get { return customer; }
            set { customer = value; }
        }

        private void PurchaseForm_Activated(object sender, EventArgs e)
        {
            this.discount.Text = customer.DiscountPercent().ToString() ;
        }
    }
}
