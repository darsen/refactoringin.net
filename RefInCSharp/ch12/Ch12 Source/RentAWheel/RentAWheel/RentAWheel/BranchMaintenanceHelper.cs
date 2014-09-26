using System;
using RentAWheel.Business;
using RentAWheel.Data.Implementation;
using RentAWheel.GUI;

namespace RentAWheel
{
public class BranchMaintenanceHelper : MaintenanceFormAbstractHelper<Branch>
{
    private BranchData branchData;

    private BranchMaintenance form;

    public BranchMaintenance Form
    {
        get { return form; }
        set { form = value; }
    }

    public BranchData BranchData
    {
        get { return branchData; }
        set { branchData = value; }
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
        this.Maintained = BranchData.GetAll();
    }

    protected override void DeleteMaintained() 
    {
        BranchData.Delete(Current());            
    }

    protected override void SaveMaintained()
    {
        if (String.IsNullOrEmpty(Form.id.Text))
        {
            BranchData.Insert(new Branch(0, Form.name.Text));
        }
        else
        {
            Branch branch = Current();
            branch.Name = Form.name.Text;
            BranchData.Update(Current());
        }

    }      
}
}
