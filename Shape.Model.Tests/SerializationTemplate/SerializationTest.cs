using Sim.Core;
using Xml.Generator;

namespace Shape.Model.Tests;

public class SerializationTest
    : FileTestTemplate<string>
{
    private readonly ISerializationTestScheme shapeSerialization;

    public SerializationTest(
        IFilePath filePath,
        ISerializationTestScheme shapeSerialization,
        IText expected) : base(filePath, expected.Text) =>
            this.shapeSerialization = shapeSerialization;

    protected override void Testing()
    {
        shapeSerialization.TestingSerialization(FilePath.FullPath);
        Acctual = shapeSerialization.FileReader.OutputAsString;
    }
}