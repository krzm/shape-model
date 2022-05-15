using System.Text;
using Xml.Generator;

namespace Shape.Model.Tests;

public class XmlOrderedGenerator
    : IText
{
    private readonly IText _text;

    public XmlOrderedGenerator(IText text)
    {
        _text = text;
    }

    public string Text
    {
        get
        {
            var lines = _text.Text.Split(MyConst.NewLineAsChars);
            var sb = new StringBuilder();
            foreach (var line in lines.Where(line => !string.IsNullOrWhiteSpace(line)))
            {
                var lineStr = line.Split(MyConst.LineSeparator).Last();
                sb.AppendLine(lineStr);
            }
            return sb.ToString().TrimEnd(MyConst.NewLineAsChars);
        }
    }
}