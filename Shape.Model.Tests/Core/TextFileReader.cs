namespace Shape.Model.Tests;

public class TextFileReader
    : FileReader
{
    private readonly IFilePath? filePath;

    private int lineNr;

    private string? line;

    public TextFileReader(
        IFilePath filePath) => this.filePath = filePath;

    public override void ReadingData()
    {
        if (string.IsNullOrWhiteSpace(filePath?.FullPath)) return;
        Reset();
        using (var reader = new StreamReader(filePath.FullPath))
        {
            lineNr = 0;
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                if (IsFromIgnoredHeader() &&
                    !IsContainingIgnoredValues() &&
                    !string.IsNullOrWhiteSpace(line))
                    Output.Add(line.TrimEnd(','));
                lineNr++;
            }
        }
    }

    protected override void Reset() =>
        Output.Clear();

    private bool IsFromIgnoredHeader() =>
        lineNr > IgnoreFirstXLines - 1;

    private bool IsContainingIgnoredValues()
    {
        if(IsIgnoreOrLineEmpty())
            return false;
        return IgnoreLineContainingValue!.Any(value => line!.Contains(value));
    }
       
    private bool IsIgnoreOrLineEmpty() =>
        IgnoreLineContainingValue == null 
        || IgnoreLineContainingValue.Length == 0
        || string.IsNullOrWhiteSpace(line);
}