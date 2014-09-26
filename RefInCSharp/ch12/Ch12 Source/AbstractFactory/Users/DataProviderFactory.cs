using System;
using System.Data;

namespace Users
{
public abstract class DataProviderFactory
{

    public const String MsSqlProviderName = "System.Data.SqlClient";

    public const String OracleProviderName = "System.Data.OracleClient";

    public const String OleDbProviderName = "System.Data.OleDb";

    public const String DbConfigurationSectionName = "DataEntry";

    private static String connectionString;

    private static String databaseProviderName;

    public static String ConnectionString
    {
        get { return DataProviderFactory.connectionString; }
        set { DataProviderFactory.connectionString = value; }
    }

    public static String DatabaseProviderName
    {
        get { return DataProviderFactory.databaseProviderName; }
        set { DataProviderFactory.databaseProviderName = value; }
    }
          
    public static DataProviderFactory CreateDataProviderFactory(
        String providerName)
    {
        DataProviderFactory concreteFactory = null;
        switch (providerName) { 
            case DataProviderFactory.MsSqlProviderName:
                concreteFactory = new MsSqlProviderFactory();
                break;
            case DataProviderFactory.OracleProviderName:
                concreteFactory = new OracleProviderFactory();
                break;
            case DataProviderFactory.OleDbProviderName:
                concreteFactory = new OleDbProviderFactory();
                break;
        }
        return concreteFactory;
    }

    public abstract IDbCommand CreateCommand();
    
    public abstract IDbConnection CreateConnection();
}
}
