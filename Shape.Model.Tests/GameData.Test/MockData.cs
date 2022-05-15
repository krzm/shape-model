using Sim.Core;
using System.Windows.Media;
using Vector.Lib;

namespace Shape.Model.Tests;

public static class MockData
{
    public static Line[] PolygonTable { get; } =
    {
            new Line()
            {
                Context = Context.Physic
                , Color = Colors.Red
                , IsColorFilled = true
                , MassCenter = new Vector2(0, 0)
                , Velocity = new Vector2(0, 0)
            }
        };

    public static Circle[] CircleTable { get; } =
    {
            new Circle()
            {
                Context = Context.Physic
                , TextFlag = "a"
                , Color = Colors.Red
                , IsColorFilled = true
                , MassCenter = new Vector2(0, 0)
                , Radius = 10
                , Velocity = new Vector2(0, 0)
            }
            , new Circle()
            {
                Context = Context.Physic
                , TextFlag = "b"
                , Color = Colors.AliceBlue
                , IsColorFilled = false
                , MassCenter = new Vector2(0, 0)
                , Radius = 14
                , Velocity = new Vector2(1, 0)
            }
        };
}