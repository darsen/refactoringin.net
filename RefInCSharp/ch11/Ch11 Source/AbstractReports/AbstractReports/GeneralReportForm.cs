using System.Windows.Forms;

namespace AbstractReports
{
public partial class GeneralReportForm : Form
{
    private AbstractReportHelper helper;

    public GeneralReportForm()
    {
        InitializeComponent();
    }

    protected AbstractReportHelper Helper
    {
        get { return helper; }
        set { helper = value; }
    }
}
}
