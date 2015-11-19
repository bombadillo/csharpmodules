using System;
using System.IO;
using Interfaces;

public class FileMover : IMoveFiles
{
    private readonly ILog Logger;

    public FileMover(ILog logger)
    {
        Logger = logger;
    }

    public void Move(string from, string to)
    {
        try
        {
            File.Move(from, to);
            Logger.Trace("File archived: " + from);
        }
        catch (Exception e)
        {
            Logger.Error(string.Format("Failed to move file {0}. {1}", from, e.Message));
        }
    }
}
