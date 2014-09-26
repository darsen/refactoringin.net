using System;
using System.Windows.Forms;

namespace RentAWheel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FleetView());

            AppDomain.CurrentDomain.UnhandledException +=
            new UnhandledExceptionEventHandler(HandleUnhandledException);
        }

        static void HandleUnhandledException(object sender, 
            UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("A problem occurred " + 
                "and the application cannot recover! " +
            "Please contact the technical support.");           
        }
    }
}
