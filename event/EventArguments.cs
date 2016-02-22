using System;
using System.Collections.Generic;

public class EventArguments : EventArgs
{
    public Dictionary<string, string> List { get; set; }
    public CustomerOrder Order { get; set; }

    public EventArguments()
    {
        List = new Dictionary<string, string>();
    }
}
