using System;
using System.Runtime.ExceptionServices;
using Interfaces;

public class ExceptionHandler : IHandleExceptions
{
    private readonly ILog Logger;

    public ExceptionHandler(ILog logger)
    {
        Logger = logger;
    }

    public void SetupExceptionHandling()
    {
        AppDomain.CurrentDomain.FirstChanceException += FirstChanceExceptionTrapper;
        AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
    }

    public void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
    {
        Environment.Exit(1);
    }

    public void FirstChanceExceptionTrapper(object sender, FirstChanceExceptionEventArgs e)
    {
        LogMessage(e);
    }

    private void LogMessage(FirstChanceExceptionEventArgs e)
    {
        Logger.Error(e.Exception.Message);

        if (e.Exception.InnerException != null)
        {
            Logger.Error(e.Exception.InnerException.ToString());
        }

        if (e.Exception.StackTrace != null)
        {
            Logger.Error(e.Exception.StackTrace);
        }
    }
}
