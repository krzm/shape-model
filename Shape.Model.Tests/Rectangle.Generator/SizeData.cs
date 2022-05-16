using Xml.Generator;

namespace Shape.Model.Tests;

public class SizeData
    : XmlSerializedObjectData
{
    public SizeData(
        int order
        , List<XmlPropertyData> propertiesData)
            : base(order, propertiesData)
    {
    }

    public SizeData(
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
        BasicParts[XmlObjectParts.ObjectName] = "Size";
        BasicParts[XmlObjectParts.PropPrefix] = "    ";
    }
}