using Xml.Generator;

namespace Shape.Model.Tests;

public class LineXmlGenerator
    : IText
{
    private readonly IComponents<LineComponents, IXmlSerializedObjectData> _composite;
    private readonly IComponentBuilders<LineComponents> _componentBuilders;
    private readonly IXmlCompositeObjectBuilder _objectBuilder;
    private readonly IXmlBuilder<XmlFileParts> _fileBuilder;
    private readonly IComponents<XmlFileParts, string> _fileComposite;

    public LineXmlGenerator()
    {
        _composite = new LineComposite();
        _componentBuilders = new LineComponentBuilders(_composite
            , (property) => new XmlPropertyNumberedParser(property));
        _componentBuilders.Build();
        _objectBuilder = new XmlCompositeObjectBuilder(
            (parsers, innerObjOrder) => new XmlObject(parsers) { InnerObjectPosition = innerObjOrder }
            , _componentBuilders.Builders[LineComponents.Line]
            , new IXmlBuilder<XmlObjectParts>[]
            {
                    _componentBuilders.Builders[LineComponents.Color]
                    , _componentBuilders.Builders[LineComponents.MassCenter]
                    , _componentBuilders.Builders[LineComponents.Velocity]
                    , _componentBuilders.Builders[LineComponents.SecondPoint]
            }
            , int.Parse(_composite.Components[LineComponents.Color].BasicParts[XmlObjectParts.ObjectPosition]));
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