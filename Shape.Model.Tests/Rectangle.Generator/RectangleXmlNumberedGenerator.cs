using Xml.Generator;

namespace Shape.Model.Tests;

public class RectangleXmlNumberedGenerator
    : IText
{
    private readonly IComponents<RectangleComponents, IXmlSerializedObjectData>? composite;
    private readonly IComponentBuilders<RectangleComponents> componentBuilders;
    private readonly IXmlCompositeObjectBuilder objectBuilder;
    private readonly IComponents<XmlFileParts, string> fileComposite;
    private readonly IXmlBuilder<XmlFileParts> fileBuilder;

    public RectangleXmlNumberedGenerator()
    {
        composite = new RectangleNumberedComposite();
        componentBuilders = new RectangleComponentNumberedBuilders(composite
            , (property) => new XmlPropertyNumberedParser(property));
        componentBuilders.Build();
        var color = composite?.Components[RectangleComponents.Color];
        ArgumentNullException.ThrowIfNull(color?.BasicParts);
        var position = color?.BasicParts[XmlObjectParts.ObjectPosition];
        ArgumentNullException.ThrowIfNull(position);
        objectBuilder = new XmlCompositeObjectNumberedBuilder(
            (parsers, innerObjOrder) => new XmlObjectNumbered(parsers) { InnerObjectPosition = innerObjOrder }
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
        fileBuilder = new XmlFileNumberedBuilder(
            new IText[] { objectBuilder.CreateXml() }
            , (parts) =>
                new XmlFileParser(
                    (headerParts) => new XmlHeaderNumberedParser(headerParts)
                    , parts)
            , fileComposite.Components);
    }

    public string Text => fileBuilder.CreateXml().Text;
}