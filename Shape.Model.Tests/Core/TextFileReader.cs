namespace Shape.Model.Tests;

public class TextFileReader
    : FileReader
{
    private readonly IFilePath _filePath;

    private int _lineNr;

    private string _line;

    public TextFileReader(
        IFilePath filePath) => _filePath = filePath;

    public override void ReadingData()
    {
        if (string.IsNullOrWhiteSpace(_filePath.FullPath)) return;
        Reset();
        using (var reader = new StreamReader(_filePath.FullPath))
        {
            _lineNr = 0;
            while (!reader.EndOfStream)
            {
                _line = reader.ReadLine();
                if (IsFromIgnoredHeader() &&
                    !IsContainingIgnoredValues() &&
                    !string.IsNullOrWhiteSpace(_line))
                    Output.Add(_line.TrimEnd(','));
                _lineNr++;
            }
        }
    }

    protected override void Reset() =>
        Output.Clear();

    private bool IsFromIgnoredHeader() =>
        _lineNr > IgnoreFirstXLines - 1;

    private bool IsContainingIgnoredValues() =>
        IsIgnoreEmpty() ?
        false :
        IgnoreLineContainingValue.Any(value => _line.Contains(value));

    private bool IsIgnoreEmpty() =>
        IgnoreLineContainingValue == null ||
        IgnoreLineContainingValue.Length == 0;
}