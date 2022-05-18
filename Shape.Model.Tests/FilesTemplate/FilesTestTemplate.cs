using Sim.Core;

namespace Shape.Model.Tests;

public abstract class FilesTestTemplate<TType>
        : TestTemplate<TType>
        , IFileTestTemplate<TType>
            where TType : class
{
    protected readonly IFilePath ExpectedFilePath;
    protected readonly IFilePath AcctualFilePath;

    public bool IsRemovingTempFiles { get; set; }

    public FilesTestTemplate(
        Dictionary<string, IFilePath> filePaths,
        TType expected) : base(expected)
    {
        ExpectedFilePath = filePaths[nameof(Expected)];
        AcctualFilePath = filePaths[nameof(Acctual)];
        IsRemovingTempFiles = true;
    }

    public override string ToString() =>
        $"{Environment.NewLine}{nameof(Expected)}:{Environment.NewLine}{Expected}{Environment.NewLine}" +
        $"{Environment.NewLine}{nameof(Acctual)}:{Environment.NewLine}{Acctual}";

    protected override void RemoveFile()
    {
        if (!IsRemovingTempFiles) return;
        if (File.Exists(ExpectedFilePath.FullPath))
            File.Delete(ExpectedFilePath.FullPath);
        if (File.Exists(AcctualFilePath.FullPath))
            File.Delete(AcctualFilePath.FullPath);
    }
}