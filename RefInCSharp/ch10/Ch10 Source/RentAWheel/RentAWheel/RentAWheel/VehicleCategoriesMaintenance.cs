using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class VehicleCategoriesMaintenance : Form
    {
        private IList<Category> categories;
        private CategoryData data  = new CategoryData();
        private int current;        

        public VehicleCategoriesMaintenance()
        {
            InitializeComponent();
        }

        private void right_Click(object sender, EventArgs e)
        {
            if (categories.Count > current + 1)
            {
                current++;
                DisplayCurrent();
            }
        }

        private void left_Click(object sender, EventArgs e)
        {
            if (current - 1 >= 0 & categories.Count > 0)
            {
                current--;
                DisplayCurrent();
            }
        }

        private void first_Click(object sender, EventArgs e)
        {
            if (categories.Count > 0)
            {
                current = 0;
                DisplayCurrent();
            }
        }

        private void last_Click(object sender, EventArgs e)
        {
            if (categories.Count > 0)
            {
                current = categories.Count - 1;
                DisplayCurrent();
            }
        }

        private void DisplayCurrent()
        {
            Category category = categories[current];
            id.Text = category.Id.ToString();
            name.Text = category.Name;
            dailyPrice.Text = category.DailyPrice.ToString();
            weeklyPrice.Text = category.WeeklyPrice.ToString();
            monthlyPrice.Text = category.MonthlyPrice.ToString();
        }


        private void new_Click(object sender, EventArgs e)
        {
            id.Text = String.Empty;
            name.Text = String.Empty;
            dailyPrice.Text = String.Empty;
            weeklyPrice.Text = String.Empty;
            monthlyPrice.Text = String.Empty;
        }

        private void VehicleCategoriesMaintenance_Load(object sender, EventArgs e)
        {   
            LoadCategories();
            if (categories.Count > 0)
            {
                current = 0;
                DisplayCurrent();
            }            
        }

        private void LoadCategories() {
            categories = data.GetAll();
        }

        private void reload_Click(object sender, EventArgs e)
        {
            VehicleCategoriesMaintenance_Load(null, null);
        }

        private void save_Click(object sender, EventArgs e)
        {
            Save();
            VehicleCategoriesMaintenance_Load(null, null);
        }

        private void Save()
        {
            if ((String.IsNullOrEmpty(id.Text)))
            {
                Category category = new Category(0, name.Text,
                    Convert.ToDecimal(dailyPrice.Text),
                    Convert.ToDecimal(weeklyPrice.Text),
                    Convert.ToDecimal(monthlyPrice.Text));

                data.Insert(category);
            }
            else
            {
                Category category = categories[current];
                category.Name = this.name.Text;
                category.DailyPrice = Convert.ToDecimal(this.dailyPrice.Text);
                category.WeeklyPrice = Convert.ToDecimal(this.weeklyPrice.Text);
                category.MonthlyPrice = Convert.ToDecimal(this.monthlyPrice.Text);
                data.Update(category);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            data.Delete(categories[current]);
            VehicleCategoriesMaintenance_Load(null, null);
        }
    }
}
