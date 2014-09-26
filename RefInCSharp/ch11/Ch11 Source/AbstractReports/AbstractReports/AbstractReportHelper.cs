
namespace AbstractReports
{
    public abstract class AbstractReportHelper
    {
        private GeneralReportForm form;

        public AbstractReportHelper(GeneralReportForm form)
        {
            this.form = form;
        }
        internal void ViewReport()
        {
            //...
        }

        internal void SelectReportType()
        {
            //...
        }
        
        public GeneralReportForm Form
        {
            get { return form; }
            set { form = value; }
        }

        internal abstract void AddReportData();
    }
}
