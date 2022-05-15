using Xml.Generator;

namespace Shape.Model.Tests;

public class CircleXmlGenerator
    : IText
{
    private readonly IComponents<CircleComponents, IXmlSerializedObjectData> _composite;
    private readonly IComponentBuilders<CircleComponents> _componentBuilders;
    private readonly IXmlCompositeObjectBuilder _objectBuilder;
    private readonly IComponents<XmlFileParts, string> _fileComposite;
    private readonly IXmlBuilder<XmlFileParts> _fileBuilder;

    public CircleXmlGenerator()
    {
        _composite = new CircleComposite();
        _componentBuilders = new CircleComponentBuilders(_composite
            , (property) => new XmlPropertyNumberedParser(property));
        _componentBuilders.Build();
        _objectBuilder = new XmlCompositeObjectBuilder(
            (parsers, innerObjOrder) => new XmlObject(parsers) { InnerObjectPosition = innerObjOrder }
            , _componentBuilders.Builders[CircleComponents.Circle]
            , new IXmlBuilder<XmlObjectParts>[]
            {
                    _componentBuilders.Builders[CircleComponents.Color]
                    , _componentBuilders.Builders[CircleComponents.MassCenter]
                    , _componentBuilders.Builders[CircleComponents.Velocity]
            }
            , int.Parse(_composite.Components[CircleComponents.Color].BasicParts[XmlObjectParts.ObjectPosition]));
        _fileComposite = new FileParts();
        _fileBuilder = new XmlFileBuilder(
            new IText[] { _objectBuilder.CreateXml() }
            , (parts) =>
                new XmlFileParser(
                    (headerParts) => new XmlHeaderParser(headerParts)
                    , parts)
            , _fileComposite.Components);
    }

    public string Text => _fileBuilder.CreateXml().Text;
}