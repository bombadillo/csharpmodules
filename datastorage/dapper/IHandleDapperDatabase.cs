using System.Collections.Generic;

public interface IHandleDatabase<T>
{
    T GetById(string sqlFile, int id);
    T GetByCustomSql(string sqlFile, object queryArguments = null, object[] templateArguments = null);
    IEnumerable<T> GetAll(string sqlFile, object queryArguments = null, object[] templateArguments = null);
    T GetOne(string sqlFile, object queryArguments = null, object[] templateArguments = null);
    bool Insert(string sqlFile, object queryArguments = null, object[] templateArguments = null);
}
