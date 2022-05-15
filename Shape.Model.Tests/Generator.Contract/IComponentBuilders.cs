using Xml.Generator;

namespace Shape.Model.Tests;

public interface IComponentBuilders<TComponents>
{
    Dictionary<TComponents, IXmlBuilder<XmlObjectParts>> Builders { get; }

    void Build();
}