using System;

namespace RentAWheel
{
    public partial class BranchMaintenance : GeneralMaintenanceForm
    {
        public BranchMaintenance():base() {
            BranchMaintenanceHelper helper = new BranchMaintenanceHelper();            
            helper.Form = this;
            base.Helper = helper;            
            InitializeComponent();
            
        }

        private void BranchMaintenance_Load(object sender, EventArgs e)
        {
            base.Helper.GeneralMaintenanceForm_Load(null, null);
        }        
    }
}

