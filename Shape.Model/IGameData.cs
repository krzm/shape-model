using System.Collections.Concurrent;

namespace Shape.Model;

public interface IGameData
{
    List<IShape> Circles { get; }
    List<IShape> Polygons { get; }
    List<IShape> Shapes { get; }
    List<IShape> Sinks { get; }
    BlockingCollection<IShape> VectorAnalitics { get; set; }
}