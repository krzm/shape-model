namespace Shape.Model.Tests;

public class SerializationTestScheme<TType>
    : ISerializationTestScheme
{
    private readonly ISerializer _serializer;

    private readonly TType _serializedObject;

    public IFileReader FileReader { get; }

    public SerializationTestScheme(
        ISerializer serializer,
        TType serializedObject,
        IFileReader fileReader)
    {
        _serializer = serializer;
        _serializedObject = serializedObject;
        FileReader = fileReader;
    }

    public void TestingSerialization(string fileName)
    {
        _serializer.Serialize(_serializedObject, fileName);
        FileReader.ReadingData();
    }
}