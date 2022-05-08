using System.Windows.Media;
using System.Windows;
using System.Xml.Schema;
using System.Xml;
using System.Globalization;

namespace Shape.Model;

public class Rectangle : Shape, IRectangle
{
    private DrawingVisual _drawingVisual;
    private DrawingContext _drawingContext;
    private Rect _rect;

    public Size Size { get; set; }

    public Rectangle() : base() => Initialize();

    private void Initialize()
    {
        _drawingVisual = new DrawingVisual();
        Size = new Size(100, 100);
        _rect = new Rect();
    }

    public Rectangle(Point massCenter) : base(massCenter) => Initialize();

    public override Visual GetVisual()
    {
        UpdateVisual();
        return _drawingVisual;
    }

    public override void UpdateVisual()
    {
        _drawingContext = _drawingVisual.RenderOpen();
        SetShape();
        DrawShape();
        _drawingContext.Close();
    }

    private void SetShape()
    {
        _rect.Location = MassCenterPoint;
        _rect.Size = Size;
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
        if (string.IsNullOrWhiteSpace(RelativeImagePath))
            _drawingContext.DrawRectangle(GetSolidColorBrush(),
                null,
                _rect);
        else
            _drawingContext.DrawRectangle(GetImageBrush(),
                null,
                _rect);
    }

    private void DrawWireShape() =>
        _drawingContext.DrawRectangle(null, GetColorPen(), _rect);

    public override string ToString() => base.ToString() +
        $"{nameof(Size)}={Size.ToString()}{Environment.NewLine}";

    public override int GetHashCode() => ToString().GetHashCode();

    public override bool Equals(object theObject) => ToString().Equals(theObject.ToString());

    public override XmlSchema GetSchema() => null;

    public override void ReadXml(XmlReader reader)
    {
        base.ReadXml(reader);
        if (reader.IsStartElement(nameof(Size)))
        {
            var width = double.Parse(reader.ReadElementString(), CultureInfo.InvariantCulture);
            var height = double.Parse(reader.ReadElementString(), CultureInfo.InvariantCulture);
            Size = new Size(width, height);
            reader.Read();
        }
    }

    public override void WriteXml(XmlWriter writer)
    {
        base.WriteXml(writer);
        writer.WriteStartElement(nameof(Size));
        writer.WriteElementString(nameof(Size.Width), Size.Width.ToString(CultureInfo.InvariantCulture));
        writer.WriteElementString(nameof(Size.Height), Size.Height.ToString(CultureInfo.InvariantCulture));
        writer.WriteEndElement();
    }
}