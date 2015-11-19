using System.IO;
using Interfaces;

public class FolderCreator : ICreateFolders
{
    public void Create(string directory)
    {
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
    }
}
