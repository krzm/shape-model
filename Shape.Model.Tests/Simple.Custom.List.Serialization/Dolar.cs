using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

namespace Shape.Model.Tests.CustomList;

public class Dolar
    : Money
    , IXmlSerializable
{
    public int FaceValue { get; set; }

    public Dolar()
    {

    }

    public override void ReadXml(XmlReader reader)
    {
        base.ReadXml(reader);
        FaceValue = int.Parse(reader.ReadElementString(), CultureInfo.InvariantCulture);
    }

    public override void WriteXml(XmlWriter writer)
    {
        base.WriteXml(writer);
        writer.WriteElementString(nameof(FaceValue), FaceValue.ToString(CultureInfo.InvariantCulture));
    }
}