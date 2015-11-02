using Oracle.ManagedDataAccess.Client;
using Interfaces;
using System.Configuration;

public class OracleConnectionHandler : IHandleOracleConnection
{
    private readonly ILog Logger;

    private OracleConnection Con;
    private readonly string OracleConnectionString = ConfigurationManager.AppSettings["OracleConnection"];

    public OracleConnectionHandler(ILog logger)
    {
        Logger = logger;
    }

    public OracleConnection GetConnection()
    {
        if (Con == null)
        {
            Con = new OracleConnection
            {
                ConnectionString = OracleConnectionString
            };

            Con.Open();
        }

        return Con;
    }
}
