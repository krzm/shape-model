namespace Shape.Model.Tests;

public class CircleNumberedComposite
    : IComponents<CircleComponents, IXmlSerializedObjectData>
{
    public Dictionary<CircleComponents, IXmlSerializedObjectData> Components { get; }

    public CircleNumberedComposite()
    {
        var dataFactory = new CircleDataFactory();
        Components = new Dictionary<CircleComponents, IXmlSerializedObjectData>
            {
                { CircleComponents.Circle, new CircleData("02", "27", 1, dataFactory.OrderCircle()) }
                , { CircleComponents.Color, new ColorData("05", "14", 2, dataFactory.OrderColor()) }
                , { CircleComponents.MassCenter, new MassCenterData("15", "18", 3, dataFactory.OrderMassCenter()) }
                , { CircleComponents.Velocity, new VelocityData("19", "22", 4, dataFactory.OrderVelocity()) }
            };
        foreach (var component in Components.Values)
        {
            component.Build();
        }
    }
}