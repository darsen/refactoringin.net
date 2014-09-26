using System;
using System.Windows.Forms;

namespace RentAWheel
{
public partial class GeneralMaintenanceForm : Form
{

    public GeneralMaintenanceForm()
    {
        InitializeComponent();            
    }
    
    private IMaintenanceFormHelper helper;

    public IMaintenanceFormHelper Helper
    {
        get { return helper; }
        set { helper = value; }
    }

    private void btnNew_Click(object sender, EventArgs e)
    {
        Helper.btnNew_Click(sender, e);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        Helper.btnSave_Click(sender, e);   
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        Helper.btnDelete_Click(sender, e);
    }

    private void btnReload_Click(object sender, EventArgs e)
    {
        Helper.btnReload_Click(sender, e);
    }

    private void btnFirst_Click(object sender, EventArgs e)
    {
        Helper.btnFirst_Click(sender, e);
    }

    private void btnLeft_Click(object sender, EventArgs e)
    {
        Helper.btnLeft_Click(sender, e);
    }

    private void btnRight_Click(object sender, EventArgs e)
    {
        Helper.btnRight_Click(sender, e);
    }

    private void btnLast_Click(object sender, EventArgs e)
    {
        Helper.btnLast_Click(sender, e);
    }    
    
}
}
