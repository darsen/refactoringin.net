using System;
using System.Configuration;
using System.Windows.Forms;

namespace Users
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
            readConfiguration();
            Application.Run(new UserMaintenance());
        }

        private static void readConfiguration() {
            Configuration config =
            ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringsSection connectionStringsSection = 
                config.ConnectionStrings;
            ConnectionStringSettings connectionStringSettings = 
                connectionStringsSection.ConnectionStrings[
                DataProviderFactory.DbConfigurationSectionName];
            DataProviderFactory.ConnectionString = connectionStringSettings.ConnectionString;
            DataProviderFactory.DatabaseProviderName = connectionStringSettings.ProviderName;    
        }
    }
}
