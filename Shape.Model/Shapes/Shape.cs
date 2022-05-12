using System.Globalization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Sim.Core;
using Vector.Lib;

namespace Shape.Model;

[Serializable()]
[XmlInclude(typeof(Circle))]
[XmlInclude(typeof(Rectangle))]
[XmlInclude(typeof(Line))]
public abstract class Shape 
    : IShape
    , IXmlSerializable
{
    protected Point? MassCenterPointField;
    private SolidColorBrush? solidColorBrush;
    private ImageBrush? imageBrush;
    private Pen? pen;

    public string? TextFlag { get; set; }

    public Context Context { get; set; }

    public Color Color { get; set; }

    public Vector2 MassCenter { get; set; }

    public Vector2 Velocity { get; set; }

    public bool IsColorFilled { get; set; }

    public double Mass { get; set; }

    public string? RelativeImagePath { get; set; }

    public Point? MassCenterPoint
    {
        get
        {
            MassCenterPointField = new Point(MassCenter.X, MassCenter.Y);
            return MassCenterPointField;
        }
    }

    public Shape() => InitializeShape(new Point(0, 0));

    public Shape(Point massCenter) => InitializeShape(massCenter);

    private void InitializeShape(Point massCenter)
    {
        MassCenter = new Vector2(massCenter.X, massCenter.Y);
        MassCenterPointField = massCenter;
    }

    public virtual Visual GetVisual() => default!;

    public virtual void UpdateVisual() { }

    public override string ToString() =>
        $"{nameof(TextFlag)}={TextFlag}{Environment.NewLine}" +
        $"{nameof(Context)}={Context}{Environment.NewLine}" +
        $"{nameof(Color)}={Color}{Environment.NewLine}" +
        $"{nameof(MassCenter)}={MassCenter}{Environment.NewLine}" +
        $"{nameof(Velocity)}={Velocity}{Environment.NewLine}" +
        $"{nameof(IsColorFilled)}={IsColorFilled}{Environment.NewLine}" +
        $"{nameof(Mass)}={Mass}{Environment.NewLine}" +
        $"{nameof(RelativeImagePath)}={RelativeImagePath}{Environment.NewLine}";

    public override int GetHashCode() => ToString().GetHashCode();

    public override bool Equals(object? model) => ToString().Equals(model?.ToString());

    public virtual XmlSchema GetSchema() => new XmlSchema();

    public virtual void ReadXml(XmlReader reader)
    {
        Context = (Context)Enum.Parse(typeof(Context), reader.ReadElementString());
        if (reader.IsStartElement(nameof(Color)))
        {
            var a = byte.Parse(reader.ReadElementString());
            var r = byte.Parse(reader.ReadElementString());
            var g = byte.Parse(reader.ReadElementString());
            var b = byte.Parse(reader.ReadElementString());
            var sa = float.Parse(reader.ReadElementString(), NumberStyles.Float, CultureInfo.InvariantCulture);
            var sr = float.Parse(reader.ReadElementString(), NumberStyles.Float, CultureInfo.InvariantCulture);
            var sg = float.Parse(reader.ReadElementString(), NumberStyles.Float, CultureInfo.InvariantCulture);
            var sb = float.Parse(reader.ReadElementString(), NumberStyles.Float, CultureInfo.InvariantCulture);
            Color = new Color
            {
                A = a,
                R = r,
                G = g,
                B = b,
                ScA = sa,
                ScR = sr,
                ScG = sg,
                ScB = sb
            };
            reader.Read();
        }
        if (reader.IsStartElement(nameof(MassCenter)))
        {
            var valueX = double.Parse(reader.ReadElementString(), CultureInfo.InvariantCulture);
            var valueY = double.Parse(reader.ReadElementString(), CultureInfo.InvariantCulture);
            MassCenter = new Vector2(valueX, valueY);
            reader.Read();
        }
        if (reader.IsStartElement(nameof(Velocity)))
        {
            var valueX = double.Parse(reader.ReadElementString(), CultureInfo.InvariantCulture);
            var valueY = double.Parse(reader.ReadElementString(), CultureInfo.InvariantCulture);
            Velocity = new Vector2(valueX, valueY);
            reader.Read();
        }
        IsColorFilled = bool.Parse(reader.ReadElementString() ?? "false");
        Mass = double.Parse(reader.ReadElementString());
        RelativeImagePath = reader.ReadElementString();
    }

    public virtual void WriteXml(XmlWriter writer)
    {
        writer.WriteElementString(nameof(Context), Context.ToString());
        writer.WriteStartElement(nameof(Color));
        writer.WriteElementString(nameof(Color.A), Color.A.ToString());
        writer.WriteElementString(nameof(Color.R), Color.R.ToString());
        writer.WriteElementString(nameof(Color.G), Color.G.ToString());
        writer.WriteElementString(nameof(Color.B), Color.B.ToString());
        writer.WriteElementString(nameof(Color.ScA), Color.ScA.ToString(CultureInfo.InvariantCulture));
        writer.WriteElementString(nameof(Color.ScR), Color.ScR.ToString(CultureInfo.InvariantCulture));
        writer.WriteElementString(nameof(Color.ScG), Color.ScG.ToString(CultureInfo.InvariantCulture));
        writer.WriteElementString(nameof(Color.ScB), Color.ScB.ToString(CultureInfo.InvariantCulture));
        writer.WriteEndElement();
        writer.WriteStartElement(nameof(MassCenter));
        MassCenter.WriteXml(writer);
        writer.WriteEndElement();
        writer.WriteStartElement(nameof(Velocity));
        Velocity.WriteXml(writer);
        writer.WriteEndElement();
        writer.WriteElementString(nameof(IsColorFilled), IsColorFilled.ToString());
        writer.WriteElementString(nameof(Mass), Mass.ToString());
        writer.WriteElementString(nameof(RelativeImagePath), RelativeImagePath);
    }

    protected SolidColorBrush GetSolidColorBrush()
    {
        if (solidColorBrush == null)
        {
            solidColorBrush = new SolidColorBrush(Color);
        }
        return solidColorBrush;
    }

    protected ImageBrush GetImageBrush()
    {
        if (imageBrush == null && !string.IsNullOrEmpty(RelativeImagePath))
        {
            imageBrush = new ImageBrush(new BitmapImage(new Uri(RelativeImagePath, UriKind.Relative)));
        }
        ArgumentNullException.ThrowIfNull(imageBrush);
        return imageBrush;
    }

    protected Pen GetColorPen()
    {
        if (pen == null)
        {
            pen = new Pen(GetSolidColorBrush(), 1.0);
        }
        return pen;
    }
}