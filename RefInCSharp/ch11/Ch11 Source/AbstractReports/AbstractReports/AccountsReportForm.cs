
namespace AbstractReports
{
    public partial class AccountsReportForm : GeneralReportForm
    {
        public AccountsReportForm()
        {
            InitializeComponent();
            this.Helper = new AccountsHelper(this);
        }
    }
}
