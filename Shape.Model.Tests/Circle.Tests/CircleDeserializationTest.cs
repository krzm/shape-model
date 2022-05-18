using System.Windows;
using Sim.Core;
using Xunit;

namespace Shape.Model.Tests;

public class CircleDeserializationTest
{
    [Fact]
    public void CircleSerialization()
    {
        var test = SetupTest();
        test.InvokeTest();
        Assert.Equal(test.Expected, test.Acctual);
    }

    private static IFileTestTemplate<Circle> SetupTest()
    {
        var folderName = @"C:\Tests\TestTempFiles";
        var fileName = "BlackBallDeserialization";
        var fileExtension = "xml";

        IFilePath filePath = new FilePath(
            folderName
            , fileName
            , fileExtension);

        var massCenter = new Point(10, 10);
        var circle = new ShapeFactory().GetBlackBall(massCenter) as Circle;
        ArgumentNullException.ThrowIfNull(circle);
        IDeserializationTestScheme<Circle> testScheme =
        new DeserializationTestScheme<Circle>(
                new SerializerXml()
                , new CircleXmlGenerator());

        IFileTestTemplate<Circle> test =
            new DeserializationTest<Circle>(
                filePath
                , testScheme
                , circle);

        test.AssertFailEvent += (message) => Assert.True(false, message);
        test.IsRemovingTempFiles = true;

        return test;
    }
}