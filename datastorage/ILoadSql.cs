public interface ILoadSql
{
    string LoadFromFile(string fileName, object[] templateArguments = null);
}
