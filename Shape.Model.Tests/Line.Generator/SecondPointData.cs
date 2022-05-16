using Xml.Generator;

namespace Shape.Model.Tests;

public class SecondPointData
    : XmlSerializedObjectData
{
    public SecondPointData(
        int order
        , List<XmlPropertyData> propertiesData)
            : base(order, propertiesData)
    {
    }

    public SecondPointData(
        string startLine
        , string stopLine
        , int order
        , List<XmlPropertyData> propertiesData)
            : base(startLine, stopLine, order, propertiesData)
    {
    }

    protected override void BuildBasicParts()
    {
        base.BuildBasicParts();
        ArgumentNullException.ThrowIfNull(BasicParts);
        BasicParts[XmlObjectParts.ObjectPrefix] = "  ";
        BasicParts[XmlObjectParts.ObjectName] = "SecondPoint";
        BasicParts[XmlObjectParts.PropPrefix] = "    ";
    }
}