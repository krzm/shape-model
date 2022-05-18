using Sim.Core;
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
        var testRectangle = new ShapeFactory().GetTestRectangle() as Rectangle;
        ArgumentNullException.ThrowIfNull(testRectangle);
        var test = new DeserializationTest<Rectangle>(
            new FilePath(@"C:\Tests\TestTempFiles", "RectangleDeserialization", "xml")
            , new DeserializationTestScheme<Rectangle>(
                new SerializerXml()
                , new XmlOrderedGenerator(new RectangleXmlNumberedGenerator()))
            , testRectangle);
        test.AssertFailEvent += (message) => Assert.True(false, message);
        test.IsRemovingTempFiles = true;
        return test;
    }
}