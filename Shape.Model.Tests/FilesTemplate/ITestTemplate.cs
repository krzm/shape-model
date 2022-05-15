namespace Shape.Model.Tests;

public interface ITestTemplate<TType>
{
    event Action TestActionEvent;

    event Action<string> AssertFailEvent;

    TType Expected { get; }

    TType Acctual { get; }

    void InvokeTest();
}