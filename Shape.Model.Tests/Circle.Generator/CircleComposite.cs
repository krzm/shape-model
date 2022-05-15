namespace Shape.Model.Tests;

public class CircleComposite 
    : IComponents<CircleComponents, IXmlSerializedObjectData>
{
    public Dictionary<CircleComponents, IXmlSerializedObjectData> Components { get; }

    public CircleComposite()
    {
        var dataFactory = new CircleDataFactory();
        Components = new Dictionary<CircleComponents, IXmlSerializedObjectData>
        {
            { CircleComponents.Circle, new CircleData(1, dataFactory.OrderCircle()) }
            , { CircleComponents.Color, new ColorData(2, dataFactory.OrderColor()) }
            , { CircleComponents.MassCenter, new MassCenterData(4, dataFactory.OrderMassCenter()) }
            , { CircleComponents.Velocity, new VelocityData(3, dataFactory.OrderVelocity()) }
        };
        foreach (var component in Components.Values)
        {
            component.Build();
        }
    }
}