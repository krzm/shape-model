using System.Text;

namespace Shape.Model.Tests;

public abstract class FileReader
    : IFileReader
{
    public List<string> Output { get; protected set; } = new List<string>();

    public int IgnoreFirstXLines { get; set; }

    public string[] IgnoreLineContainingValue { get; set; }

    public string OutputAsString => ConvertLinesToString();

    protected string ConvertLinesToString()
    {
        var stringBuilder = new StringBuilder();
        foreach (var line in Output)
        {
            stringBuilder.AppendLine(line);
        }
        return stringBuilder.ToString().TrimEnd(Environment.NewLine.ToCharArray());
    }

    public abstract void ReadingData();

    protected abstract void Reset();
}