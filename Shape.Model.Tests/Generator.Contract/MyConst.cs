namespace Shape.Model.Tests;

public static class MyConst
{
    static MyConst()
    {
        NewLineAsChars = NewLine.ToCharArray();
    }

    public static string NewLine => Environment.NewLine;

    public static char[] NewLineAsChars { get; private set; }

    public static char LineSeparator => '|';
}