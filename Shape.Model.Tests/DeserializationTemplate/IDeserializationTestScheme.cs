using Xml.Generator;

namespace Shape.Model.Tests;

public interface IDeserializationTestScheme<TType>
{
    IText Text { get; }

    TType? DeserializedObject { get; }

    void TestingDeserialization(string fileName);
}