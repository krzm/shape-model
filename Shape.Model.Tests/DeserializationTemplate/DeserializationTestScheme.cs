using Xml.Generator;

namespace Shape.Model.Tests;

public class DeserializationTestScheme<TType>
    : IDeserializationTestScheme<TType>
{
    private readonly ISerializer serializer;

    public IText Text { get; }

    public TType? DeserializedObject { get; private set; }

    public DeserializationTestScheme(
        ISerializer serializer,
        IText text)
    {
        this.serializer = serializer;
        Text = text;
    }

    public void TestingDeserialization(string fileName)
    {
        File.WriteAllText(fileName, Text.Text);
        DeserializedObject = serializer.Deserialize<TType>(fileName);
    }
}