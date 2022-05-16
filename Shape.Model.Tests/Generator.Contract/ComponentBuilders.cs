using Xml.Generator;

namespace Shape.Model.Tests;

public abstract class ComponentBuilders<TComponents>
    : IComponentBuilders<TComponents>
        where TComponents : notnull
{
    protected readonly IComponents<TComponents, IXmlSerializedObjectData> Composite;

    public Dictionary<TComponents, IXmlBuilder<XmlObjectParts>> Builders { get; }

    protected ComponentBuilders(
        IComponents<TComponents, IXmlSerializedObjectData> composite)
    {
        Composite = composite;
        Builders = new Dictionary<TComponents, IXmlBuilder<XmlObjectParts>>();
    }

    public abstract void Build();

    protected abstract XmlObjectWithPropsBuilder CreateBuilder(
        TComponents type
        , Func<string[], IXmlParser> propertyParserFactory
        , bool isEndingWithNewLine = true);
}