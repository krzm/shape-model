namespace Shape.Model.Tests;

public interface IComponents<TKey, TType>
{
    Dictionary<TKey, TType> Components { get; }
}