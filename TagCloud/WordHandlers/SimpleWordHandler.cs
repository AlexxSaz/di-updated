namespace TagCloud.WordHandlers;

public class SimpleWordHandler(HashSet<string> boringWords) : IWordHandler
{
    public IEnumerable<string> Handle(IEnumerable<string> words) 
    {
        return words
            .Select(word => word.ToLower())
            .Where(word => !string.IsNullOrWhiteSpace(word))
            .Where(word => !boringWords.Contains(word));
    }
}