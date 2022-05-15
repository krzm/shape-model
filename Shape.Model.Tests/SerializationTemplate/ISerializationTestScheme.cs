namespace Shape.Model.Tests;

public interface ISerializationTestScheme
{
    IFileReader FileReader { get; }

    void TestingSerialization(string fileName);
}