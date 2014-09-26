using System;
using System.Windows.Forms;
using RentAWheel.Data;
using RentAWheel.Business;
using RentAWheel.Data.Implementation;
using System.Configuration;
using System.Data.Linq;

namespace RentAWheel
{
    static class Program
    {
        private static ConnectionStringSettings connectionStringSettings;
        
        private const String DbStringConfigurationSectionName = "RentAWheels";

        private static DataContext context;

        private static LinqData<Vehicle> vehicleData;

        private static LinqData<Model> modelData;

        private static LinqData<Category> categoryData;

        private static LinqData<Branch> branchData;

        private static FleetView fleetView;

        static BranchMaintenance branchMaintenance;
        static VehicleCategoriesMaintenance categoryMaintenance;        
        static ModelMaintenance modelMaintenance;        
        static FleetMaintenance fleetMaintenance;        
        static VehicleRental vehicleRental;        
        static VehicleReception vehicleReception;
        static VehicleChangeBranch changeBranch;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
                        
            ReadConnectionSettings();
            CreateDataServices();            
            CreateForms();
            SetupModelMaintenanceForm();
            SetupFleetMaintenanceForm();
            SetUpBranchMaintenanceForm();
            SetUpVehicleCategoriesMaintenanceForm();
            SetUpVehicleRentalForm();
            SetUpRentVehicleReceptionForm();
            SetUpRentVehicleChangeBranchForm();
            SetUpFleetViewForm();
            SetUpChangeBranchForm();
            Application.Run(fleetView);

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

        static void CreateDataServices() {
            vehicleData = new LinqData<Vehicle>(connectionStringSettings)
                { Context = context };
            modelData = new LinqData<Model>(connectionStringSettings)
                { Context = context };
            categoryData = new LinqData<Category>(connectionStringSettings)
                { Context = context };
            branchData = new LinqData<Branch>(connectionStringSettings)         
                { Context = context };
        }

        private static void ReadConnectionSettings()
        {
            Configuration config = ConfigurationManager.
                OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringsSection connectionStringsSection = 
                config.ConnectionStrings;
            connectionStringSettings = connectionStringsSection.
                ConnectionStrings[DbStringConfigurationSectionName];
            context = new DataContext(connectionStringSettings.ConnectionString);
        }

        private static void CreateForms() 
        {
            fleetView = new FleetView();
            branchMaintenance = new BranchMaintenance();
            categoryMaintenance = new VehicleCategoriesMaintenance();
            modelMaintenance = new ModelMaintenance();
            fleetMaintenance = new FleetMaintenance();
            vehicleRental = new VehicleRental();
            vehicleReception = new VehicleReception();
            changeBranch = new VehicleChangeBranch();
        }

        private static void SetupModelMaintenanceForm()
        {
            ((ModelMaintenanceHelper)modelMaintenance.Helper).ModelData 
                = modelData;
            ((ModelMaintenanceHelper)modelMaintenance.Helper).CategoryData 
                = categoryData;
        }
        private static void SetUpFleetViewForm()
        {
            fleetView.BranchData = branchData;
            fleetView.CategoryData = categoryData;
            fleetView.VehicleData = vehicleData;
            fleetView.ModelMaintenance = modelMaintenance;
            fleetView.BranchMaintenance = branchMaintenance;
            fleetView.CategoryMaintenance = categoryMaintenance;
            fleetView.FleetMaintenance = fleetMaintenance;
            fleetView.VehicleReception = vehicleReception;
            fleetView.VehicleRental = vehicleRental;
            fleetView.ChangeBranchForm = changeBranch;
        }
        private static void SetupFleetMaintenanceForm()
        {
            ((FleetMaintenanceHelper)fleetMaintenance.Helper).BranchData
                = branchData;
            ((FleetMaintenanceHelper)fleetMaintenance.Helper).ModelData 
                = modelData;
            ((FleetMaintenanceHelper)fleetMaintenance.Helper).VehicleData 
                = vehicleData;
        }
        private static void SetUpChangeBranchForm()
        {
            changeBranch.BranchData = branchData;
            changeBranch.VehicleData = vehicleData;
        }
        private static void SetUpBranchMaintenanceForm()
        {
            ((BranchMaintenanceHelper)branchMaintenance.Helper).BranchData 
                = branchData;
        }
        private static void SetUpVehicleReceptionForm()
        {
            vehicleReception.VehicleData = vehicleData;
        }
        private static void SetUpVehicleCategoriesMaintenanceForm()
        {
            ((VehicleCategoriesMaintenanceHelper)categoryMaintenance.Helper).
                CategoryData = categoryData;
        }
        private static void SetUpVehicleRentalForm()
        {
            vehicleRental.VehicleData = vehicleData;
        }
        private static void SetUpRentVehicleReceptionForm()
        {
            vehicleReception.VehicleData = vehicleData;
        }
        private static void SetUpRentVehicleChangeBranchForm()
        {
            changeBranch.VehicleData = vehicleData;
        }
    }
}
