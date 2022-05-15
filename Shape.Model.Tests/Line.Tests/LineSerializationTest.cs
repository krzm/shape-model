using Xunit;

namespace Shape.Model.Tests;

public class LineSerializationTest
{
    [Fact]
    public void LineSerialization()
    {
        var test = new LineXmlTestFactory(
            new XmlOrderedGenerator(
                new LineXmlNumberedGenerator())).Order();

        test.InvokeTest();

        Assert.Equal(test.Expected, test.Acctual);
    }

    [Fact]
    public void LineSerializationHardCodedXml()
    {
        var test = new LineXmlTestFactory(new LineXml()).Order();

        test.InvokeTest();

        Assert.Equal(test.Expected, test.Acctual);
    }
}