using System.Collections.Generic;

public interface IHandleDatabase<T>
{
    T GetById(string sql, int id);
    T GetByCustomSql(string sql, object args = null,
        object[] templateArguments = null);
    IEnumerable<T> GetAll(string sql, object args = null,
        object[] templateArguments = null);
}
