namespace Shape.Model.Tests;

public abstract class IndirectSerializationTest<TMediatorType, TImmutableType>
    : FileTestTemplate<TImmutableType>
{
    private readonly ISerializer serializer;
    protected TMediatorType? DeserializedMediator;

    protected IndirectSerializationTest(
        IFilePath filePath,
        ISerializer serializer,
        TImmutableType expected)
            : base(filePath, expected) => 
                this.serializer = serializer;

    protected override void Testing()
    {
        SerializeMediator(CreateMediatorType());
        Acctual = CreateImmutableType();
    }

    protected abstract TMediatorType CreateMediatorType();

    private void SerializeMediator(TMediatorType serializableObject)
    {
        serializer.Serialize(serializableObject, FilePath.FullPath);
        DeserializedMediator = serializer.Deserialize<TMediatorType>(FilePath.FullPath);
    }

    protected abstract TImmutableType CreateImmutableType();
}