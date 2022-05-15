using Xml.Generator;

namespace Shape.Model.Tests;

public class SerializationBothFilesTest : FilesTestTemplate<string>
{
    private readonly ISerializationTestScheme _shapeSerialization;

    public SerializationBothFilesTest(
        Dictionary<string, IFilePath> filePaths
        , ISerializationTestScheme shapeSerialization
        , IText expected) 
            : base(filePaths, expected.Text) =>
            _shapeSerialization = shapeSerialization;

    protected override void Testing()
    {
        _shapeSerialization.TestingSerialization(AcctualFilePath.FullPath);
        Acctual = _shapeSerialization.FileReader.OutputAsString;
        File.WriteAllText(ExpectedFilePath.FullPath, Expected);
    }
}