namespace Shape.Model.Tests;

public interface IComponents<TKey, TType>
    where TKey : notnull
{
    Dictionary<TKey, TType> Components { get; }
}