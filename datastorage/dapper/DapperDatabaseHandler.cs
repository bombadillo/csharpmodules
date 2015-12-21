using System.Linq;
using Dapper;
using Interfaces;
using System.Collections.Generic;

public class DatabaseHandler<T> : IHandleDatabase<T>
{
    private readonly IHandleDatabaseConnection DatabaseConnectionHandler;
    private readonly ILoadSql SqlLoader;

    public DatabaseHandler(IHandleDatabaseConnection databaseConnectionHandler, ILoadSql sqlLoader)
    {
        DatabaseConnectionHandler = databaseConnectionHandler;
        SqlLoader = sqlLoader;
    }

    public T GetById(string sqlFile, int id)
    {
        var sql = SqlLoader.LoadFromFile(sqlFile);
        DatabaseConnectionHandler.GetConnection();

        using (var con = DatabaseConnectionHandler.Con)
        {
            return con.Query<T>(sql, new { id }).FirstOrDefault();
        }
    }

    public IEnumerable<T> GetAll(string sqlFile, object queryArguments = null,
        object[] templateArguments = null)
    {
        var sql = SqlLoader.LoadFromFile(sqlFile, templateArguments);

        DatabaseConnectionHandler.GetConnection();

        using (var con = DatabaseConnectionHandler.Con)
        {
            return con.Query<T>(sql, queryArguments);
        }
    }


    public T GetByCustomSql(string sqlFile, object queryArguments = null, object[] templateArguments = null)
    {
        var sql = SqlLoader.LoadFromFile(sqlFile, templateArguments);
        DatabaseConnectionHandler.GetConnection();

        using (var con = DatabaseConnectionHandler.Con)
        {
            return con.Query<T>(sql, queryArguments).FirstOrDefault();
        }
    }
}
