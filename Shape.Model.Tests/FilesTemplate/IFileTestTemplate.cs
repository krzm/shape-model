namespace Shape.Model.Tests;

public interface IFileTestTemplate<TType>
    : ITestTemplate<TType>
{
    bool IsRemovingTempFiles { get; set; }
}