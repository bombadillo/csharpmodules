using System;
using System.Data.SqlClient;
using Interfaces;
using System.Configuration;

public class SqlConnectionHandler : IHandleSqlConnection
{
    private readonly ILog Logger;

    private SqlConnection Con;
    private readonly string SqlConnectionString = ConfigurationManager.AppSettings["SqlConnectionString"];

    public SqlConnectionHandler(ILog logger)
    {
        Logger = logger;
    }

    public SqlConnection GetConnection()
    {
        if (Con == null)
        {
            try
            {
                Con = new SqlConnection(ConfigurationManager.AppSettings["DbConnectString"]);
                Logger.Trace("Connected to DB");
            }
            catch (Exception e)
            {
                Logger.Fatal("Unable to connect to database. " + e.Message);
                Environment.Exit(1);
            }
        }

        return Con;
    }
}
