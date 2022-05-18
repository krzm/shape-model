using System.Windows;
using Sim.Core;
using Xunit;

namespace Shape.Model.Tests;

public class ShapesDeserializationTest
{
    [Fact]
    public void ShapesDeserialization()
    {
        var test = SetupDeserializationTest();
        test.InvokeTest();
        ArgumentNullException.ThrowIfNull(test.Acctual);
        AssertShapeContext(test.Expected, test.Acctual);
    }

    private ITestTemplate<ShapeContext> SetupDeserializationTest()
    {
        IFileTestTemplate<ShapeContext> test = new DeserializationTest<ShapeContext>(
            new FilePath(@"C:\Tests\TestTempFiles", "ShapesDeserialization", "xml")
            , new DeserializationTestScheme<ShapeContext>(
                new SerializerXml()
                , new ShapesDefaultSchema())
            , GetShapeContext());
        test.AssertFailEvent += (message) => Assert.True(false, message);
        test.IsRemovingTempFiles = true;
        return test;
    }

    private static ShapeContext GetShapeContext()
    {
        var blackBall = new ShapeFactory().GetBlackBall(new Point(10, 10)) as Circle;
        ArgumentNullException.ThrowIfNull(blackBall);
        var testLine = new ShapeFactory().GetTestLine() as Line;
        ArgumentNullException.ThrowIfNull(testLine);
        var testRectangle = new ShapeFactory().GetTestRectangle() as Rectangle;
        ArgumentNullException.ThrowIfNull(testRectangle);
        return new ShapeContext()
        {
            Shapes = new List<Shape>
            {
                blackBall
                , testLine
                , testRectangle
            }
        };
    }

    private static void AssertShapeContext(ShapeContext expected, ShapeContext acctual)
    {
        var types = new Type[] { typeof(Circle), typeof(Line), typeof(Rectangle) };

        for (int i = 0; i < 3; i++)
        {
            Assert.True(expected.Shapes[i].GetType() == types[i]);
            Assert.True(acctual.Shapes[i].GetType() == types[i]);
            AssertShape(expected, acctual, i);
            AssertCircle(types[i], expected.Shapes[i], acctual.Shapes[i]);
            AssertLine(types[i], expected.Shapes[i], acctual.Shapes[i]);
            AssertRectangle(types[i], expected.Shapes[i], acctual.Shapes[i]);
        }
    }

    private static void AssertShape(ShapeContext expected, ShapeContext acctual, int i)
    {
        Assert.Equal(expected.Shapes[i].TextFlag, acctual.Shapes[i].TextFlag);
        Assert.Equal(expected.Shapes[i].Context, acctual.Shapes[i].Context);
        Assert.Equal(expected.Shapes[i].Color, acctual.Shapes[i].Color);
        Assert.Equal(expected.Shapes[i].MassCenter, acctual.Shapes[i].MassCenter);
        Assert.Equal(expected.Shapes[i].Velocity, acctual.Shapes[i].Velocity);
        Assert.Equal(expected.Shapes[i].IsColorFilled, acctual.Shapes[i].IsColorFilled);
        Assert.Equal(expected.Shapes[i].Mass, acctual.Shapes[i].Mass);
        Assert.Equal(expected.Shapes[i].RelativeImagePath, acctual.Shapes[i].RelativeImagePath);
        Assert.Equal(expected.Shapes[i].MassCenterPoint, acctual.Shapes[i].MassCenterPoint);
    }

    private static void AssertCircle(Type type, Shape expectedShape, Shape acctualShape)
    {
        if (type != typeof(Circle)) return;
        var expected = expectedShape as Circle;
        var acctual = acctualShape as Circle;
        Assert.Equal(expected?.Radius, acctual?.Radius);

    }

    private static void AssertLine(Type type, Shape expectedShape, Shape acctualShape)
    {
        if (type != typeof(Line)) return;
        var expected = expectedShape as Line;
        var acctual = acctualShape as Line;
        Assert.Equal(expected?.SecondPoint, acctual?.SecondPoint);
        Assert.Equal(expected?.SecondPoint2D, acctual?.SecondPoint2D);
    }

    private static void AssertRectangle(Type type, Shape expectedShape, Shape acctualShape)
    {
        if (type != typeof(Rectangle)) return;
        var expected = expectedShape as Rectangle;
        var acctual = acctualShape as Rectangle;
        Assert.Equal(expected?.Size, acctual?.Size);
        Assert.Equal(expected?.Size, acctual?.Size);
    }
}