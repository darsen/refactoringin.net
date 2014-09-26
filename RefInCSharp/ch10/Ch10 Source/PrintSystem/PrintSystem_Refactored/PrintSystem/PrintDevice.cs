using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RefactoringInCSharpAndAsp.Chapter10.PrintSystem
{
    public abstract class PrintDevice : IPrintDevice
    {
        private bool initialized;

        public bool Initialized
        {
            get { return initialized; }
            set { initialized = value; }
        }

        public void PrintJob(PrintJob job)
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
        protected abstract Stream RenderDocument(PrintJob job);
        protected abstract void WriteDocumentToDevice(Stream data);
        protected abstract void Initialize();
        protected abstract void StartDocument();
        protected abstract void EndDocument();

    }
}
