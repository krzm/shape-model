﻿using System.Windows;
using Xunit;

namespace Shape.Model.Tests;

public class ShapesSerializationTest
{
    [Fact]
    public void ShapesSerialization()
    {
        var test = SetupSerializationTest();
        test.InvokeTest();
        Assert.Equal(test.Expected, test.Acctual);
    }

    private IFileTestTemplate<string> SetupSerializationTest()
    {
        IFilePath filePath = new FilePath(
            @"C:\Tests\TestTempFiles"
            , "ShapesSerialization"
            , "xml");
        IFileTestTemplate<string> test = new SerializationTest(
            filePath
            , new SerializationTestScheme<ShapeContext>(
                new SerializerXml()
                , new ShapeContext()
                {
                    Shapes = new List<Shape>
                            {
                                    new ShapeFactory().GetBlackBall(new Point(10, 10)) as Circle,
                                    new ShapeFactory().GetTestLine() as Line,
                                    new ShapeFactory().GetTestRectangle() as Rectangle
                            }
                }
                , new TextFileReader(filePath)),
            new ShapesDefaultSchema());
        test.AssertFailEvent += (message) => Assert.True(false, message);
        test.IsRemovingTempFiles = true;
        return test;
    }
}