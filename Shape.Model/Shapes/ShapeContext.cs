using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Shape.Model;

public class ShapeContext : IXmlSerializable
{
    public List<Shape> Shapes { get; set; }

    public InfoContext InfoContext { get; private set; } = new InfoContext();

    public ShapeContext()
    {
        Shapes = new List<Shape>();
    }

    public XmlSchema GetSchema() => throw new NotImplementedException();

    public void ReadXml(XmlReader reader)
    {
        try
        {
            reader.Read();
            while (!reader.EOF)
            {
                if (InfoContext.Get(nameof(Line)) == 6)
                {

                }
                if (reader.IsStartElement(nameof(Circle)))
                {
                    var obj = new Circle();
                    obj.ReadXml(reader);
                    Shapes.Add(obj);
                    InfoContext.Add(nameof(Circle));
                    reader.Skip();
                    continue;
                }
                if (reader.IsStartElement(nameof(Line)))
                {
                    var obj = new Line();
                    obj.ReadXml(reader);
                    Shapes.Add(obj);
                    InfoContext.Add(nameof(Line));
                    reader.Skip();
                    continue;
                }
                if (reader.IsStartElement(nameof(Rectangle)))
                {
                    var obj = new Rectangle();
                    obj.ReadXml(reader);
                    Shapes.Add(obj);
                    InfoContext.Add(nameof(Rectangle));
                    reader.Skip();
                    continue;
                }
                reader.Skip();
            }
        }
        catch (Exception)
        {
        }
    }

    public void WriteXml(XmlWriter writer)
    {
        foreach (var item in Shapes)
        {
            if (item is Circle)
                writer.WriteStartElement(nameof(Circle));
            if (item is Line)
                writer.WriteStartElement(nameof(Line));
            if (item is Rectangle)
                writer.WriteStartElement(nameof(Rectangle));
            item.WriteXml(writer);
            writer.WriteEndElement();
        }
    }
}