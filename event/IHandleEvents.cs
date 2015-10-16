using Models;
using System;

public interface IHandleEvents
{
    event EventHandler<EventArguments> OnEmailSend;
    event EventHandler<EventArguments> OnSmsSend;

    void TriggerOnEmailSend(EventArguments args);
    void TriggerOnSmsSend(EventArguments args);
}
