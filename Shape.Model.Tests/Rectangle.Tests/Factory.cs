namespace Shape.Model.Tests;

public abstract class Factory<TType>
        : IOrder<TType>
{
    public abstract TType Order();
}