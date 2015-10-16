using Oracle.DataAccess.Client;
public interface IHandleOracleConnection
{
    OracleConnection GetConnection();
}
