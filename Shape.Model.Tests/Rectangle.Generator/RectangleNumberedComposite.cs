namespace Shape.Model.Tests;

public class RectangleNumberedComposite
    : IComponents<RectangleComponents, IXmlSerializedObjectData>
{
    public Dictionary<RectangleComponents, IXmlSerializedObjectData> Components { get; }

    public RectangleNumberedComposite()
    {
        var dataFactory = new RectangleDataFactory();
        Components = new Dictionary<RectangleComponents, IXmlSerializedObjectData>
            {
                { RectangleComponents.Rectangle, new RectangleData("02", "29", 1, dataFactory.OrderRectangle()) }
                , { RectangleComponents.Color, new ColorData("04", "13", 2, dataFactory.OrderColor()) }
                , { RectangleComponents.MassCenter, new MassCenterData("14", "17", 3, dataFactory.OrderMassCenter()) }
                , { RectangleComponents.Velocity, new VelocityData("18", "21", 4, dataFactory.OrderVelocity()) }
                , { RectangleComponents.Size, new SizeData("25", "28", 5, dataFactory.OrderSize()) }
            };
        foreach (var component in Components.Values)
        {
            component.Build();
        }
    }
}