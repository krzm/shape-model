namespace Shape.Model.Tests;

public class CircleDataFactory
    : DataFactory
{
    public List<XmlPropertyData> OrderCircle()
    {
        return new List<XmlPropertyData>()
            {
                GetProp("03", "TextFlag", "black")
                , GetProp("04", "Context", "Physic")
                , GetProp("23", "IsColorFilled", "True")
                , GetProp("24", "Mass", "10")
                , GetProp("25", "RelativeImagePath", @"Images\ball8.bmp")
                , GetProp("26", "Radius", "20")
            };
    }

    public List<XmlPropertyData> OrderColor()
    {
        return new List<XmlPropertyData>()
            {
                GetProp("06", "A", "0")
                , GetProp("07", "R", "0")
                , GetProp("08", "G", "0")
                , GetProp("09", "B", "0")
                , GetProp("10", "ScA", "0")
                , GetProp("11", "ScR", "0")
                , GetProp("12", "ScG", "0")
                , GetProp("13", "ScB", "0")
            };
    }

    public List<XmlPropertyData> OrderMassCenter()
    {
        return new List<XmlPropertyData>()
            {
                GetProp("16", "X", "10")
                , GetProp("17", "Y", "10")
            };
    }

    public List<XmlPropertyData> OrderVelocity()
    {
        return new List<XmlPropertyData>()
            {
                GetProp("20", "X", "0")
                , GetProp("21", "Y", "0")
            };
    }
}