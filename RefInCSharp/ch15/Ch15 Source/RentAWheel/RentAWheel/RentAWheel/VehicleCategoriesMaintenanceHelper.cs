using System;
using RentAWheel.Business;
using RentAWheel.Data.Implementation;
using RentAWheel.Data;
using RentAWheel.GUI;

namespace RentAWheel
{
    class VehicleCategoriesMaintenanceHelper : MaintenanceFormAbstractHelper<Category>
    {
        private IData<Category> categoryData;

        public IData<Category> CategoryData
        {
            get { return categoryData; }
            set { categoryData = value; }
        }

        private VehicleCategoriesMaintenance vehicleCategoriesMaintenance;

        public VehicleCategoriesMaintenance VehicleCategoriesMaintenance
        {
            get { return vehicleCategoriesMaintenance; }
            set { vehicleCategoriesMaintenance = value; }
        }

        protected override void DisplayCurrent()
        {
            Category category = Current();
            VehicleCategoriesMaintenance.id.Text = category.Id.ToString();
            VehicleCategoriesMaintenance.name.Text = category.Name;
            VehicleCategoriesMaintenance.dailyPrice.Text = category.DailyPrice.ToString();
            VehicleCategoriesMaintenance.weeklyPrice.Text = category.WeeklyPrice.ToString();
            VehicleCategoriesMaintenance.monthlyPrice.Text = category.MonthlyPrice.ToString();
        }

        protected override void CleanForm()
        {
            VehicleCategoriesMaintenance.id.Text = String.Empty;
            VehicleCategoriesMaintenance.name.Text = String.Empty;
            VehicleCategoriesMaintenance.dailyPrice.Text = String.Empty;
            VehicleCategoriesMaintenance.weeklyPrice.Text = String.Empty;
            VehicleCategoriesMaintenance.monthlyPrice.Text = String.Empty;
        }

        protected override void LoadMaintanied()
        {
            this.Maintained = CategoryData.GetAll();
        }

        protected override void DeleteMaintained()
        {
            CategoryData.Delete(Current());
        }

        protected override void SaveMaintained()
        {
            if (String.IsNullOrEmpty(VehicleCategoriesMaintenance.id.Text))
            {
                Category category = new Category(0, VehicleCategoriesMaintenance.name.Text,
                   Convert.ToDecimal(VehicleCategoriesMaintenance.dailyPrice.Text),
                   Convert.ToDecimal(VehicleCategoriesMaintenance.weeklyPrice.Text),
                   Convert.ToDecimal(VehicleCategoriesMaintenance.monthlyPrice.Text));

                CategoryData.Insert(category);
            }
            else
            {
                Category category = Current();
                category.Name = VehicleCategoriesMaintenance.name.Text;
                category.DailyPrice = Convert.ToDecimal(VehicleCategoriesMaintenance.dailyPrice.Text);
                category.WeeklyPrice = Convert.ToDecimal(VehicleCategoriesMaintenance.weeklyPrice.Text);
                category.MonthlyPrice = Convert.ToDecimal(VehicleCategoriesMaintenance.monthlyPrice.Text);
                CategoryData.Update(category);
            }

        }      
    }
}
