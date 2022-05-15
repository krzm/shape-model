using Xunit;

namespace Shape.Model.Tests;

public class RectangleSerializationCycleTest
{
    [Fact]
    public void RectangleSerializationCycle()
    {
        var test = SetupTest();

        test.InvokeTest();

        Assert.Equal(test.Expected, test.Acctual);
    }

    private static IFileTestTemplate<Rectangle> SetupTest()
    {
        var test = new SerializationCycleTest<Rectangle>(
            new FilePath(@"C:\Tests\TestTempFiles", "RectangleFullSerialization", "xml"),
            new SerializerXml(),
            new ShapeFactory().GetTestRectangle() as Rectangle);
        test.AssertFailEvent += (message) => Assert.True(false, message);
        test.IsRemovingTempFiles = true;
        return test;
    }
}