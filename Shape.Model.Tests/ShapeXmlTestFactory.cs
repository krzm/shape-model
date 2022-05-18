using Sim.Core;
using Xml.Generator;
using Xunit;

namespace Shape.Model.Tests;

public abstract class ShapeXmlTestFactory<TShape>
    : Factory<IFileTestTemplate<string>>
{
    private IFilePath? filePath;
    private ISerializer? serializer;
    private TShape? shape;
    private IFileReader? fileReader;
    private ISerializationTestScheme? serializationTestScheme;
    private IText expectedXml;
    private IFileTestTemplate<string>? test;

    public virtual string FolderName => @"C:\Tests\TestTempFiles";

    public virtual string FileExtension => "xml";

    public abstract string FileName { get; }

    public ShapeXmlTestFactory(IText expectedXml) =>
        this.expectedXml = expectedXml ?? throw new ArgumentNullException(nameof(expectedXml));

    protected virtual IFilePath ProduceFilePath() => new FilePath(
        FolderName,
        FileName,
        FileExtension);

    protected virtual ISerializer ProduceSerializer() => new SerializerXml();

    protected abstract TShape ProduceShape();

    protected virtual IFileReader ProduceFileReader()
    {
        ArgumentNullException.ThrowIfNull(filePath);
        return new TextFileReader(filePath);
    }

    protected virtual ISerializationTestScheme ProduceSerializationTestScheme()
    {
        ArgumentNullException.ThrowIfNull(serializer);
        ArgumentNullException.ThrowIfNull(shape);
        ArgumentNullException.ThrowIfNull(fileReader);
        //todo: di
        return new SerializationTestScheme<TShape>(
            serializer,
            shape,
            fileReader);
    }

    protected virtual IText ProduceExpectedXml() => expectedXml;

    protected virtual IFileTestTemplate<string> ProduceTest()
    {
        ArgumentNullException.ThrowIfNull(filePath);
        ArgumentNullException.ThrowIfNull(serializationTestScheme);
        //todo: di
        return new SerializationTest(
            filePath,
            serializationTestScheme,
            expectedXml);
    }

    public override IFileTestTemplate<string> Order()
    {
        filePath = ProduceFilePath();
        serializer = ProduceSerializer();
        shape = ProduceShape();
        fileReader = ProduceFileReader();
        serializationTestScheme = ProduceSerializationTestScheme();
        expectedXml = ProduceExpectedXml();
        test = ProduceTest();

        test.AssertFailEvent += (message) => Assert.True(false, message);
        test.IsRemovingTempFiles = true;

        return test;
    }
}