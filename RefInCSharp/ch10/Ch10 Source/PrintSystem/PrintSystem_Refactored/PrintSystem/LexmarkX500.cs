using System.IO;

namespace RefactoringInCSharpAndAsp.Chapter10.PrintSystem
{
    public class LexmarkX500 : PrintDevice
    {        
        protected override Stream RenderDocument(PrintJob job)
        {
            //device specific code
            return null;
        }

        protected override void WriteDocumentToDevice(Stream data)
        {
            //device specific code
        }

        protected override void Initialize()
        {
            //device specific code
        }

        protected override void StartDocument()
        {
            //device specific code
        }
        
        protected override void EndDocument()
        {
            //device specific code
        }
    }
}
