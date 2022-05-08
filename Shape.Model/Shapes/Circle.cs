using System.Globalization;
using System.Windows;
using System.Windows.Media;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Shape.Model;

public class Circle : Shape, ICircle, IXmlSerializable
{
    private DrawingVisual _drawingVisual;
    private DrawingContext _drawingContext;

    public double Radius { get; set; }

    public Circle() : base() => Initialize();

    private void Initialize() => _drawingVisual = new DrawingVisual();

    public Circle(Point massCenter) : base(massCenter) => Initialize();

    public override Visual GetVisual()
    {
        UpdateVisual();
        return _drawingVisual;
    }

    public override void UpdateVisual()
    {
        _drawingContext = _drawingVisual.RenderOpen();
        DrawShape();
        _drawingContext.Close();
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
        if (RelativeImagePath == string.Empty)
            _drawingContext.DrawEllipse(GetSolidColorBrush(),
                null,
                MassCenterPoint,
                Radius,
                Radius);
        else
            _drawingContext.DrawEllipse(GetImageBrush(),
                null,
                MassCenterPoint,
                Radius,
                Radius);
    }

    private void DrawWireShape() => _drawingContext.DrawEllipse(null,
                            GetColorPen(),
                            MassCenterPoint,
                            Radius,
                            Radius);

    public override string ToString() => base.ToString() +
        $"{nameof(Radius)}={Radius}{Environment.NewLine}";

    public override int GetHashCode() => ToString().GetHashCode();

    public override bool Equals(object model) => ToString().Equals(model.ToString());

    public override XmlSchema GetSchema() => null;

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