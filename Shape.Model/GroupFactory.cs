using System.Windows;
using System.Windows.Media;

namespace Shape.Model;

public class GroupFactory : IGroupFactory
{
    private readonly IShapeFactory _shapeFactory;

    public GroupFactory(IShapeFactory shapeFactory) =>
        _shapeFactory = shapeFactory;

    public IShapeGroup GetShape(SelectedGroup selectedGroup, Point massCenter)
    {
        IShapeGroup ShapeGroup = null;
        switch (selectedGroup)
        {
            case SelectedGroup.CircleAnaliticsGroup:
                ShapeGroup = GetCircleAnaliticsGroup(massCenter);
                break;
        }
        return ShapeGroup;
    }

    private IShapeGroup GetCircleAnaliticsGroup(Point mc)
    {
        IShapeGroup ShapeGroup = new CircleAnalitics();
        var circleInMassCenter = GetCircleInMassCenter(mc);
        var velocity = GetVelocity(circleInMassCenter);
        var velocityVector = (ILine)velocity;
        velocityVector.SecondPoint = circleInMassCenter.MassCenter + circleInMassCenter.Velocity;
        ShapeGroup.Group.Add(circleInMassCenter);
        ShapeGroup.Group.Add(velocity);
        return ShapeGroup;
    }

    private IShape GetCircleInMassCenter(Point masCenter) =>
        _shapeFactory.GetShape(
            ShapeTypes.Circle,
            Context.Graphic,
            masCenter,
            Colors.Red,
            textFlag: string.Empty,
            isColorFilled: false);

    private IShape GetVelocity(IShape circle) =>
        _shapeFactory.GetShape(
            ShapeTypes.Line,
            Context.Graphic,
            circle.MassCenterPoint,
            Colors.Red,
            textFlag: string.Empty,
            isColorFilled: false);
}