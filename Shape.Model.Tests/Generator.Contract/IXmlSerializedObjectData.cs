using Xml.Generator;

namespace Shape.Model.Tests;

public interface IXmlSerializedObjectData
{
    Dictionary<XmlObjectParts, string>? BasicParts { get; }

    List<XmlProperty>? Properties { get; }

    void Build();
}