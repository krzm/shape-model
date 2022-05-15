using Xunit;

namespace Shape.Model.Tests;

public class RectangleSerializationTest
{
    [Fact]
    public void RectangleSerialization()
    {
        var test = new RectangleXmlTestFactory(
            new XmlOrderedGenerator(
                new RectangleXmlNumberedGenerator())).Order();

        test.InvokeTest();

        Assert.Equal(test.Expected, test.Acctual);
    }
}