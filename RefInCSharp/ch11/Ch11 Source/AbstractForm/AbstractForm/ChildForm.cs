using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AbstractForm
{
    public partial class ChildForm : AbstractParentForm
    {
        public ChildForm()
        {
            InitializeComponent();
        }

        public override void myAbstractMethod() { 
            //leave empty
        }
    }
}
