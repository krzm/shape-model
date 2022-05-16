using Xml.Generator;

namespace Shape.Model.Tests;

public interface IComponentBuilders<TComponents>
    where TComponents : notnull
{
    Dictionary<TComponents, IXmlBuilder<XmlObjectParts>> Builders { get; }

    void Build();
}