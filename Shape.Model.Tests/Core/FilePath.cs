namespace Shape.Model.Tests;

public class FilePath
    : IFilePath
{
    public string FileFolderPath { get; }

    public string FileName { get; }

    public string FileExtension { get; }

    public string FullPath { get; }

    public FilePath(
        string fileFolderPath,
        string fileName,
        string fileExtension)
    {
        FileFolderPath = fileFolderPath.TrimEnd('\\');
        FileName = fileName;
        FileExtension = fileExtension.TrimStart('.');
        if (!IsFolderSet() && IsFileSet())
            FullPath = $"{FileName}.{FileExtension}";
        else if (IsFolderSet() && IsFileSet())
            FullPath = $@"{FileFolderPath}\{FileName}.{FileExtension}";
        else throw new ArgumentNullException(nameof(fileName), nameof(fileExtension));
    }

    private bool IsFolderSet() => !string.IsNullOrWhiteSpace(FileFolderPath);

    private bool IsFileSet() => !string.IsNullOrWhiteSpace(FileName) && !string.IsNullOrWhiteSpace(FileExtension);
}