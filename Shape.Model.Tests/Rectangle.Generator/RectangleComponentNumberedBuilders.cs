using Xml.Generator;

namespace Shape.Model.Tests;

public class RectangleComponentNumberedBuilders
    : RectangleComponentBuilders
{
    public RectangleComponentNumberedBuilders(
        IComponents<RectangleComponents, IXmlSerializedObjectData> composite
        , Func<string[], IXmlParser> propertyParserFactory)
            : base(composite, propertyParserFactory)
    {
    }

    protected override XmlObjectWithPropsBuilder CreateBuilder(
        RectangleComponents type
        , Func<string[], IXmlParser> propertyParserFactory
        , bool isEndingWithNewLine = true)
    {
        var data = Composite.Components[type];
        var parts = data?.BasicParts;
        var props = data?.Properties;
        ArgumentNullException.ThrowIfNull(parts);
        ArgumentNullException.ThrowIfNull(props);
        return new XmlObjectNumberedBuilder(
            parts
            , props
            , propertyParserFactory
            , isEndingWithNewLine);
    }
}