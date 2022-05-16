using Vector.Lib;

namespace Shape.Model.Tests;

public class Vector2IndirectSerializationTest
    : IndirectSerializationTest<Vector2Serializable, Vector2>
{
    public Vector2IndirectSerializationTest(
        IFilePath filePath,
        ISerializer serializer,
        Vector2 expected) : base(filePath, serializer, expected)
    { }

    protected override Vector2 CreateImmutableType()
    {
        ArgumentNullException.ThrowIfNull(DeserializedMediator);
        return new Vector2(DeserializedMediator.X, DeserializedMediator.Y);
    }
        

    protected override Vector2Serializable CreateMediatorType() =>
        new Vector2Serializable { X = Expected.X, Y = Expected.Y };
}