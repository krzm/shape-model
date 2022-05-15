using Vector.Lib;
using Xunit;

namespace Shape.Model.Tests;

public class Vector2SerializationCycleTest
{
    [Theory]
    [InlineData(1.0d, 2.0d)]
    [InlineData(.1d, 6.6d)]
    [InlineData(0.0d, 0.0d)]
    [InlineData(-.1d, -1.0d)]
    public void Vector2SerializationCycle(double x, double y)
    {
        var test = SetupTest(x, y);

        test.InvokeTest();

        Assert.Equal(test.Expected, test.Acctual);
    }

    private static IFileTestTemplate<Vector2> SetupTest(double x, double y)
    {
        IFilePath filePath = new FilePath(@"C:\Tests\TestTempFiles", $"Vector2FullSerialization({x},{y})", "xml");
        var test = new SerializationCycleTest<Vector2>(
            filePath
            , new SerializerXml()
            , new Vector2(x, y));
        test.AssertFailEvent += (message) => Assert.True(false, message);
        test.IsRemovingTempFiles = true;
        return test;
    }
}