using Sim.Core;
using Xunit;

namespace Shape.Model.Tests;

public class SimpleListSerializationTest
{
    private const string FilePath = @"C:\Tests\TestTempFiles\Money.xml";

    [Fact]
    public void TestListSerialization()
    {
        var serializer = new SerializerXml();
        serializer.Serialize(
            new List<Money>()
            {
                    new Gold { Type = "Hard money", WeightInOunces = 1, Color = new Color { Value = 999 } }
                    , new Dolor { Type = "Fiat money", FaceValue = 2 }
            }
            , FilePath);
    }

    [Fact]
    public void TestListDeserialization()
    {
        var serializer = new SerializerXml();
        var list = serializer.Deserialize<List<Money>>(FilePath);
    }
}