using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Shape.Model.Tests.CustomList;

public class MoneyContext
    : IXmlSerializable
{
    public List<Money> Valueables { get; set; }

    public MoneyContext()
    {
        Valueables = new List<Money>();
    }

    public XmlSchema GetSchema()
    {
        throw new NotImplementedException();
    }

    public void ReadXml(XmlReader reader)
    {
        reader.Read();
        while (!reader.EOF)
        {
            if (reader.IsStartElement(nameof(Gold)))
            {
                var gold = new Gold();
                gold.ReadXml(reader);
                Valueables.Add(gold);
                reader.Skip();
                continue;
            }
            if (reader.IsStartElement(nameof(Dolar)))
            {
                var dolar = new Dolar();
                dolar.ReadXml(reader);
                Valueables.Add(dolar);
                reader.Skip();
                continue;
            }
            reader.Skip();
        }
    }

    public void WriteXml(XmlWriter writer)
    {
        foreach (var item in Valueables)
        {
            if (item is Gold)
                writer.WriteStartElement(nameof(Gold));
            if (item is Dolar)
                writer.WriteStartElement(nameof(Dolar));
            item.WriteXml(writer);
            writer.WriteEndElement();
        }
    }
}