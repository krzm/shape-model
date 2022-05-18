using Sim.Core;
using Xunit;

namespace Shape.Model.Tests;

public class LineSerializationCycleTest
{
    [Fact]
    public void LineSerializationCycle()
    {
        var test = SetupTest();

        test.InvokeTest();

        Assert.Equal(test.Expected, test.Acctual);
    }

    private static IFileTestTemplate<Line> SetupTest()
    {
        var shape = new ShapeFactory().GetTestLine() as Line;
        ArgumentNullException.ThrowIfNull(shape);
        var test = new SerializationCycleTest<Line>(
            new FilePath(@"C:\Tests\TestTempFiles", "LineFullSerialization", "xml")
            , new SerializerXml()
            , shape);
        test.AssertFailEvent += (message) => Assert.True(false, message);
        test.IsRemovingTempFiles = true;
        return test;
    }
}