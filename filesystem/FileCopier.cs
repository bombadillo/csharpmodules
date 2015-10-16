using System;
using System.IO;
using Interfaces;

public class FileCopier : ICopyFiles
{
    private readonly ILog Logger;

    public FileCopier(ILog logger)
    {
        Logger = logger;
    }

    public bool CopyFile(string from, string to)
    {
        var backedUp = false;

        try
        {
            File.Copy(from, to, true);
            Logger.Info(string.Format("Copying {0} to {1}", from, to));
            backedUp = File.Exists(to);
        }
        catch (Exception e)
        {
            Logger.Error("Failed to backup the file: " + e.Message);

        }

        return backedUp;
    }
}
