using System.Windows;
using Xunit;

namespace Shape.Model.Tests;

public class CircleSerializationCycleTest
{
    [Fact]
    public void CircleSerialization()
    {
        var test = SetupTest();
        test.InvokeTest();
        Assert.Equal(test.Expected, test.Acctual);
    }

    private ITestTemplate<Circle> SetupTest()
    {
        var folderName = @"C:\Tests\TestTempFiles";
        var fileName = "BlackBallFullSerialization";
        var fileExtension = "xml";

        IFilePath filePath = new FilePath(
            folderName
            , fileName
            , fileExtension);

        var massCenter = new Point(10, 10);
        var circle = new ShapeFactory().GetBlackBall(massCenter) as Circle;
        ArgumentNullException.ThrowIfNull(circle);
        ISerializer serializer = new SerializerXml();

        IFileTestTemplate<Circle> test =
        new SerializationCycleTest<Circle>(
            filePath
            , serializer
            , circle);

        test.AssertFailEvent += (message) => Assert.True(false, message);
        test.IsRemovingTempFiles = true;

        return test;
    }
}