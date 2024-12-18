namespace TagCloud.WordHandlers;

public class SimpleWordHandler(AppConfig appConfig) : IWordHandler
{
    public IEnumerable<string> Handle(IEnumerable<string> words) 
    {
        return words
            .Select(word => word.ToLower())
            .Where(word => !string.IsNullOrWhiteSpace(word))
            .Where(word => !appConfig.BoringWords.Contains(word));
    }
}