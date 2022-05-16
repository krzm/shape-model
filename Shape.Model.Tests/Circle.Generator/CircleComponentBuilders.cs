using Xml.Generator;

namespace Shape.Model.Tests;

public class CircleComponentBuilders
    : ComponentBuilders<CircleComponents>
{
    private readonly Func<string[], IXmlParser> propertyParserFactory;

    public CircleComponentBuilders(
        IComponents<CircleComponents, IXmlSerializedObjectData> composite
        , Func<string[], IXmlParser> propertyParserFactory)
            : base(composite)
    {
        this.propertyParserFactory = propertyParserFactory ??
            throw new ArgumentNullException(nameof(propertyParserFactory));
    }

    public override void Build()
    {
        Builders.Add(
            CircleComponents.Circle
            , CreateBuilder(
                CircleComponents.Circle
                , propertyParserFactory
                , false));
        Builders.Add(
            CircleComponents.Color
            , CreateBuilder(
                CircleComponents.Color
                , propertyParserFactory));
        Builders.Add(
            CircleComponents.MassCenter
            , CreateBuilder(
                CircleComponents.MassCenter
                , propertyParserFactory));
        Builders.Add(
            CircleComponents.Velocity
            , CreateBuilder(
                CircleComponents.Velocity
                , propertyParserFactory));
    }

    protected override XmlObjectWithPropsBuilder CreateBuilder(
        CircleComponents type
        , Func<string[], IXmlParser> propertyParserFactory
        , bool isEndingWithNewLine = true)
    {
        var data = Composite.Components[type];
        var parts = data.BasicParts;
        ArgumentNullException.ThrowIfNull(parts);
        var props = data.Properties;
        ArgumentNullException.ThrowIfNull(props);
        return new XmlObjectWithPropsBuilder(
            parts
            , props
            , propertyParserFactory
            , isEndingWithNewLine);
    }
}