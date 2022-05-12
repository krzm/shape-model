using System.Windows.Media;
using Sim.Core;

namespace Shape.Model;

public abstract class ShapeGroup
    : IShapeGroup
{
    public List<IShape> Group { get; set; } = new List<IShape>();

    public abstract Visual[] GetShape();
}