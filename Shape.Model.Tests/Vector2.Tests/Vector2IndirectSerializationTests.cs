using Sim.Core;
using Vector.Lib;
using Xunit;

namespace Shape.Model.Tests;

public class Vector2IndirectSerializationTests
{
    [Theory]
    [InlineData(1.0d, 2.0d)]
    [InlineData(.1d, 6.6d)]
    [InlineData(0.0d, 0.0d)]
    [InlineData(-.1d, -1.0d)]
    public void Vector2IndirectSerializationA(double x, double y)
    {
        var test = SetupTest(x, y, new SerializerXml());

        test.InvokeTest();

        Assert.Equal(test.Expected, test.Acctual);
    }

    [Theory]
    [InlineData(1.0d, 2.0d)]
    [InlineData(.1d, 6.6d)]
    [InlineData(0.0d, 0.0d)]
    [InlineData(-.1d, -1.0d)]
    public void Vector2IndirectSerializationB(double x, double y)
    {
        var test = SetupTest(x, y, new SerializerXmlB());

        test.InvokeTest();

        Assert.Equal(test.Expected, test.Acctual);
    }

    private static IFileTestTemplate<Vector2> SetupTest(double x, double y, ISerializer serializer)
    {
        IFilePath filePath = new FilePath(@"C:\Tests\TestTempFiles", $"Vector2IndirectSerializationA({x},{y})", "xml");
        var test = new Vector2IndirectSerializationTest(
            filePath
            , serializer
            , new Vector2(x, y));
        test.AssertFailEvent += (message) => Assert.True(false, message);
        test.IsRemovingTempFiles = true;
        return test;
    }
}