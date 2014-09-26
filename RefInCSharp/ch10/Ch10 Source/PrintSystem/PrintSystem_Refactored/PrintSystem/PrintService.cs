using System.Collections.Generic;

namespace RefactoringInCSharpAndAsp.Chapter10.PrintSystem
{
    public enum ServiceState
    {
        Idle,
        Processing,
        Stopped
    }

public class PrintService : PrintSystem.IPrintDevice
{
    private IPrintDevice device;
    
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

    public void PrintJob(PrintJob job) {
        this.device.PrintJob(job);
    }
}
}
