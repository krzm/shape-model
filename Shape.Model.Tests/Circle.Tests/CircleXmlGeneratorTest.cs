using Xunit;

namespace Shape.Model.Tests;

public class CircleXmlGeneratorTest
{
    [Fact]
    public void CircleExpected() =>
        Assert.Equal(
            new CircleXml().Text
            , new CircleXmlGenerator().Text);

    [Fact]
    public void CircleNumberedExpected() =>
        Assert.Equal(
            new CircleXmlNumbered().Text
            , new CircleXmlNumberedGenerator().Text);

    [Fact]
    public void CircleOrderedExpected() =>
        Assert.Equal(
            new CircleXml().Text
            , new XmlOrderedGenerator(new CircleXmlNumberedGenerator()).Text);
}