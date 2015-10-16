using System.Collections.Generic;
using System.IO;
using System.Configuration;
using Interfaces;

public class TemplatePopulater : IPopulateTemplates
{
    public string PopulateFromList(string templateName, List<string> data)
    {
        var templateContents = LoadTemplate(templateName);

        return string.Format(templateContents, data.ToArray());
    }

    public string PopulateFromDictionary(string templateName, Dictionary<string, string> data)
    {
        var templatecontents = LoadTemplate(templateName);

        foreach (var item in data)
        {
            var replaceItem = string.Format("%%{0}%%", item.Key);
            templatecontents = templatecontents.Replace(replaceItem, item.Value);
        }

        return templatecontents;
    }

    private string LoadTemplate(string templateName)
    {
        var templateLocation = string.Format("{0}{1}.tmpl", ConfigurationManager.AppSettings["TemplateFolder"], templateName);
        var templateContents = File.ReadAllText(templateLocation);

        return templateContents;
    }
}
