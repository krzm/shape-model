using System.Xml.Serialization;

namespace Shape.Model.Tests;

public class SerializerXmlB
    : Serializer
{
    public override string ToString() => nameof(SerializerXmlB);

    protected override TType TryDeserialize<TType>(string filePath)
    {
        var serializer = new XmlSerializer(typeof(TType));
        TType data;
        using (var streamIn = new System.IO.FileStream(filePath, System.IO.FileMode.Open))
        {
            var obj = serializer.Deserialize(streamIn);
            ArgumentNullException.ThrowIfNull(obj);
            data = (TType)obj;
        }
        return data;
    }

    protected override void TrySerialize<TType>(TType data, string filePath)
    {
        var serializer = new XmlSerializer(typeof(TType));
        using (var streamOut = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
        {
            serializer.Serialize
            (
                streamOut,
                data
            );
        }
    }
}