using Xml.Generator;

namespace Shape.Model.Tests;

public class RectangleComponentBuilders
    : ComponentBuilders<RectangleComponents>
{
    private readonly Func<string[], IXmlParser> propertyParserFactory;

    public RectangleComponentBuilders(
        IComponents<RectangleComponents, IXmlSerializedObjectData> composite
        , Func<string[], IXmlParser> propertyParserFactory)
            : base(composite)
    {
        this.propertyParserFactory = propertyParserFactory;
    }

    public override void Build()
    {
        Builders.Add(
            RectangleComponents.Rectangle
            , CreateBuilder(
                RectangleComponents.Rectangle
                , propertyParserFactory
                , false));
        Builders.Add(
            RectangleComponents.Color
            , CreateBuilder(
                RectangleComponents.Color
                , propertyParserFactory));
        Builders.Add(
            RectangleComponents.MassCenter
            , CreateBuilder(
                RectangleComponents.MassCenter
                , propertyParserFactory));
        Builders.Add(
            RectangleComponents.Velocity
            , CreateBuilder(
                RectangleComponents.Velocity
                , propertyParserFactory));
        Builders.Add(
            RectangleComponents.Size
            , CreateBuilder(
                RectangleComponents.Size
                , propertyParserFactory));
    }

    protected override XmlObjectWithPropsBuilder CreateBuilder(
        RectangleComponents type
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