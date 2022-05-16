using System.Windows;
using Xunit;

namespace Shape.Model.Tests;

public class CircleSerializationTest
{
    [Fact]
    public void CircleSerialization()
    {
        var test = SetupTest();
        test.InvokeTest();
        Assert.Equal(test.Expected, test.Acctual);
    }

    private static IFileTestTemplate<string> SetupTest()
    {
        var folderName = @"C:\Tests\TestTempFiles";
        var fileName = "BlackBallSerialization";
        var fileExtension = "xml";

        IFilePath filePath = new FilePath(
            folderName
            , fileName
            , fileExtension);

        var massCenter = new Point(10, 10);
        ISerializer serializer = new SerializerXml();
        var circle = new ShapeFactory().GetBlackBall(massCenter) as Circle;
        ArgumentNullException.ThrowIfNull(circle);
        IFileReader fileReader = new TextFileReader(filePath);
        ISerializationTestScheme testScheme =
        new SerializationTestScheme<Circle>(
            serializer
            , circle
            , fileReader);
        IFileTestTemplate<string> test =
            new SerializationTest(
                filePath
                , testScheme
                , new CircleXmlGenerator());
        test.AssertFailEvent += (message) => Assert.True(false, message);
        test.IsRemovingTempFiles = true;
        return test;
    }
}