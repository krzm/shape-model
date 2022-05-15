namespace Shape.Model.Tests;

public abstract class DataFactory
{
    protected XmlPropertyData GetProp(string line, string name, string value) =>
        new XmlPropertyData { Line = line, Name = name, Value = value };
}