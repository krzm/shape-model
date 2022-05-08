using System.Windows.Media;

namespace Shape.Model;

public interface IShapeGroup
{
    List<IShape> Group { get; set; }

    Visual[] GetShape();
}