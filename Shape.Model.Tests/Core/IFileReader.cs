namespace Shape.Model.Tests;

public interface IFileReader
    : IOutput
    , IOutputAsString
{
    int IgnoreFirstXLines { get; set; }

    string[] IgnoreLineContainingValue { get; set; }

    void ReadingData();
}