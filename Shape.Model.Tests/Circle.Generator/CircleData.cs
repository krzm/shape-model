using Xml.Generator;

namespace Shape.Model.Tests;

public class CircleData
    : XmlSerializedObjectData
{
    public CircleData(
        int order
        , List<XmlPropertyData> propertiesData)
            : base(order, propertiesData)
    {
    }

    public CircleData(
        string startLine
        , string stopLine
        , int order
        , List<XmlPropertyData> propertiesData) : base(startLine, stopLine, order, propertiesData)
    {
    }

    protected override void BuildBasicParts()
    {
        base.BuildBasicParts();
        BasicParts[XmlObjectParts.ObjectPrefix] = "";
        BasicParts[XmlObjectParts.ObjectName] = "Circle";
        BasicParts[XmlObjectParts.PropPrefix] = "  ";
    }
}