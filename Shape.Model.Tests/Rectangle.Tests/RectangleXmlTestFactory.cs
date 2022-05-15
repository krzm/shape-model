using Xml.Generator;

namespace Shape.Model.Tests;

public class RectangleXmlTestFactory
    : ShapeXmlTestFactory<Rectangle>
{
    public override string FileName => "RectangleSerialization";

    public RectangleXmlTestFactory(IText expectedXml)
        : base(expectedXml)
    {
    }

    protected override Rectangle ProduceShape() =>
        new ShapeFactory().GetTestRectangle() as Rectangle;
}