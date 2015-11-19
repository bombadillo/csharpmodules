using System;
using System.IO;
using Interfaces;

public class FileArchiver : IArchiveFiles
{
    private readonly ILog Logger;
    private readonly ICreateFolders FolderCreator;
    private readonly IMoveFiles FileMover;

    private string TodaysArchivePath;

    public FileArchiver(ILog logger, ICreateFolders folderCreator,
        IMoveFiles fileMover)
    {
        Logger = logger;
        FolderCreator = folderCreator;
        FileMover = fileMover;
    }

    public void ArchiveFiles(string[] fileNames, string baseDirectory)
    {
        CreateArchiveFolders(baseDirectory);

        foreach (var file in fileNames)
        {
            MoveFile(file);
        }
    }

    public void ArchiveFile(string fileName, string baseDirectory)
    {
        CreateArchiveFolders(baseDirectory);

        MoveFile(fileName);
    }

    private void CreateArchiveFolders(string baseDirectory)
    {
        var date = DateTime.Now.ToString("yyyy-MM-dd-");
        var unixTimeStamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        var archivePath = baseDirectory + @"\archive";
        TodaysArchivePath = string.Format(@"{0}\{1}-{2}", archivePath, date, unixTimeStamp);

        FolderCreator.Create(TodaysArchivePath);
    }

    private void MoveFile(string file)
    {
        var fileName = Path.GetFileName(file);
        var from = file;
        var to = string.Format(@"{0}\{1}", TodaysArchivePath, fileName);

        FileMover.Move(from ,to);
    }


    public void ArchiveDirectoryContents(string directory)
    {
        CreateArchiveFolders(directory);
        var files = Directory.GetFiles(directory);

        foreach (var file in files)
        {
            MoveFile(file);
        }
    }
}
