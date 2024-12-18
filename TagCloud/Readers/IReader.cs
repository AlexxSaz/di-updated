namespace TagCloud.Readers;

public interface IFileReader
{
    IEnumerable<string> Read(string path);
}