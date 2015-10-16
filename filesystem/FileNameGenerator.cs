using System.IO;
using System.Text.RegularExpressions;
using Interfaces;

public class FileNameGenerator : IGenerateFileNames
{
    public string ProcessFileName(string desiredFileName)
    {
        var fileName = CreateNewFileName(desiredFileName);

        return fileName;
    }

    private string CreateNewFileName(string desiredFileName)
    {
        var fileName = desiredFileName;
        var fileExists = CheckFileExists(desiredFileName);

        var fileNameAppendage = 0;
        while (fileExists)
        {
            fileNameAppendage++;
            fileName = Regex.Replace(fileName, @"[\d-]", string.Empty);
            fileName = AddFileNameAppendage(fileName, fileNameAppendage);
            fileExists = CheckFileExists(fileName);
        }

        return fileName;
    }

    private string AddFileNameAppendage(string fileName, int fileNameAppendage)
    {
        var split = fileName.Split('.');
        var newFileName = string.Format("{0}{1}.{2}", split[0], fileNameAppendage, split[1]);

        return newFileName;
    }

    private bool CheckFileExists(string desiredFileName)
    {
        return File.Exists(desiredFileName);
    }
}
