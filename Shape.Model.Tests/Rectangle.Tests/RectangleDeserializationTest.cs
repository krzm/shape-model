using Xunit;

namespace Shape.Model.Tests;

public class RectangleDeserializationTest
{
    [Fact]
    public void RectangleDeserialization()
    {
        var test = SetupTest();

        test.InvokeTest();

        Assert.Equal(test.Expected, test.Acctual);
    }

    private static IFileTestTemplate<Rectangle> SetupTest()
    {
        var test = new DeserializationTest<Rectangle>(
            new FilePath(@"C:\Tests\TestTempFiles", "RectangleDeserialization", "xml")
            , new DeserializationTestScheme<Rectangle>(
                new SerializerXml()
                , new XmlOrderedGenerator(new RectangleXmlNumberedGenerator()))
            , new ShapeFactory().GetTestRectangle() as Rectangle);
        test.AssertFailEvent += (message) => Assert.True(false, message);
        test.IsRemovingTempFiles = true;
        return test;
    }
}