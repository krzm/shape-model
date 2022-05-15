namespace Shape.Model.Tests;

public class LineNumberedComposite
    : IComponents<LineComponents, IXmlSerializedObjectData>
{
    public Dictionary<LineComponents, IXmlSerializedObjectData> Components { get; }

    public LineNumberedComposite()
    {
        var dataFactory = new LineDataFactory();
        Components = new Dictionary<LineComponents, IXmlSerializedObjectData>
            {
                {
                    LineComponents.Line
                    , new LineData(
                        "02"
                        , "29"
                        , 1
                        , dataFactory.OrderLine()) }
                , {
                    LineComponents.Color
                    , new ColorData(
                        "04"
                        , "13"
                        , 1
                        , dataFactory.OrderColor()) }
                , {
                    LineComponents.MassCenter
                    , new MassCenterData(
                        "14"
                        , "17"
                        , 2
                        , dataFactory.OrderMassCenter()) }
                , {
                    LineComponents.Velocity
                    , new VelocityData(
                        "18"
                        , "21"
                        , 3
                        , dataFactory.OrderVelocity()) }
                , { LineComponents.SecondPoint
                    , new SecondPointData(
                        "25"
                        , "28"
                        , 4
                        , dataFactory.OrderSecondPoint()) }
            };
        foreach (var component in Components.Values)
        {
            component.Build();
        }
    }
}