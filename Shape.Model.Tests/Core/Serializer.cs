using System.Diagnostics;

namespace Shape.Model.Tests;

public abstract class Serializer
    : ISerializer
{
    public TType Deserialize<TType>(string filePath)
    {
        try
        {
            var typeName = typeof(TType).FullName;
            return TryDeserialize<TType>(filePath);
        }
        catch (Exception exception)
        {
            //todo: add logger
            Debug.WriteLine(exception.Message);
            throw;
        }
    }

    protected abstract TType TryDeserialize<TType>(string filePath);

    public void Serialize<TType>(TType data, string filePath)
    {
        try
        {
            TrySerialize(data, filePath);
        }
        catch (Exception exception)
        {
            Debug.WriteLine(exception.Message);
        }
    }

    protected abstract void TrySerialize<TType>(TType data, string filePath);
}