using Xml.Generator;

namespace Shape.Model.Tests;

public class LineXmlGenerator
    : IText
{
    private readonly IComponents<LineComponents, IXmlSerializedObjectData>? composite;
    private readonly IComponentBuilders<LineComponents> componentBuilders;
    private readonly IXmlCompositeObjectBuilder objectBuilder;
    private readonly IXmlBuilder<XmlFileParts> fileBuilder;
    private readonly IComponents<XmlFileParts, string> fileComposite;

    public LineXmlGenerator()
    {
        composite = new LineComposite();
        componentBuilders = new LineComponentBuilders(composite
            , (property) => new XmlPropertyNumberedParser(property));
        componentBuilders.Build();
        var color = composite?.Components[LineComponents.Color];
        ArgumentNullException.ThrowIfNull(color?.BasicParts);
        var position = color?.BasicParts[XmlObjectParts.ObjectPosition];
        ArgumentNullException.ThrowIfNull(position);
        objectBuilder = new XmlCompositeObjectBuilder(
            (parsers, innerObjOrder) => new XmlObject(parsers) { InnerObjectPosition = innerObjOrder }
            , componentBuilders.Builders[LineComponents.Line]
            , new IXmlBuilder<XmlObjectParts>[]
            {
                    componentBuilders.Builders[LineComponents.Color]
                    , componentBuilders.Builders[LineComponents.MassCenter]
                    , componentBuilders.Builders[LineComponents.Velocity]
                    , componentBuilders.Builders[LineComponents.SecondPoint]
            }
            , int.Parse(position));
        fileComposite = new FileParts();
        fileBuilder = new XmlFileBuilder(
            new IText[] { objectBuilder.CreateXml() }
            , (parts) =>
                new XmlFileParser(
                    (headerParts) => new XmlHeaderParser(headerParts)
                    , parts)
            , fileComposite.Components);
    }

    public string Text => fileBuilder.CreateXml().Text;
}