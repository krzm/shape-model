using Xml.Generator;

namespace Shape.Model.Tests;

public class LineComponentBuilders
    : ComponentBuilders<LineComponents>
{
    private readonly Func<string[], IXmlParser> _propertyParserFactory;

    public LineComponentBuilders(
        IComponents<LineComponents, IXmlSerializedObjectData> composite
        , Func<string[], IXmlParser> propertyParserFactory) : base(composite)
    {
        _propertyParserFactory = propertyParserFactory ?? throw new ArgumentNullException(nameof(propertyParserFactory));
    }

    public override void Build()
    {
        Builders.Add(
            LineComponents.Line
            , CreateBuilder(LineComponents.Line, _propertyParserFactory, false));
        Builders.Add(
            LineComponents.Color
            , CreateBuilder(LineComponents.Color, _propertyParserFactory));
        Builders.Add(
            LineComponents.MassCenter
            , CreateBuilder(LineComponents.MassCenter, _propertyParserFactory));
        Builders.Add(
            LineComponents.Velocity
            , CreateBuilder(LineComponents.Velocity, _propertyParserFactory));
        Builders.Add(
            LineComponents.SecondPoint
            , CreateBuilder(LineComponents.SecondPoint, _propertyParserFactory));
    }

    protected override XmlObjectWithPropsBuilder CreateBuilder(
        LineComponents type
        , Func<string[], IXmlParser> propertyParserFactory
        , bool isEndingWithNewLine = true)
    {
        var data = Composite.Components[type];
        return new XmlObjectWithPropsBuilder(data.BasicParts
            , data.Properties
            , propertyParserFactory
            , isEndingWithNewLine);
    }
}