namespace Shape.Model.Tests;

public abstract class IndirectSerializationTest<TMediatorType, TImmutableType>
    : FileTestTemplate<TImmutableType>
{
    private readonly ISerializer _serializer;

    protected TMediatorType DeserializedMediator;

    protected IndirectSerializationTest(
        IFilePath filePath,
        ISerializer serializer,
        TImmutableType expected) : base(filePath, expected) => _serializer = serializer;

    protected override void Testing()
    {
        SerializeMediator(CreateMediatorType());
        Acctual = CreateImmutableType();
    }

    protected abstract TMediatorType CreateMediatorType();

    private void SerializeMediator(TMediatorType serializableObject)
    {
        _serializer.Serialize(serializableObject, FilePath.FullPath);
        DeserializedMediator = _serializer.Deserialize<TMediatorType>(FilePath.FullPath);
    }

    protected abstract TImmutableType CreateImmutableType();
}