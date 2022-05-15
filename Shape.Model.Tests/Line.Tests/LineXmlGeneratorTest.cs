using Xunit;

namespace Shape.Model.Tests;

public class LineXmlGeneratorTest
{
    [Fact]
    public void LineExpected() =>
        Assert.NotEqual(
            new LineXml().Text
            , new LineXmlGenerator().Text);

    [Fact]
    public void LineNumberedExpected() =>
        Assert.Equal(
            new LineXmlNumbered().Text
            , new LineXmlNumberedGenerator().Text);

    [Fact]
    public void LineOrderedExpected() =>
        Assert.Equal(
            new LineXml().Text
            , new XmlOrderedGenerator(new LineXmlNumberedGenerator()).Text);
}