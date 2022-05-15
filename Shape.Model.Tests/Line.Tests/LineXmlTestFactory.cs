using Xml.Generator;

namespace Shape.Model.Tests;

public class LineXmlTestFactory
    : ShapeXmlTestFactory<Line>
{
    public override string FileName => "LineSerialization";

    public LineXmlTestFactory(IText expectedXml) : base(expectedXml)
    {
    }

    protected override Line ProduceShape() =>
        new ShapeFactory().GetTestLine() as Line;
}