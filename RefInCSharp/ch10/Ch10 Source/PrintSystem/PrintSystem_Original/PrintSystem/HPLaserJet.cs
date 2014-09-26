using System.IO;

namespace RefactoringInCSharpAndAsp.Chapter10.PrintSystem
{
    public class HPLaserJet : PrintService
    {
        private bool initialized;
        private bool Initialized
        {
            get { return initialized; }
            set { initialized = value; }
        }
        protected override void PrintJob(PrintJob job)
        {
            if (!this.Initialized)
            {
                this.Initialize();
            }
            StartDocument();
            Stream renderedDocument = RenderDocument(job);
            WriteDocumentToDevice(renderedDocument);
            EndDocument();
        }
        private Stream RenderDocument(PrintJob job)
        {
            //device specific code
            return null;
        }
        private void WriteDocumentToDevice(Stream data)
        {
            //device specific code
        }
        private void Initialize()
        {
            //device specific code
        }
        private void StartDocument()
        {
            //device specific code
        }
        private void EndDocument()
        {
            //device specific code
        }
    }
}
