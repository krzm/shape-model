using Sim.Core;

namespace Shape.Model.Tests;

public abstract class FileTestTemplate<TType>
    : TestTemplate<TType>
    , IFileTestTemplate<TType>
{
    protected readonly IFilePath FilePath;

    public bool IsRemovingTempFiles { get; set; }

    public FileTestTemplate(
        IFilePath filePath
        , TType expected)
            : base(expected)
    {
        FilePath = filePath;
        IsRemovingTempFiles = true;
    }

    public override string ToString() =>
        $"{MyConst.NewLine}Expected:{MyConst.NewLine}{Expected}{MyConst.NewLine}{MyConst.NewLine}Acctual:{MyConst.NewLine}{Acctual}";

    protected override void RemoveFile()
    {
        if (!IsRemovingTempFiles) return;
        if (!File.Exists(FilePath.FullPath)) return;
        File.Delete(FilePath.FullPath);
    }
}