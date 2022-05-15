using System.Xml.Serialization;

namespace Shape.Model.Tests;

[XmlInclude(typeof(Gold))]
[XmlInclude(typeof(Dolor))]
public abstract class Money
{
    public string Type { get; set; }
}