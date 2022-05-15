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
        return new XmlObjectNumberedBuilder(data.BasicParts
            , data.Properties
            , propertyParserFactory
            , isEndingWithNewLine);
    }
}