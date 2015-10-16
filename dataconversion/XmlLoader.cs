using System.Xml;
using Interfaces;

public class XmlLoader : ILoadXml
{
    public XmlDocument LoadDocument(string fileName)
    {
        var doc = new XmlDocument();

        try
        {
            doc.Load(fileName);
        }
        catch (XmlException ex)
        {
            // log
        }

        return doc;
    }
}
