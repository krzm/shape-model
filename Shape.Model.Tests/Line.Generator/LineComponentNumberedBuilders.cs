using Xml.Generator;

namespace Shape.Model.Tests;

public class LineComponentNumberedBuilders
    : LineComponentBuilders
{
    public LineComponentNumberedBuilders(
        IComponents<LineComponents, IXmlSerializedObjectData> composite
        , Func<string[], IXmlParser> propertyParserFactory)
            : base(composite, propertyParserFactory)
    {
    }

    protected override XmlObjectWithPropsBuilder CreateBuilder(
        LineComponents type
        , Func<string[], IXmlParser> propertyParserFactory
        , bool isEndingWithNewLine = true)
    {
        var data = Composite.Components[type];
        var parts = data.BasicParts;
        ArgumentNullException.ThrowIfNull(parts);
        var props = data.Properties;
        ArgumentNullException.ThrowIfNull(props);
        return new XmlObjectNumberedBuilder(
            parts
            , props
            , propertyParserFactory
            , isEndingWithNewLine);
    }
}