using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RentAWheel.Business;
using RentAWheel.Data.Implementation;

namespace RentAWheel
{
    public partial class VehicleCategoriesMaintenance : GeneralMaintenanceForm
    {
        public VehicleCategoriesMaintenance()
        {
            VehicleCategoriesMaintenanceHelper helper = 
                new VehicleCategoriesMaintenanceHelper();
            helper.VehicleCategoriesMaintenance = this;
            base.Helper = helper;
            InitializeComponent();
        }

        private void VehicleCategoriesMaintenance_Load(object sender, EventArgs e)
        {
            base.Helper.GeneralMaintenanceForm_Load(null, null);

        }
    }
}
