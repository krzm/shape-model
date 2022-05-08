using System.Windows;

namespace Shape.Model;

public interface IRectangle : IShape
{
    Size Size { get; set; }
}