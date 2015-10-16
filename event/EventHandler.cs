using System;
using Interfaces;
using Models;

public class EventHandler : IHandleEvents
{
    public event EventHandler<EventArguments> OnEmailSend;
    public event EventHandler<EventArguments> OnSmsSend;

    private static readonly Lazy<EventHandler> instance = new Lazy<EventHandler>(() => new EventHandler());

    public static EventHandler Instance
    {
        get { return instance.Value; }
    }

    public void TriggerOnEmailSend(EventArguments args)
    {
        OnEmailSend(this, args);
    }

    public void TriggerOnSmsSend(EventArguments args)
    {
        OnSmsSend(this, args);
    }
}
