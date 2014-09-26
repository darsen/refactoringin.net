using System;

namespace RentAWheel
{
    public partial class ModelMaintenance : GeneralMaintenanceForm
    {
        public ModelMaintenance()
        {
            ModelMaintenanceHelper helper = new ModelMaintenanceHelper();
            helper.Form = this;
            base.Helper = helper;
            InitializeComponent();
        }

        private void ModelMaintenance_Load(object sender, EventArgs e)
        {
            base.Helper.GeneralMaintenanceForm_Load(null, null);
            
        }
    }
}
