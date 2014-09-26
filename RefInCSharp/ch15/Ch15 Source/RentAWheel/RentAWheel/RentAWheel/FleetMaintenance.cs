using System;

namespace RentAWheel
{
    public partial class FleetMaintenance : GeneralMaintenanceForm
    {
        public FleetMaintenance() 
        {
            FleetMaintenanceHelper helper = new FleetMaintenanceHelper();
            helper.Form = this;
            base.Helper = helper;
            InitializeComponent();
        }

        private void FleetMaintenance_Load(object sender, EventArgs e)
        {
            base.Helper.GeneralMaintenanceForm_Load(null, null);
        }
    }
}

