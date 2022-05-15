namespace Shape.Model.Tests;

public class SerializationCycleTest<TType>
    : FileTestTemplate<TType>
{
    private readonly ISerializer serializer;

    public SerializationCycleTest(
        IFilePath filePath,
        ISerializer serializer,
        TType expected) : base(filePath, expected) =>
            this.serializer = serializer;

    protected override void Testing()
    {
        serializer.Serialize(Expected, FilePath.FullPath);
        var deserialized = serializer.Deserialize<TType>(FilePath.FullPath);
        Acctual = deserialized;
    }
}