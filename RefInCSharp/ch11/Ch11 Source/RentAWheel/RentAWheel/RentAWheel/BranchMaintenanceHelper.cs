using System;
using RentAWheel.Business;
using RentAWheel.Data.Implementation;

namespace RentAWheel
{
public class BranchMaintenanceHelper : MaintenanceFormAbstractHelper<Branch>
{
    private BranchData data;

    private BranchMaintenance form;

    public BranchMaintenance Form
    {
        get { return form; }
        set { form = value; }
    }

    protected override void DisplayCurrent() {
        Branch branch = Current();
        Form.id.Text = branch.Id.ToString();
        Form.name.Text = branch.Name;        
    }

    protected override void CleanForm()
    {
        Form.id.Text = String.Empty;
        Form.name.Text = String.Empty;
    }

    protected override void LoadMaintanied()
    {
        this.Maintained = data.GetAll();
    }

    protected override void CreateData()
    {
        this.data = new BranchData();
    }

    protected override void DeleteMaintained() 
    {
        data.Delete(Current());            
    }

    protected override void SaveMaintained()
    {
        if (String.IsNullOrEmpty(Form.id.Text))
        {
            data.Insert(new Branch(0, Form.name.Text));
        }
        else
        {
            Branch branch = Current();
            branch.Name = Form.name.Text;
            data.Update(Current());
        }

    }      
}
}
