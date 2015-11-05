using System.IO;
using Interfaces;

public class FileWriter : IWriteFile
{
    public void WriteStringToFile(string data, string fileName)
    {
        using (var sw = new StreamWriter(fileName, true))
        {
            sw.Write(data);
        }
    }
}
