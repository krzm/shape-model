using System.Windows;
using System.Windows.Media;
using Vector.Lib;

namespace Shape.Model;

public interface IShapeFactory
{
    IShape GetShape(
        ShapeTypes shapeType,
        Color color,
        bool isColorFilled = true,
        double radius = 100,
        double width = 100,
        double height = 100);

    IShape GetShape(
        ShapeTypes shapeType,
        Context context,
        Point massCenter,
        Color color,
        string textFlag,
        bool isColorFilled = true,
        double radius = 100,
        double width = 100,
        double height = 100,
        string relativeImagePath = "");

    ICircle GetBlackBall(Point massCenter);

    ICircle GetWhiteBall(Point massCenter);

    ICircle GetCollisionPointMarker(double x, double y);

    ILine GetVelocityVector(
        Vector2 massCenter,
        Vector2 secondPoint,
        Color color = default);

    ICircle GetCircleMarker(
        Vector2 center,
        Color color = default);

    ILine GetTestLine();

    IRectangle GetTestRectangle();
}