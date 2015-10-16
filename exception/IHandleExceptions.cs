using System;
using System.Runtime.ExceptionServices;

public interface IHandleExceptions
{
    void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e);
    void FirstChanceExceptionTrapper(object sender, FirstChanceExceptionEventArgs e);

    void SetupExceptionHandling();
}
