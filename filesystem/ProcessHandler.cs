using System.Diagnostics;
using Interfaces;

public class ProcessHandler : IHandleProcesses
{
    public bool ExecuteProcess(string processLocation)
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = processLocation
            }
        };
        process.Start();
        process.WaitForExit();

        return process.ExitCode == 0;
    }
}
