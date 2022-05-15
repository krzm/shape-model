namespace Shape.Model.Tests;

public class RectangleComposite
    : IComponents<RectangleComponents, IXmlSerializedObjectData>
{
    public Dictionary<RectangleComponents, IXmlSerializedObjectData> Components { get; }

    public RectangleComposite()
    {
        var dataFactory = new RectangleDataFactory();
        Components = new Dictionary<RectangleComponents, IXmlSerializedObjectData>
        {
            { RectangleComponents.Rectangle, new RectangleData(1, dataFactory.OrderRectangle()) }
            , { RectangleComponents.Color, new ColorData(2, dataFactory.OrderColor()) }
            , { RectangleComponents.MassCenter, new MassCenterData(3, dataFactory.OrderMassCenter()) }
            , { RectangleComponents.Velocity, new VelocityData(4, dataFactory.OrderVelocity()) }
            , { RectangleComponents.Size, new SizeData(5, dataFactory.OrderSize()) }
        };
        foreach (var component in Components.Values)
        {
            component.Build();
        }
    }
}