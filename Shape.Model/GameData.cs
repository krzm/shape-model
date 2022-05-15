using System.Collections.Concurrent;
using System.Windows;
using Sim.Core;

namespace Shape.Model;

public class GameData
    : ContextBoundObject
    , IGameData
{
    private readonly ISerializer dataSerialization;
    private readonly string filePath;
    private readonly string fileError;

    public List<IShape> Shapes { get; private set; } = new List<IShape>();

    public List<IShape> Circles =>
        (from shape in Shapes where shape.Context == Context.Physic && shape is Circle select shape).ToList();

    public List<IShape> Polygons =>
        (from shape in Shapes where shape is Line && shape.Context == Context.Physic select shape).ToList();

    public List<IShape> Sinks =>
        (from shape in Shapes where shape.Context == Context.Logic && shape is Circle select shape).ToList();

    public BlockingCollection<IShape>? VectorAnalitics { get; set; }

    public GameData(
        ISerializer dataSerialization
        , string filePath)
    {
        this.dataSerialization = dataSerialization;
        this.filePath = filePath;
        fileError = $"Deserializacja {this.filePath} nie powiodła się sprawdź czy plik znajduje się w folderze programu";
        TryInitialize();
    }

    private void TryInitialize()
    {
        try
        {
            var serializableShapes = dataSerialization.Deserialize<ShapeContext>(filePath);
            Shapes.AddRange(serializableShapes.Shapes);
        }
        catch (Exception exception)
        {
            MessageBox.Show($"{fileError}{Environment.NewLine}{exception.Message}");
        }
    }
}