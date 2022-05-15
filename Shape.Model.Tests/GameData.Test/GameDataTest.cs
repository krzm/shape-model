using Xunit;

namespace Shape.Model.Tests;

public class GameDataTest
{
    private const string FolderPath = @"C:\Tests\TestTempFiles";
    private const string FileName = "GameShapesTest.xml";
    private readonly string filePath;

    public GameDataTest()
    {
        MyFileSystem.EnsureFolder(FolderPath);
        filePath = Path.Combine(FolderPath, FileName);
    }

    [Fact]
    public void TestGameData()
    {
        var shapeContext = GetShapeContext();
        var serialization = new SerializerXml();
        serialization.Serialize(shapeContext, filePath);

        var data = new GameData(serialization, filePath);

        var circle = data.Circles;
        for (int i = 0; i < MockData.CircleTable.Length; i++)
        {
            Assert.Equal(MockData.CircleTable[i], (Circle)circle[i]);
        }

        var polygon = data.Polygons;
        for (int i = 0; i < MockData.PolygonTable.Length; i++)
        {
            Assert.Equal(MockData.PolygonTable[i], (Line)polygon[i]);
        }
    }

    private static ShapeContext GetShapeContext()
    {
        return new ShapeContext()
        {
            Shapes = new List<Shape>()
                {
                    MockData.CircleTable[0],
                    MockData.CircleTable[1],
                    MockData.PolygonTable[0]
                }
        };
    }
}