using System.Globalization;
using System.Windows;
using System.Windows.Media;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Sim.Core;

namespace Shape.Model;

public class Circle 
    : Shape
    , ICircle
    , IXmlSerializable
{
    private DrawingVisual? drawingVisual;
    private DrawingContext? drawingContext;

    public double Radius { get; set; }

    public Circle() : base() => Initialize();

    private void Initialize() => drawingVisual = new DrawingVisual();

    public Circle(Point massCenter) : base(massCenter) => Initialize();

    public override Visual GetVisual()
    {
        UpdateVisual();
        ArgumentNullException.ThrowIfNull(drawingVisual);
        return drawingVisual;
    }

    public override void UpdateVisual()
    {
        drawingContext = drawingVisual?.RenderOpen();
        DrawShape();
        drawingContext?.Close();
    }

    private void DrawShape()
    {
        if (IsColorFilled)
        {
            DrawFilledShape();
        }
        else
        {
            DrawWireShape();
        }
    }

    private void DrawFilledShape()
    {
        ArgumentNullException.ThrowIfNull(MassCenterPoint);
        if (RelativeImagePath == string.Empty)
            drawingContext?.DrawEllipse(
                GetSolidColorBrush(),
                null,
                MassCenterPoint.Value,
                Radius,
                Radius);
        else
            drawingContext?.DrawEllipse(
                GetImageBrush(),
                null,
                MassCenterPoint.Value,
                Radius,
                Radius);
    }

    private void DrawWireShape()
    {
        ArgumentNullException.ThrowIfNull(MassCenterPoint);
        drawingContext?.DrawEllipse(
            null,
            GetColorPen(),
            MassCenterPoint.Value,
            Radius,
            Radius);
    }

    public override string ToString() => base.ToString() +
        $"{nameof(Radius)}={Radius}{Environment.NewLine}";

    public override int GetHashCode() => ToString().GetHashCode();

    public override bool Equals(object? model) => ToString().Equals(model?.ToString());

    public override XmlSchema GetSchema() => new XmlSchema();

    public override void ReadXml(XmlReader reader)
    {
        reader.Read();
        if(reader.Name == nameof(TextFlag))
        {
            TextFlag = reader.ReadElementString();
        }
        base.ReadXml(reader);
        Radius = double.Parse(reader.ReadElementString());
    }

    public override void WriteXml(XmlWriter writer)
    {
        if (!string.IsNullOrWhiteSpace(TextFlag))
            writer.WriteElementString(nameof(TextFlag), TextFlag);
        base.WriteXml(writer);
        writer.WriteElementString(nameof(Radius), Radius.ToString(CultureInfo.InvariantCulture));
    }
}