using System.Data.SqlClient;

public interface IHandleSqlConnection
{
    SqlConnection GetConnection();
}
