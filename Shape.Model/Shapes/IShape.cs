using System.Windows;
using System.Windows.Media;
using Vector.Lib;

namespace Shape.Model;

public interface IShape
{
    Color Color { get; set; }

    Context Context { get; set; }
    
    bool IsColorFilled { get; set; }
    
    double Mass { get; set; }
    
    Point MassCenterPoint { get; }
    
    string RelativeImagePath { get; set; }
    
    string TextFlag { get; set; }

    Vector2 MassCenter { get; set; }
    
    Vector2 Velocity { get; set; }

    Visual GetVisual();

    void UpdateVisual();
}