using System;
using RentAWheel.Business;
using RentAWheel.Data.Implementation;

namespace RentAWheel
{
    class VehicleCategoriesMaintenanceHelper : MaintenanceFormAbstractHelper<Category>
    {
        private CategoryData data;

        private VehicleCategoriesMaintenance form;

        public VehicleCategoriesMaintenance Form
        {
            get { return form; }
            set { form = value; }
        }

        protected override void DisplayCurrent()
        {
            Category category = Current();
            Form.id.Text = category.Id.ToString();
            Form.name.Text = category.Name;
            Form.dailyPrice.Text = category.DailyPrice.ToString();
            Form.weeklyPrice.Text = category.WeeklyPrice.ToString();
            Form.monthlyPrice.Text = category.MonthlyPrice.ToString();
        }

        protected override void CleanForm()
        {
            Form.id.Text = String.Empty;
            Form.name.Text = String.Empty;
            Form.dailyPrice.Text = String.Empty;
            Form.weeklyPrice.Text = String.Empty;
            Form.monthlyPrice.Text = String.Empty;
        }

        protected override void LoadMaintanied()
        {
            this.Maintained = data.GetAll();
        }

        protected override void CreateData()
        {
            this.data = new CategoryData();
        }

        protected override void DeleteMaintained()
        {
            data.Delete(Current());
        }

        protected override void SaveMaintained()
        {
            if (String.IsNullOrEmpty(Form.id.Text))
            {
                Category category = new Category(0, Form.name.Text,
                   Convert.ToDecimal(Form.dailyPrice.Text),
                   Convert.ToDecimal(Form.weeklyPrice.Text),
                   Convert.ToDecimal(Form.monthlyPrice.Text));

                data.Insert(category);
            }
            else
            {
                Category category = Current();
                category.Name = Form.name.Text;
                category.DailyPrice = Convert.ToDecimal(Form.dailyPrice.Text);
                category.WeeklyPrice = Convert.ToDecimal(Form.weeklyPrice.Text);
                category.MonthlyPrice = Convert.ToDecimal(Form.monthlyPrice.Text);
                data.Update(category);
            }

        }      
    }
}
