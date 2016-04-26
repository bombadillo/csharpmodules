    using System.Data;
    using System;
    using Interfaces;
    using Oracle.ManagedDataAccess.Client;
    using System.Configuration;

    public class DatabaseConnectionHandler : IHandleDatabaseConnection
    {
        private readonly ILog Logger;

        public OracleConnection Con { get; set; }

        private readonly string OracleConnectionString = ConfigurationManager.AppSettings["OracleConnection"];

        public DatabaseConnectionHandler(ILog logger)
        {
            Logger = logger;
        }

        public void GetConnection()
        {
            Con = new OracleConnection
            {
                ConnectionString = OracleConnectionString
            };

            if (Con.State != ConnectionState.Open)
            {
                OpenConnection();   
            }                      
        }

        private void OpenConnection()
        {
            try
            {
                Con.Open();
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to open Oracle connection." + ex.Message);
            }
        }


        public void CloseConnection()
        {
            Con.Dispose();
        }
    }
