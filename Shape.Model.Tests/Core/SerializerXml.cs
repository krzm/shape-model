using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Shape.Model.Tests;

public class SerializerXml : Serializer
{
    public override string ToString() => nameof(SerializerXml);

    protected override void TrySerialize<TType>(TType data, string filePath)
    {
        using (Stream stream = File.Open(filePath, FileMode.Create, FileAccess.ReadWrite))
        {
            var writer = new XmlTextWriter(stream, Encoding.UTF8)
            {
                Formatting = Formatting.Indented
            };
            var serializer = new XmlSerializer(typeof(TType));
            serializer.Serialize(writer, data);
            writer.Close();
        }
    }

    protected override TType TryDeserialize<TType>(string filePath)
    {
        var serializer = new XmlSerializer(typeof(TType));
        TType data;
        using (Stream stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            var obj = serializer.Deserialize(stream);
            data = (TType)obj;
        }
        return data;
    }
}