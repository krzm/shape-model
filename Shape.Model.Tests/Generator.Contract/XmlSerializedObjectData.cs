using Xml.Generator;

namespace Shape.Model.Tests;

public abstract class XmlSerializedObjectData
    : Validator
    , IXmlSerializedObjectData
{
    private readonly int order;
    private readonly string? stastLine;
    private readonly string? stopLine;
    private readonly List<XmlPropertyData>? propertiesData;

    public Dictionary<XmlObjectParts, string>? BasicParts { get; protected set; }

    public List<XmlProperty>? Properties { get; protected set; }

    protected XmlSerializedObjectData(
        int order
        , List<XmlPropertyData> propertiesData)
    {
        this.order = order > 0 ? order : throw new ArgumentException(nameof(order), "must be > 0");
        this.propertiesData = propertiesData ?? throw new ArgumentNullException(nameof(propertiesData));
    }

    protected XmlSerializedObjectData(
        string startLine
        , string stopLine
        , int order
        , List<XmlPropertyData> propertiesData) : this(order, propertiesData)
    {
        stastLine = IsItText(startLine);
        this.stopLine = IsItText(stopLine);
    }

    public void Build()
    {
        BuildBasicParts();
        BuildProperties();
    }

    protected virtual void BuildBasicParts()
    {
        BasicParts = new Dictionary<XmlObjectParts, string>()
        {
            { XmlObjectParts.ObjectPosition, $"{order}" }
            , { XmlObjectParts.Empty, "" }
            , { XmlObjectParts.NewLine, "\r\n" }
            , { XmlObjectParts.ObjectPrefix, "  " }
            , { XmlObjectParts.ObjectName, "" }
            , { XmlObjectParts.PropPrefix, "    " }
            , { XmlObjectParts.ObjectStartLineNr, stastLine ?? string.Empty }
            , { XmlObjectParts.ObjectStopLineNr, stopLine ?? string.Empty }
        };
    }

    protected virtual void BuildProperties()
    {
        Properties = new List<XmlProperty>();
        propertiesData?.ForEach(prop => Properties.Add(
            GetXmlProperty(prop?.Name, prop?.Value, prop?.Line)));
    }

    protected XmlProperty GetXmlProperty(
        string? name
        , string? value
        , string? order = "")
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(value);
        ArgumentNullException.ThrowIfNull(BasicParts);
        ArgumentNullException.ThrowIfNull(order);
        return new XmlProperty(
            name,
            value,
            BasicParts[XmlObjectParts.PropPrefix],
            BasicParts[XmlObjectParts.NewLine],
            order);
    }
}