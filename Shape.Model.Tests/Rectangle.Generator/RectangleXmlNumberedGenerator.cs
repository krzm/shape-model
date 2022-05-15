using Xml.Generator;

namespace Shape.Model.Tests;

public class RectangleXmlNumberedGenerator
    : IText
{
    private readonly IComponents<RectangleComponents, IXmlSerializedObjectData> _composite;
    private readonly IComponentBuilders<RectangleComponents> componentBuilders;
    private readonly IXmlCompositeObjectBuilder objectBuilder;
    private readonly IComponents<XmlFileParts, string> fileComposite;
    private readonly IXmlBuilder<XmlFileParts> fileBuilder;

    public RectangleXmlNumberedGenerator()
    {
        _composite = new RectangleNumberedComposite();
        componentBuilders = new RectangleComponentNumberedBuilders(_composite
            , (property) => new XmlPropertyNumberedParser(property));
        componentBuilders.Build();
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
            , int.Parse(_composite.Components[RectangleComponents.Color].BasicParts[XmlObjectParts.ObjectPosition]));
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