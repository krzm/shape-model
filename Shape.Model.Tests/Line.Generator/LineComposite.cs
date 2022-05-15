namespace Shape.Model.Tests;

public class LineComposite
    : IComponents<LineComponents, IXmlSerializedObjectData>
{
    public Dictionary<LineComponents, IXmlSerializedObjectData> Components { get; }

    public LineComposite()
    {
        var dataFactory = new LineDataFactory();
        Components = new Dictionary<LineComponents, IXmlSerializedObjectData>
            {
                { LineComponents.Line
                    , new LineData(
                        1
                        , dataFactory.OrderLine()) }
                , { LineComponents.Color,
                    new ColorData(
                        1
                        , dataFactory.OrderColor()) }
                , { LineComponents.MassCenter,
                    new MassCenterData(
                        2
                        , dataFactory.OrderMassCenter()) }
                , { LineComponents.Velocity, new VelocityData(3, dataFactory.OrderVelocity()) }
                , { LineComponents.SecondPoint, new SecondPointData(4, dataFactory.OrderSecondPoint()) }
            };
        foreach (var component in Components.Values)
        {
            component.Build();
        }
    }
}