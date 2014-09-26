using System;
using System.Collections.Generic;
using RentAWheel.Business;
using RentAWheel.Data;
using RentAWheel.Data.Implementation;
using RentAWheel.GUI;

namespace RentAWheel
{
    public class ModelMaintenanceHelper : MaintenanceFormAbstractHelper<Model>
    {
        private IData<Model> modelData;

        public IData<Model> ModelData
        {
            get { return modelData; }
            set { modelData = value; }
        }

        LinqData<Category> categoryData;

        public LinqData<Category> CategoryData
        {
            get { return categoryData; }
            set { categoryData = value; }
        }

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
            this.Maintained = ModelData.GetAll();
            LoadCategoryCombo();
        }

        private void LoadCategoryCombo()
        {
            this.categories = CategoryData.GetAll();
            Form.category.DataSource = this.categories;
            Form.category.DisplayMember = "Name";
            Form.category.ValueMember = "Id";
        }

        protected override void DeleteMaintained()
        {
            ModelData.Delete(Current());
        }

        protected override void SaveMaintained()
        {
            if (String.IsNullOrEmpty(Form.id.Text))
            {
                Model model = new Model(0,
                    Form.name.Text,
                    (Category)Form.category.SelectedItem)
                    {
                        CategoryId = ((Category)Form.category.SelectedItem).Id
                    };
                ModelData.Insert(model);
            }
            else
            {
                Model model = Current();
                model.Name = Form.name.Text;
                model.Category = (Category)Form.category.SelectedItem;
                ModelData.Update(model);   
            }

        }      

    }
}
