using Xunit;

namespace Shape.Model.Tests.CustomList;

public partial class SimpleCustomListSerializationTest
{
    private const string FolderPath = @"C:\Tests\TestTempFiles";
    private const string FileName = "CustomMoney.xml";
    private readonly string _filePath;

    public SimpleCustomListSerializationTest()
    {
        MyFileSystem.EnsureFolder(FolderPath);
        _filePath = Path.Combine(FolderPath, FileName);

        if (File.Exists(_filePath))
            File.Delete(_filePath);
    }

    [Fact]
    public void TestListSerialization()
    {
        Serialize(new SerializerXml());

        Assert.True(File.Exists(_filePath));
    }

    private void Serialize(ISerializer serializer) => serializer.Serialize(
        GetMoneyContext()
        , _filePath);

    private static MoneyContext GetMoneyContext() => new MoneyContext
    {
        Valueables = new List<Money>()
        {
            new Gold 
            { 
                Type = "Hard money"
                , WeightInOunces = 1
                , Color = new Color { Value = 999 } 
            }
            , new Dolar { Type = "Fiat money", FaceValue = 2 }
            , new Dolar { Type = "Fiat money", FaceValue = 3 }
        }
    };

    [Fact]
    public void TestListDeserialization()
    {
        var serializer = new SerializerXml();
        Serialize(serializer);

        Assert.True(File.Exists(_filePath));

        var acctual = serializer.Deserialize<MoneyContext>(_filePath);
        var expected = GetMoneyContext();

        AssertMoneyContext(acctual, expected);
    }

    private static void AssertMoneyContext(MoneyContext acctual, MoneyContext expected)
    {
        var types = new Type[] { typeof(Gold), typeof(Dolar), typeof(Dolar) };

        for (int i = 0; i < 3; i++)
        {
            Assert.True(expected.Valueables[i].GetType() == types[i]);
            Assert.True(acctual.Valueables[i].GetType() == types[i]);

            Assert.Equal(expected.Valueables[i].Type, acctual.Valueables[i].Type);
            AssertGold(types[i], expected.Valueables[i], acctual.Valueables[i]);
            AssertDolor(types[i], expected.Valueables[i], acctual.Valueables[i]);
        }
    }

    private static void AssertGold(Type type, Money expectedMoney, Money acctualMoney)
    {
        if (type != typeof(Gold)) return;
        var expected = expectedMoney as Gold;
        var acctual = acctualMoney as Gold;
        Assert.Equal(expected?.WeightInOunces, acctual?.WeightInOunces);
        Assert.Equal(expected?.Color.Value, acctual?.Color.Value);
    }

    private static void AssertDolor(Type type, Money expectedMoney, Money acctualMoney)
    {
        if (type != typeof(Dolar)) return;
        var expected = expectedMoney as Dolar;
        var acctual = acctualMoney as Dolar;
        Assert.Equal(expected?.FaceValue, acctual?.FaceValue);
    }
}