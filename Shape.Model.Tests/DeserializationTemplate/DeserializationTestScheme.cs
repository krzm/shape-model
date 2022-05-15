using Xml.Generator;

namespace Shape.Model.Tests;

public class DeserializationTestScheme<TType>
    : IDeserializationTestScheme<TType>
{
    private readonly ISerializer _serializer;

    public IText Text { get; }

    public TType DeserializedObject { get; private set; }

    public DeserializationTestScheme(
        ISerializer serializer,
        IText text)
    {
        _serializer = serializer;
        Text = text;
    }

    public void TestingDeserialization(string fileName)
    {
        File.WriteAllText(fileName, Text.Text);
        DeserializedObject = _serializer.Deserialize<TType>(fileName);
    }
}