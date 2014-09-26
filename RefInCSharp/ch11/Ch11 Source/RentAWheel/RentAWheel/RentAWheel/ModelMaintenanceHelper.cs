using System;
using System.Collections.Generic;
using RentAWheel.Business;
using RentAWheel.Data.Implementation;

namespace RentAWheel
{
    public class ModelMaintenanceHelper : MaintenanceFormAbstractHelper<Model>
    {
        private ModelData data;

        CategoryData categoryData = new CategoryData();

        IList<Category> categories;

        private ModelMaintenance form;

        public ModelMaintenance Form
        {
            get { return form; }
            set { form = value; }
        }
        
        protected override void DisplayCurrent()
        {            
            Form.id.Text = Current().Id.ToString();
            Form.name.Text = Current().Name;
            Form.category.Text = Current().Category.Name;
        }

        protected override void CleanForm()
        {
            Form.id.Text = String.Empty;
            Form.name.Text = String.Empty;
            Form.category.Text = String.Empty;
        }

        protected override void LoadMaintanied()
        {
            this.Maintained = data.GetAll();
            LoadCategoryCombo();
        }

        private void LoadCategoryCombo()
        {
            this.categories = categoryData.GetAll();
            Form.category.DataSource = this.categories;
            Form.category.DisplayMember = "Name";
            Form.category.ValueMember = "Id";
        }

        protected override void CreateData()
        {
            this.data = new ModelData();
        }

        protected override void DeleteMaintained()
        {
            data.Delete(Current());
        }

        protected override void SaveMaintained()
        {
            if (String.IsNullOrEmpty(Form.id.Text))
            {
                Model model = new Model(
                0,
                Form.name.Text,
                (Category)Form.category.SelectedItem);
                data.Insert(model);
            }
            else
            {
                Model model = Current();
                model.Name = Form.name.Text;
                model.Category = (Category)Form.category.SelectedItem;
                data.Update(model);   
            }

        }      

    }
}
