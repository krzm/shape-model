using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Shape.Model.Tests.CustomList;

public class Color
    : IXmlSerializable
{
    public int Value { get; set; }

    public XmlSchema GetSchema() => new XmlSchema();

    public void ReadXml(XmlReader reader)
    {
        Value = int.Parse(reader.ReadElementString(), CultureInfo.InvariantCulture);
        reader.Skip();
    }

    public void WriteXml(XmlWriter writer)
    {
        writer.WriteElementString(nameof(Value), Value.ToString(CultureInfo.InvariantCulture));
    }
}