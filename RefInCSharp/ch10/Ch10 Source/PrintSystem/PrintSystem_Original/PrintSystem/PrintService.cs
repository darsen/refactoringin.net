using System.Collections.Generic;

namespace RefactoringInCSharpAndAsp.Chapter10.PrintSystem
{
    public enum ServiceState
    {
        Idle,
        Processing,
        Stopped
    }

    public abstract class PrintService
    {
        private IList<PrintJob> jobsInQueue;
        private ServiceState serviceState;
        public IList<PrintJob> JobsInQueue
        {
            get { return jobsInQueue; }
            set { jobsInQueue = value; }
        }
        public ServiceState ServiceState
        {
            get { return serviceState; }
            set { serviceState = value; }
        }
        public PrintJob CreatePrintJob()
        {
            return new PrintJob();
        }
        private void print()
        {
            while (JobsInQueue.Count > 0)
            {
                PrintJob(JobsInQueue[0]);
            }
        }
        protected abstract void PrintJob(PrintJob job);
    }
}
