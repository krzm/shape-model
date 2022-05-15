namespace Shape.Model.Tests;

public interface IOrder<TType>
{
    TType Order();
}