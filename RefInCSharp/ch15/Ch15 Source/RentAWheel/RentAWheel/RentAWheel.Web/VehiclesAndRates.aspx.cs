using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Web.Configuration;
using RentAWheel.Business;
using RentAWheel.Data;
using System.Web.UI;

namespace RentAWheel.Web
{
    public partial class _VehiclesAndRates : Page
    {

        private static ConnectionStringSettings 
            connectionStringSettings;

        private const String DbStringConfigurationSectionName 
            = "RentAWheels";

        private static DataContext context;        

        private static LinqData<Model> modelData;

        private static void ReadConnectionSettings()
        {
            Configuration config = WebConfigurationManager.
                OpenWebConfiguration("/");
            ConnectionStringsSection connectionStringsSection =
                config.ConnectionStrings;
            connectionStringSettings = connectionStringsSection.
                ConnectionStrings[DbStringConfigurationSectionName];
            context = new DataContext(
                connectionStringSettings.ConnectionString);
        }

        static void CreateDataServices()
        {            
            modelData = new LinqData<Model>(connectionStringSettings)
            { Context = context };            
        }

        public _VehiclesAndRates() {
            ReadConnectionSettings();
            CreateDataServices();
            
        }

        public IList<Model> GetAllModels(){
            return modelData.GetAll();
        }
    }
}
