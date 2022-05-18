using Sim.Core;

namespace Shape.Model.Tests;

public class DeserializationTest<TType>
    : FileTestTemplate<TType>
{
    protected readonly IDeserializationTestScheme<TType> ShapeDeserialization;

    public DeserializationTest(
        IFilePath filePath,
        IDeserializationTestScheme<TType> shapeDeserialization,
        TType expected) : base(filePath, expected) =>
            ShapeDeserialization = shapeDeserialization;

    protected override void Testing()
    {
        ShapeDeserialization.TestingDeserialization(FilePath.FullPath);
        Acctual = ShapeDeserialization.DeserializedObject;
    }

    public override string ToString() => $"{base.ToString()}{MyConst.NewLine}Used xml: {MyConst.NewLine}{ShapeDeserialization.Text.Text}";
}