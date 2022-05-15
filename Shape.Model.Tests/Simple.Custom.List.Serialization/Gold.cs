using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

namespace Shape.Model.Tests.CustomList;

public class Gold
    : Money
    , IXmlSerializable
{
    public int WeightInOunces { get; set; }

    public Color Color { get; set; }

    public Gold()
    {
        Color = new Color();
    }

    public override void ReadXml(XmlReader reader)
    {
        base.ReadXml(reader);
        WeightInOunces = int.Parse(reader.ReadElementString(), CultureInfo.InvariantCulture);
        if (reader.IsStartElement(nameof(Color)))
        {
            Color.ReadXml(reader);
        }
    }

    public override void WriteXml(XmlWriter writer)
    {
        base.WriteXml(writer);
        writer.WriteElementString(nameof(WeightInOunces), WeightInOunces.ToString(CultureInfo.InvariantCulture));
        writer.WriteStartElement(nameof(Color));
        Color.WriteXml(writer);
        writer.WriteEndElement();
    }
}