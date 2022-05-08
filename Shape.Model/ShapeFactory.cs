using System.Windows;
using System.Windows.Media;
using Vector.Lib;

namespace Shape.Model;

public class ShapeFactory : IShapeFactory
{
    private const string BlackBallTextFlag = "black";
    private const string BlackBallImage = @"Images\ball8.bmp";
    private const string WhiteBallTextFlag = "white";

    public IShape GetShape(
        ShapeTypes shapeType,
        Color color,
        bool isColorFilled = true,
        double radius = 100,
        double width = 100,
        double height = 100)
    {
        IShape shape = null;
        switch (shapeType)
        {
            case ShapeTypes.Circle:
                shape = GetCircle(color, isColorFilled, radius);
                break;
            case ShapeTypes.Rectangle:
                shape = GetRectangle(color, isColorFilled, width, height);
                break;
            case ShapeTypes.Line:
                shape = GetLine(color);
                break;
        }
        return shape;
    }

    private ICircle GetCircle(Color color, bool filled, double radius) => new Circle()
    {
        Color = color,
        IsColorFilled = filled,
        Radius = radius
        , RelativeImagePath = ""
    };

    private IRectangle GetRectangle(Color color, bool isColorFilled, double width, double height) => new Rectangle()
    {
        Color = color,
        IsColorFilled = isColorFilled,
        Size = new Size(width, height)
    };

    private IShape GetLine(Color color) => new Line() { Color = color };

    public IShape GetShape(
        ShapeTypes shapeType,
        Context context,
        Point massCenter,
        Color color,
        string textFlag,
        bool isColorFilled = true,
        double radius = 100,
        double width = 100,
        double height = 100,
        string relativeImagePath = "")
    {
        IShape shape = null;
        switch (shapeType)
        {
            case ShapeTypes.Circle:
                shape = GetCircle(context, massCenter, color,
                    textFlag, isColorFilled, radius,
                    relativeImagePath);
                break;
            case ShapeTypes.Rectangle:
                shape = GetRectangle(context, massCenter, color,
                    isColorFilled, width, height,
                    relativeImagePath);
                break;
            case ShapeTypes.Line:
                shape = GetLine(context, massCenter, color,
                    relativeImagePath);
                break;
        }
        return shape;
    }

    private ICircle GetCircle(Context context, Point massCenter, Color color, string textFlag, bool isColorFilled, double radius, string relativeImagePath) => new Circle(massCenter)
    {
        Color = color,
        IsColorFilled = isColorFilled,
        Context = context,
        TextFlag = textFlag,
        RelativeImagePath = relativeImagePath,
        Radius = radius
    };

    private IRectangle GetRectangle(Context context, Point massCenter, Color color,
        bool isColorFilled, double width, double height,
        string relativeImagePath) => new Rectangle(massCenter)
        {
            Color = color,
            IsColorFilled = isColorFilled,
            Context = context,
            RelativeImagePath = relativeImagePath,
            Size = new Size(width, height)
        };

    private ILine GetLine(Context context, Point massCenter, Color color,
        string relativeImagePath) => new Line(massCenter)
        {
            Color = color,
            Context = context,
            RelativeImagePath = relativeImagePath
        };

    public ICircle GetBlackBall(Point massCenter) =>
        new Circle
        {
            Radius = 20,
            IsColorFilled = true,
            Mass = 10,
            MassCenter = new Vector2(massCenter.X, massCenter.Y),
            Context = Context.Physic,
            TextFlag = BlackBallTextFlag,
            RelativeImagePath = BlackBallImage
        };

    public ICircle GetWhiteBall(Point massCenter) =>
        new Circle
        {
            Radius = 20,
            Color = Colors.White,
            IsColorFilled = true,
            Mass = 10,
            MassCenter = new Vector2(massCenter.X, massCenter.Y),
            Context = Context.Physic,
            TextFlag = WhiteBallTextFlag,
            RelativeImagePath = string.Empty
        };

    public ICircle GetCollisionPointMarker(double x, double y) =>
        new Circle()
        {
            Color = Colors.Red,
            IsColorFilled = true,
            MassCenter = new Vector2(x, y),
            Radius = 4,
            Velocity = new Vector2(x, y)
        };

    public ILine GetVelocityVector(
        Vector2 massCenter,
        Vector2 secondPoint,
        Color color = default) =>
        new Line()
        {
            Color = color == null ? Colors.Black : color,
            IsColorFilled = true,
            MassCenter = massCenter,
            SecondPoint = secondPoint,
            Velocity = new Vector2(0, 0)
        };

    public ICircle GetCircleMarker(
        Vector2 center,
        Color color = default) => new Circle()
        {
            Radius = 3,
            Color = color,
            IsColorFilled = true,
            MassCenter = center
        };

    public ILine GetTestLine() => new Line
    {
        Context = Context.Physic,
        Color = Colors.Red,
        MassCenter = new Vector2(334, 680),
        Velocity = new Vector2(0, 0),
        IsColorFilled = true,
        Mass = 10,
        SecondPoint = new Vector2(299, 713)
        , RelativeImagePath = string.Empty
    };

    public IRectangle GetTestRectangle() => new Rectangle
    {
        Context = Context.Graphic,
        Color = Colors.Red,
        MassCenter = new Vector2(242, 16),
        Velocity = new Vector2(0, 0),
        IsColorFilled = true,
        Mass = 10,
        RelativeImagePath = @"Images\table.jpg",
        Size = new Size(1440, 819)
    };
}