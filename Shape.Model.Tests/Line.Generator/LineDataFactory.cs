namespace Shape.Model.Tests;

public class LineDataFactory
    : DataFactory
{
    public List<XmlPropertyData> OrderLine()
    {
        return new List<XmlPropertyData>()
            {
                GetProp("03", "Context", "Physic")
                , GetProp("22", "IsColorFilled", "True")
                , GetProp("23", "Mass", "10")
                , GetProp("24", "RelativeImagePath", "")
            };
    }

    public List<XmlPropertyData> OrderColor()
    {
        return new List<XmlPropertyData>()
            {
                GetProp("05", "A", "255")
                , GetProp("06", "R", "255")
                , GetProp("07", "G", "0")
                , GetProp("08", "B", "0")
                , GetProp("09", "ScA", "1")
                , GetProp("10", "ScR", "1")
                , GetProp("11", "ScG", "0")
                , GetProp("12", "ScB", "0")
            };
    }

    public List<XmlPropertyData> OrderMassCenter()
    {
        return new List<XmlPropertyData>()
            {
                GetProp("15", "X", "334")
                , GetProp("16", "Y", "680")
            };
    }

    public List<XmlPropertyData> OrderVelocity()
    {
        return new List<XmlPropertyData>()
            {
                GetProp("19", "X", "0")
                , GetProp("20", "Y", "0")
            };
    }

    public List<XmlPropertyData> OrderSecondPoint()
    {
        return new List<XmlPropertyData>()
            {
                GetProp("26", "X", "299")
                , GetProp("27", "Y", "713")
            };
    }
}