using Xml.Generator;

namespace Shape.Model.Tests;

public class VelocityData
    : XmlSerializedObjectData
{
    public VelocityData(
        int order
        , List<XmlPropertyData> propertiesData)
            : base(order, propertiesData)
    {
    }

    public VelocityData(
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
        BasicParts[XmlObjectParts.ObjectName] = "Velocity";
    }
}