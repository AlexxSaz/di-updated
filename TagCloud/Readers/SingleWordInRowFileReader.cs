namespace TagCloud.Readers;

public class SingleWordInRowFileReader : IFileReader
{
    private readonly string[] _defaultWords = "Несколько дефолтных слов".Split();

    public IEnumerable<string> Read(string path) =>
        IsValidFile(path) 
            ? _defaultWords
            : File.ReadAllLines(path);

    private static bool IsValidFile(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentNullException(nameof(path));

        if (!File.Exists(path))
            throw new FileNotFoundException($"File {path} not found");

        return true;
    }
}