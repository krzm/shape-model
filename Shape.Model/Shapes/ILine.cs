using System.Windows;
using Vector.Lib;

namespace Shape.Model;

public interface ILine : IShape
{
    Vector2 SecondPoint { get; set; }

    Point SecondPoint2D { get; }
}