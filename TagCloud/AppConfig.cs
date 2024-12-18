using TagCloud.Readers;

namespace TagCloud;

public class AppConfig(IFileReader fileReader)
{
    private const string BoringWordsFilePath = "BoringWordsDictionary.txt";

    
    public HashSet<string> BoringWords =>
        fileReader.Read(BoringWordsFilePath).ToHashSet();
}