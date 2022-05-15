using Xml.Generator;

namespace Shape.Model.Tests;

public class FileParts
    : IComponents<XmlFileParts, string>
{
    public Dictionary<XmlFileParts, string> Components { get; }

    public FileParts()
    {
        Components = new Dictionary<XmlFileParts, string>
            {
                { XmlFileParts.Prefix, "" }
                , { XmlFileParts.Header, "<?xml version=\"1.0\" encoding=\"utf-8\"?>" }
                , { XmlFileParts.Postfix, "\r\n" }
            };
    }
}