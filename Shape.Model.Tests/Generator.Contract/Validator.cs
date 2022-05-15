namespace Shape.Model.Tests;

public abstract class Validator
{
    public string IsItText(string text)
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
            throw new ArgumentException(nameof(text));
        return text;
    }
}