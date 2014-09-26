using System;

namespace RentAWheel
{
public interface IMaintenanceFormHelper
{
    void btnDelete_Click(object sender, EventArgs e);
    void btnFirst_Click(object sender, EventArgs e);
    void btnLast_Click(object sender, EventArgs e);
    void btnLeft_Click(object sender, EventArgs e);
    void btnNew_Click(object sender, EventArgs e);
    void btnReload_Click(object sender, EventArgs e);
    void btnRight_Click(object sender, EventArgs e);
    void btnSave_Click(object sender, EventArgs e);
    void GeneralMaintenanceForm_Load(object sender, EventArgs e);
}
}
