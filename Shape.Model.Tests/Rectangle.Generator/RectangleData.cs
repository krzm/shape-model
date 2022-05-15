using Xml.Generator;

namespace Shape.Model.Tests;

public class RectangleData
    : XmlSerializedObjectData
{
    public RectangleData(
        int order
        , List<XmlPropertyData> propertiesData)
            : base(order, propertiesData)
    {
    }

    public RectangleData(
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
        BasicParts[XmlObjectParts.ObjectName] = "Rectangle";
        BasicParts[XmlObjectParts.PropPrefix] = "  ";
    }
}