namespace TagCloud.Calculators;

public class WordSizeCalculator : ISizeCalculator
{
    public Dictionary<string, int> Calculate(IEnumerable<string> words, int maxSize = 24, int minSize = 8)
    {
        var result = new Dictionary<string, int>();

        foreach (var word in words)
        {
            result.TryAdd(word, 0);
            result[word]++;
        }

        foreach (var word in result.Keys)
        {
            result[word] = GetSize(result[word], maxSize, minSize);
        }

        return result;
    }

    private static int GetSize(int count, int maxSize, int minSize) => count * (maxSize - minSize) / 2 + minSize;
}