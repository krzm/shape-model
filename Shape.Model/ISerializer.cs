namespace Shape.Model;

public interface ISerializer
{
    TType Deserialize<TType>(
        string filePath);

    void Serialize<TType>(
        TType data, 
        string filePath);
}
