using System.Globalization;
using Vector.Lib;
using Xml.Generator;
using Xunit;

namespace Shape.Model.Tests;

public class Vector2DeserializationTest
{
    [Theory]
    [InlineData(1.0d, 2.0d)]
    [InlineData(.1d, 6.6d)]
    [InlineData(0.0d, 0.0d)]
    [InlineData(-.1d, -1.0d)]
    public void Vector2Deserialization(double x, double y)
    {
        var test = SetupTest(x, y);

        test.InvokeTest();

        Assert.Equal(test.Expected, test.Acctual);
    }

    private static IFileTestTemplate<Vector2> SetupTest(double x, double y)
    {
        IFilePath filePath = new FilePath(@"C:\Tests\TestTempFiles", $"Vector2Deserialization({x},{y})", "xml");
        var test = new DeserializationTest<Vector2>(
            filePath
            , new DeserializationTestScheme<Vector2>(
                new SerializerXml()
                , BuildExpectedXml(x, y))
            , new Vector2(x, y));
        test.AssertFailEvent += (message) => Assert.True(false, message);
        test.IsRemovingTempFiles = true;
        return test;
    }

    private static IText BuildExpectedXml(double x, double y)
    {
        var _xmlObjParts = new Dictionary<XmlObjectParts, string> {
                { XmlObjectParts.Empty, "" },
                { XmlObjectParts.ObjectPrefix, "" },
                { XmlObjectParts.ObjectName, "Vector2" },
                { XmlObjectParts.PropPrefix, "  " },
                { XmlObjectParts.Property1, "X" },
                { XmlObjectParts.Value1, $"{x.ToString(CultureInfo.InvariantCulture)}" },
                { XmlObjectParts.Property2, "Y" },
                { XmlObjectParts.Value2, $"{y.ToString(CultureInfo.InvariantCulture)}" },
                { XmlObjectParts.NewLine, "\r\n" }};
        var xmlObjBuilder = new XmlObjectBuilder(_xmlObjParts
            , (property) => new XmlPropertyParser(property)
            , false).CreateXml();
        var xmlFile = new XmlFile(
            new IXmlParser[] {
                    new XmlFileParser(
                        (headerParts) => new XmlHeaderParser(headerParts)
                        , "", "\r\n") }
            , xmlObjBuilder);
        return xmlFile;
    }
}