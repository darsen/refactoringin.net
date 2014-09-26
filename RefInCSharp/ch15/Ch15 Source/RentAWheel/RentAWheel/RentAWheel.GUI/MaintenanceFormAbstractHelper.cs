using System;
using System.Collections.Generic;

namespace RentAWheel.GUI
{
    public abstract class MaintenanceFormAbstractHelper<Maintanied> : IMaintenanceFormHelper
    {
        private IList<Maintanied> maintained;

        private int current;

        public IList<Maintanied> Maintained
        {
            get { return maintained; }
            set { maintained = value; }
        }

        protected Maintanied Current() {
            return maintained[current];
        }

        public void btnNew_Click(object sender, EventArgs e)
        {
            CleanForm();
        }

        public void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteMaintained();
            GeneralMaintenanceForm_Load(sender, e);
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            SaveMaintained();
            GeneralMaintenanceForm_Load(sender, e);
        }

        public void btnReload_Click(object sender, EventArgs e)
        {
            GeneralMaintenanceForm_Load(sender, e);
        }

        public void btnFirst_Click(object sender, EventArgs e)
        {
            if (Maintained.Count > 0)
            {
                current = 0;
                DisplayCurrent();
            }
        }

        public void btnLeft_Click(object sender, EventArgs e)
        {
            if (current - 1 >= 0 & Maintained.Count > 0)
            {
                current--;
                DisplayCurrent();
            }
        }

        public void btnRight_Click(object sender, EventArgs e)
        {
            if (Maintained.Count > current + 1)
            {
                current++;
                DisplayCurrent();
            }
        }

        public void btnLast_Click(object sender, EventArgs e)
        {
            if (Maintained.Count > 0)
            {
                current = Maintained.Count - 1;
                DisplayCurrent();
            }
        }

        public void GeneralMaintenanceForm_Load(object sender, EventArgs e)
        {
            LoadMaintanied();
            if ((this.Maintained.Count > 0))
            {
                current = 0;
                DisplayCurrent();
            }
            else {
                CleanForm();
            }
        }

        protected abstract void DisplayCurrent();

        protected abstract void CleanForm();
                        
        protected abstract void LoadMaintanied();

        protected abstract void DeleteMaintained();

        protected abstract void SaveMaintained();
        
    }
}
