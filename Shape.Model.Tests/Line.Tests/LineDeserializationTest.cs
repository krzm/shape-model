using Xunit;

namespace Shape.Model.Tests;

public class LineDeserializationTest
{
    [Fact]
    public void LineDeserialization()
    {
        var test = SetupTest();

        test.InvokeTest();

        Assert.Equal(test.Expected, test.Acctual);
    }

    private static IFileTestTemplate<Line> SetupTest()
    {
        var test = new DeserializationTest<Line>(
            new FilePath(@"C:\Tests\TestTempFiles", "LineDeserialization", "xml"),
            new DeserializationTestScheme<Line>(
                new SerializerXml(),
                new XmlOrderedGenerator(
                    new LineXmlNumberedGenerator())),
            new ShapeFactory().GetTestLine() as Line);
        test.AssertFailEvent += (message) => Assert.True(false, message);
        test.IsRemovingTempFiles = true;
        return test;
    }
}