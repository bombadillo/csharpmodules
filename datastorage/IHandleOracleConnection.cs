using Oracle.ManagedDataAccess.Client;
public interface IHandleOracleConnection
{
    OracleConnection GetConnection();
}
