using System.Collections.Generic;
using System;
using Interfaces;

public class ExceptionMessageBuilder : IBuildExceptionMessages
{
    private const string UndefinedMessage = "Not set";

    public Dictionary<string, string> GetFullMesssage(UnhandledExceptionEventArgs e)
    {
        var eventObject = (Exception)e.ExceptionObject;

        var innerException = eventObject.InnerException != null ? eventObject.InnerException.ToString() : UndefinedMessage;
        var stackTrace = eventObject.StackTrace ?? UndefinedMessage;
        var helpLink = eventObject.HelpLink ?? UndefinedMessage;
        var source = eventObject.Source ?? UndefinedMessage;
        var targetSite = eventObject.TargetSite != null ? eventObject.TargetSite.ToString() : UndefinedMessage;

        var message = new Dictionary<string, string>
        {
            {"message", eventObject.Message},
            {"innerException", innerException},
            {"stackTrace", stackTrace},
            {"targetSite", targetSite},
            {"source", source},
            {"helpLink", helpLink}
        };

        return message;
    }
}
