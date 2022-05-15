using Xml.Generator;

namespace Shape.Model.Tests;

public class CircleXmlNumberedGenerator
    : IText
{
    private readonly IComponents<CircleComponents, IXmlSerializedObjectData> composite;
    private readonly IComponentBuilders<CircleComponents> componentBuilders;
    private readonly IXmlCompositeObjectBuilder objectBuilder;
    private readonly IXmlBuilder<XmlFileParts> fileBuilder;
    private readonly IComponents<XmlFileParts, string> fileComposite;

    public CircleXmlNumberedGenerator()
    {
        composite = new CircleNumberedComposite();
        componentBuilders = new CircleComponentNumberedBuilders(composite
            , (property) => new XmlPropertyNumberedParser(property));
        componentBuilders.Build();
        objectBuilder = new XmlCompositeObjectNumberedBuilder(
            (parsers, innerObjOrder) => new XmlObjectNumbered(parsers) { InnerObjectPosition = innerObjOrder }
            , componentBuilders.Builders[CircleComponents.Circle]
            , new IXmlBuilder<XmlObjectParts>[]
            {
                    componentBuilders.Builders[CircleComponents.Color]
                    , componentBuilders.Builders[CircleComponents.MassCenter]
                    , componentBuilders.Builders[CircleComponents.Velocity]
            }
            , int.Parse(composite.Components[CircleComponents.Color].BasicParts[XmlObjectParts.ObjectPosition]));
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