using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AbstractForm
{
    public abstract partial class AbstractParentForm : Form
    {
        public AbstractParentForm()
        {
            InitializeComponent();
        }

        public abstract void myAbstractMethod();

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
