using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RentAWheel
{
    public partial class BranchMaintenance : Form
    {
        private BranchData data = new BranchData();
        private IList<Branch> branches;
        private int current;

        public BranchMaintenance()
        {
            InitializeComponent();
        }

        private void new_Click(object sender, EventArgs e)
        {
            id.Text = String.Empty;
            name.Text = String.Empty;
        }

        private void BranchMaintenance_Load(object sender, EventArgs e)
        {
            LoadBranches();
            if ((this.branches.Count > 0))
            {
                current = 0;
                DisplayCurrent();
            }
        }

        private void LoadBranches() {
            this.branches = data.GetAll();
        }


        private void right_Click(object sender, EventArgs e)
        {
            if (branches.Count > current + 1)
            {
                current++;
                DisplayCurrent();
            }
        }

        private void left_Click(object sender, EventArgs e)
        {
            if (current - 1 >= 0 & branches.Count > 0)
            {
                current--;
                DisplayCurrent();
            }
        }

        private void first_Click(object sender, EventArgs e)
        {
            if (branches.Count > 0)
            {
                current = 0;
                DisplayCurrent();
            }
        }

        private void last_Click(object sender, EventArgs e)
        {
            if (branches.Count > 0)
            {
                current = branches.Count - 1;
                DisplayCurrent();
            }
        }

        private void DisplayCurrent()
        {
            Branch branch = branches[current];
            id.Text = branch.Id.ToString();
            name.Text = branch.Name;
        }

        private void save_Click(object sender, EventArgs e)
        {
            SaveBranch();           
            BranchMaintenance_Load(null, null);
        }

        private void SaveBranch()
        {            
            if (String.IsNullOrEmpty(id.Text))
            {
                data.Insert(new Branch(0 , name.Text));                
            }
            else
            {
                Branch branch = branches[current];
                branch.Name = name.Text;
                data.Update(branches[current]);
            }
        }
             
        private void delete_Click(object sender, EventArgs e)
        {
            data.Delete(branches[current]);
            BranchMaintenance_Load(null, null);
        }

        private void reload_Click(object sender, EventArgs e)
        {
            BranchMaintenance_Load(null, null);
        }
    }
}

