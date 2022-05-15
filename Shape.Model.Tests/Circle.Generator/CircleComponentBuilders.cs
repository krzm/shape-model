using Xml.Generator;

namespace Shape.Model.Tests;

public class CircleComponentBuilders
    : ComponentBuilders<CircleComponents>
{
    private readonly Func<string[], IXmlParser> _propertyParserFactory;

    public CircleComponentBuilders(
        IComponents<CircleComponents, IXmlSerializedObjectData> composite
        , Func<string[], IXmlParser> propertyParserFactory) : base(composite)
    {
        _propertyParserFactory = propertyParserFactory ?? throw new ArgumentNullException(nameof(propertyParserFactory));
    }

    public override void Build()
    {
        Builders.Add(
            CircleComponents.Circle
            , CreateBuilder(
                CircleComponents.Circle
                , _propertyParserFactory
                , false));
        Builders.Add(
            CircleComponents.Color
            , CreateBuilder(
                CircleComponents.Color
                , _propertyParserFactory));
        Builders.Add(
            CircleComponents.MassCenter
            , CreateBuilder(
                CircleComponents.MassCenter
                , _propertyParserFactory));
        Builders.Add(
            CircleComponents.Velocity
            , CreateBuilder(
                CircleComponents.Velocity
                , _propertyParserFactory));
    }

    protected override XmlObjectWithPropsBuilder CreateBuilder(
        CircleComponents type
        , Func<string[], IXmlParser> propertyParserFactory
        , bool isEndingWithNewLine = true)
    {
        var data = Composite.Components[type];
        return new XmlObjectWithPropsBuilder(
            data.BasicParts
            , data.Properties
            , propertyParserFactory
            , isEndingWithNewLine);
    }
}