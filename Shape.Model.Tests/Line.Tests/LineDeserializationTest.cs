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
        var shape = new ShapeFactory().GetTestLine() as Line;
        ArgumentNullException.ThrowIfNull(shape);
        var test = new DeserializationTest<Line>(
            new FilePath(@"C:\Tests\TestTempFiles", "LineDeserialization", "xml")
            , new DeserializationTestScheme<Line>(
                new SerializerXml()
                , new XmlOrderedGenerator(
                    new LineXmlNumberedGenerator()))
            , shape);
        test.AssertFailEvent += (message) => Assert.True(false, message);
        test.IsRemovingTempFiles = true;
        return test;
    }
}