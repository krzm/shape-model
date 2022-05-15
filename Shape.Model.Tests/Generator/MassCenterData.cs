using Xml.Generator;

namespace Shape.Model.Tests;

public class MassCenterData
    : XmlSerializedObjectData
{
    public MassCenterData(
        int order
        , List<XmlPropertyData> propertiesData) : base(order, propertiesData)
    {
    }

    public MassCenterData(
        string startLine
        , string stopLine
        , int order
        , List<XmlPropertyData> propertiesData) : base(startLine, stopLine, order, propertiesData)
    {
    }

    protected override void BuildBasicParts()
    {
        base.BuildBasicParts();
        BasicParts[XmlObjectParts.ObjectName] = "MassCenter";
    }
}