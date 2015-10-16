using System;
using System.Collections.Generic;

public interface IBuildExceptionMessages
{
    Dictionary<string, string> GetFullMesssage(UnhandledExceptionEventArgs e);
}
