using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Shape.Model.Tests.CustomList;

public abstract class Money
    : IXmlSerializable
{
    public string? Type { get; set; }

    public XmlSchema GetSchema() => new XmlSchema();

    public virtual void ReadXml(XmlReader reader)
    {
        Type = reader.ReadElementString();
    }

    public virtual void WriteXml(XmlWriter writer)
    {
        writer.WriteElementString(nameof(Type), Type?.ToString());
    }
}