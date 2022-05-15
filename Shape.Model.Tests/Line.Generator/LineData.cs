using Xml.Generator;

namespace Shape.Model.Tests;

public class LineData
    : XmlSerializedObjectData
{
    public LineData(
        int order
        , List<XmlPropertyData> propertiesData) : base(order, propertiesData)
    {
    }

    public LineData(
        string startLine
        , string stopLine
        , int order
        , List<XmlPropertyData> propertiesData) : base(startLine, stopLine, order, propertiesData)
    {
    }

    protected override void BuildBasicParts()
    {
        base.BuildBasicParts();
        BasicParts[XmlObjectParts.ObjectName] = "Line";
        BasicParts[XmlObjectParts.PropPrefix] = "  ";
        BasicParts[XmlObjectParts.ObjectPrefix] = "";
    }
}