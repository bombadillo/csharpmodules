public interface IArchiveFiles
{
    void ArchiveFiles(string[] fileNames, string baseDirectory);
    void ArchiveFile(string fileName, string baseDirectory);
    void ArchiveDirectoryContents(string directory);
}
