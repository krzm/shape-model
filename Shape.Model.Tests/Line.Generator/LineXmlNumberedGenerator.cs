using Xml.Generator;

namespace Shape.Model.Tests;

public class LineXmlNumberedGenerator
    : IText
{
    private readonly IComponents<LineComponents, IXmlSerializedObjectData> composite;
    private readonly IComponentBuilders<LineComponents> componentBuilders;
    private readonly IXmlCompositeObjectBuilder objectBuilder;
    protected readonly IXmlBuilder<XmlFileParts> FileBuilder;
    private readonly IComponents<XmlFileParts, string> fileComposite;

    public LineXmlNumberedGenerator()
    {
        composite = new LineNumberedComposite();
        componentBuilders = new LineComponentNumberedBuilders(composite
            , (property) => new XmlPropertyNumberedParser(property));
        componentBuilders.Build();
        objectBuilder = new XmlCompositeObjectNumberedBuilder(
            (parsers, innerObjOrder) => new XmlObjectNumbered(parsers) { InnerObjectPosition = innerObjOrder }
            , componentBuilders.Builders[LineComponents.Line]
            , new IXmlBuilder<XmlObjectParts>[]
            {
                    componentBuilders.Builders[LineComponents.Color]
                    , componentBuilders.Builders[LineComponents.MassCenter]
                    , componentBuilders.Builders[LineComponents.Velocity]
                    , componentBuilders.Builders[LineComponents.SecondPoint]
            }
            , int.Parse(composite.Components[LineComponents.Color].BasicParts[XmlObjectParts.ObjectPosition]));
        fileComposite = new FileParts();
        FileBuilder = new XmlFileNumberedBuilder(
            new IText[] { objectBuilder.CreateXml() }
            , (parts) =>
                new XmlFileParser(
                    (headerParts) => new XmlHeaderNumberedParser(headerParts)
                    , parts)
            , fileComposite.Components);
    }

    public virtual string Text => FileBuilder.CreateXml().Text;
}