using Xunit;

namespace Shape.Model.Tests;

public class RectangleXmlGeneratorTest
{
    [Fact]
    public void RectangleExpected() =>
        Assert.NotEqual(
            new RectangleXml().Text
            , new RectangleXmlGenerator().Text);

    [Fact]
    public void RectangleNumberedExpected() =>
        Assert.Equal(
            new RectangleNumberedXml().Text
            , new RectangleXmlNumberedGenerator().Text);

    [Fact]
    public void RectangleOrderedExpected() =>
        Assert.Equal(
            new RectangleXml().Text
            , new XmlOrderedGenerator(new RectangleXmlNumberedGenerator()).Text);
}