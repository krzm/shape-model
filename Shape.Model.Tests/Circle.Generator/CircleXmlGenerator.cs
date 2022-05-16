using Xml.Generator;

namespace Shape.Model.Tests;

public class CircleXmlGenerator
    : IText
{
    private readonly IComponents<CircleComponents, IXmlSerializedObjectData>? composite;
    private readonly IComponentBuilders<CircleComponents> componentBuilders;
    private readonly IXmlCompositeObjectBuilder objectBuilder;
    private readonly IComponents<XmlFileParts, string> fileComposite;
    private readonly IXmlBuilder<XmlFileParts> fileBuilder;

    public CircleXmlGenerator()
    {
        composite = new CircleComposite();
        componentBuilders = new CircleComponentBuilders(composite
            , (property) => new XmlPropertyNumberedParser(property));
        componentBuilders.Build();
        var color = composite?.Components[CircleComponents.Color];
        ArgumentNullException.ThrowIfNull(color?.BasicParts);
        var position = color?.BasicParts[XmlObjectParts.ObjectPosition];
        ArgumentNullException.ThrowIfNull(position);
        objectBuilder = new XmlCompositeObjectBuilder(
            (parsers, innerObjOrder) => new XmlObject(parsers) { InnerObjectPosition = innerObjOrder }
            , componentBuilders.Builders[CircleComponents.Circle]
            , new IXmlBuilder<XmlObjectParts>[]
            {
                    componentBuilders.Builders[CircleComponents.Color]
                    , componentBuilders.Builders[CircleComponents.MassCenter]
                    , componentBuilders.Builders[CircleComponents.Velocity]
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