namespace Shape.Model.Tests;

public abstract class TestTemplate<TType>
    : ITestTemplate<TType>
{
    public event Action TestActionEvent;

    public event Action<string> AssertFailEvent;

    public TType Expected { get; protected set; }

    public TType Acctual { get; protected set; }

    public TestTemplate(
        TType expected)
    {
        Expected = expected;
        TestActionEvent += TryTesting;
    }

    private void TryTesting()
    {
        try
        {
            Testing();
        }
        catch (Exception exception)
        {
            AssertFailEvent.Invoke(exception.Message);
        }
        finally
        {
            RemoveFile();
        }
    }

    protected abstract void Testing();

    protected abstract void RemoveFile();

    public void InvokeTest()
    {
        if (AssertFailEvent == null)
            throw new ArgumentNullException(nameof(AssertFailEvent));
        if (TestActionEvent == null)
            throw new ArgumentNullException(nameof(TestActionEvent));
        TestActionEvent.Invoke();
    }
}