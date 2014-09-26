using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class ModelMaintenance : Form
    {
        ModelData data = new ModelData();
        CategoryData categoryData = new CategoryData();

        IList<Model> models;
        IList<Category> categories;

        int current = 0;

        public ModelMaintenance()
        {
            InitializeComponent();
        }

        private void right_Click(object sender, EventArgs e)
        {
            if (models.Count > current + 1)
            {
                current++;
                DisplayCurrent();
            }
        }

        private void left_Click(object sender, EventArgs e)
        {
            if (current - 1 >= 0 & models.Count > 0)
            {
                current--;
                DisplayCurrent();
            }
        }

        private void first_Click(object sender, EventArgs e)
        {
            if (models.Count > 0)
            {
                current = 0;
                DisplayCurrent();
            }
        }

        private void last_Click(object sender, EventArgs e)
        {
            if (models.Count > 0)
            {
                current = models.Count - 1;
                DisplayCurrent();
            }
        }

        private void DisplayCurrent()
        {
            Model model = models[current];
            id.Text = model.Id.ToString();
            name.Text = model.Name;
            category.Text = model.Category.Name;
        }

        private void new_Click(object sender, EventArgs e)
        {
            id.Text = String.Empty;
            name.Text = String.Empty;
            category.Text = String.Empty;
        }

        private void save_Click(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(id.Text)))
            {
                InsertModel();
            }
            else
            {
                UpdateModel();
            }
            ModelMaintenance_Load(null, null);
        }

        private void UpdateModel()
        {
            Model model = models[current];
            model.Name = name.Text;
            model.Category = (Category)category.SelectedItem;
            data.Update(model);

        }

        private void InsertModel()
        {
            Model model = new Model(
                0,
                name.Text,
                (Category)this.category.SelectedItem);
            data.Insert(model);
        }

        private void ModelMaintenance_Load(object sender, EventArgs e)
        {            
            LoadCategoryCombo();
            LoadModels();
            if (models.Count > 0)
            {
                current = 0;
                DisplayCurrent();
            }  
        }

        private void LoadCategoryCombo()
        {
            this.categories = categoryData.GetAll();
            category.DataSource = this.categories;
            category.DisplayMember = "Name";
            category.ValueMember = "Id";
        }

        private void LoadModels()
        {
            this.models = data.GetAll();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            data.Delete(models[current]);
            ModelMaintenance_Load(null, null);
        }

        private void reload_Click(object sender, EventArgs e)
        {
            ModelMaintenance_Load(null, null);
        }
    }
}
