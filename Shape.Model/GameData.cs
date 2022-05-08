﻿using System.Collections.Concurrent;
using System.Windows;

namespace Shape.Model;

public class GameData : ContextBoundObject
    , IGameData
{
    private readonly ISerializer _dataSerialization;
    private readonly string _filePath;
    private readonly string _fileError;

    public List<IShape> Shapes { get; private set; } = new List<IShape>();

    public List<IShape> Circles =>
        (from shape in Shapes where shape.Context == Context.Physic && shape is Circle select shape).ToList();

    public List<IShape> Polygons =>
        (from shape in Shapes where shape is Line && shape.Context == Context.Physic select shape).ToList();

    public List<IShape> Sinks =>
        (from shape in Shapes where shape.Context == Context.Logic && shape is Circle select shape).ToList();

    public BlockingCollection<IShape> VectorAnalitics { get; set; } = null;

    public GameData(
        ISerializer dataSerialization
        , string filePath)
    {
        _dataSerialization = dataSerialization;
        _filePath = filePath;
        _fileError = $"Deserializacja {_filePath} nie powiodła się sprawdź czy plik znajduje się w folderze programu";
        TryInitialize();
    }

    private void TryInitialize()
    {
        try
        {
            var serializableShapes = _dataSerialization.Deserialize<ShapeContext>(_filePath);
            Shapes.AddRange(serializableShapes.Shapes);
        }
        catch (Exception exception)
        {
            MessageBox.Show($"{_fileError}{Environment.NewLine}{exception.Message}");
        }
    }
}