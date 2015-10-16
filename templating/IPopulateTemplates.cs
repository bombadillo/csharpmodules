using System.Collections.Generic;

public interface IPopulateTemplates
{
    string PopulateFromList(string templateName, List<string> data);
    string PopulateFromDictionary(string templateName, Dictionary<string, string> data);
}
