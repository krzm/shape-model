using Xml.Generator;

namespace Shape.Model.Tests;

public class RectangleXmlGenerator
    : IText
{
    private readonly IComponents<RectangleComponents, IXmlSerializedObjectData>? composite;
    private readonly IComponentBuilders<RectangleComponents> componentBuilders;
    private readonly IXmlCompositeObjectBuilder objectBuilder;
    private readonly IComponents<XmlFileParts, string> fileComposite;
    private readonly IXmlBuilder<XmlFileParts> fileBuilder;

    public RectangleXmlGenerator()
    {
        composite = new RectangleComposite();
        componentBuilders = new RectangleComponentBuilders(composite
            , (property) => new XmlPropertyNumberedParser(property));
        componentBuilders.Build();
        var color = composite?.Components[RectangleComponents.Color];
        ArgumentNullException.ThrowIfNull(color?.BasicParts);
        var position = color?.BasicParts[XmlObjectParts.ObjectPosition];
        ArgumentNullException.ThrowIfNull(position);
        objectBuilder = new XmlCompositeObjectBuilder(
            (parsers, innerObjOrder) => new XmlObject(parsers) { InnerObjectPosition = innerObjOrder }
            , componentBuilders.Builders[RectangleComponents.Rectangle]
            , new IXmlBuilder<XmlObjectParts>[]
            {
                    componentBuilders.Builders[RectangleComponents.Color]
                    , componentBuilders.Builders[RectangleComponents.MassCenter]
                    , componentBuilders.Builders[RectangleComponents.Velocity]
                    , componentBuilders.Builders[RectangleComponents.Size]
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