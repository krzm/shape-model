using Xml.Generator;

namespace Shape.Model.Tests;

public class ColorData
    : XmlSerializedObjectData
{
    public ColorData(
        int order
        , List<XmlPropertyData> propertiesData) : base(order, propertiesData)
    {
    }

    public ColorData(
        string startLine
        , string stopLine
        , int order
        , List<XmlPropertyData> propertyData) : base(startLine, stopLine, order, propertyData)
    {
    }

    protected override void BuildBasicParts()
    {
        base.BuildBasicParts();
        BasicParts[XmlObjectParts.ObjectName] = "Color";
    }
}