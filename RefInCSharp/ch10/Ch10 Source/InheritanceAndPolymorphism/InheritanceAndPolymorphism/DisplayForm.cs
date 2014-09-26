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
    public partial class DisplayForm : Form
    {
        public DisplayForm()
        {
            InitializeComponent();
        }

        private void instantiateAsCustomer_Click(object sender, EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm();
            purchaseForm.Customer = new Customer();
            purchaseForm.Activate();
            purchaseForm.Show();
        }

        private void instantiateAsSeniorCitizen_Click(object sender, EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm();
            purchaseForm.Customer = new SeniorCitizen();
            purchaseForm.Activate();
            purchaseForm.Show();
        }
    }
}
