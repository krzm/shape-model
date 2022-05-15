using Xml.Generator;

namespace Shape.Model.Tests;

public abstract class XmlSerializedObjectData
    : Validator
    , IXmlSerializedObjectData
{
    private readonly int _order;

    private readonly string _stastLine;

    private readonly string _stopLine;

    private readonly List<XmlPropertyData> _propertiesData;

    public Dictionary<XmlObjectParts, string> BasicParts { get; protected set; }

    public List<XmlProperty> Properties { get; protected set; }

    protected XmlSerializedObjectData(
        int order
        , List<XmlPropertyData> propertiesData)
    {
        _order = order > 0 ? order : throw new ArgumentNullException(nameof(order));
        _propertiesData = propertiesData ?? throw new ArgumentNullException(nameof(propertiesData));
    }

    protected XmlSerializedObjectData(
        string startLine
        , string stopLine
        , int order
        , List<XmlPropertyData> propertiesData) : this(order, propertiesData)
    {
        _stastLine = IsItText(startLine);
        _stopLine = IsItText(stopLine);
    }

    public void Build()
    {
        BuildBasicParts();
        BuildProperties();
    }

    protected virtual void BuildBasicParts() =>
        BasicParts = new Dictionary<XmlObjectParts, string>()
        {
                { XmlObjectParts.ObjectPosition, $"{_order}" }
                , { XmlObjectParts.Empty, "" }
                , { XmlObjectParts.NewLine, "\r\n" }
                , { XmlObjectParts.ObjectPrefix, "  " }
                , { XmlObjectParts.ObjectName, "" }
                , { XmlObjectParts.PropPrefix, "    " }
                , { XmlObjectParts.ObjectStartLineNr, _stastLine }
                , { XmlObjectParts.ObjectStopLineNr, _stopLine }
        };

    protected virtual void BuildProperties()
    {
        Properties = new List<XmlProperty>();
        _propertiesData.ForEach(prop => Properties.Add(GetXmlProperty(prop.Name, prop.Value, prop.Line)));
    }

    protected XmlProperty GetXmlProperty(
        string name
        , string value
        , string order = "") =>
            new XmlProperty(
                name,
                value,
                BasicParts[XmlObjectParts.PropPrefix],
                BasicParts[XmlObjectParts.NewLine],
                order);
}