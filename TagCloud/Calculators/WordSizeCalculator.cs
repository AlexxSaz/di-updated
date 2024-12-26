using System.Drawing;
using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Tags;

namespace TagCloud.Calculators;

public class WordSizeCalculator(ImageSettings imageSettings) : ISizeCalculator
{
    public IReadOnlyCollection<IWordTag> Calculate(IEnumerable<string> words)
    {
        var result = new List<IWordTag>();
        var dictionaryWithWordFrequency = GetDictionaryWithWordFrequency(words);
        var maxFrequency = dictionaryWithWordFrequency.Values.Max();

        foreach (var wordCountPair in dictionaryWithWordFrequency)
        {
            var normalizedFrequency = GetNormalizedFrequency(wordCountPair.Value, maxFrequency);
            var size = GetSize(normalizedFrequency, imageSettings.MaxFontSize, imageSettings.MinFontSize);
            var wordTag = new SimpleWordTag(wordCountPair.Key, new Font(imageSettings.FontFamily, size), new Point());
            result.Add(wordTag);
        }

        return result;
    }

    private static Dictionary<string, int> GetDictionaryWithWordFrequency(IEnumerable<string> words)
    {
        var wordFrequencyDictionary = new Dictionary<string, int>();
        foreach (var word in words)
        {
            wordFrequencyDictionary.TryAdd(word, 0);
            wordFrequencyDictionary[word]++;
        }

        return wordFrequencyDictionary;
    }

    private static int GetSize(double normalizedFrequency, int maxSize, int minSize) =>
        (int)(normalizedFrequency * (maxSize - minSize) / 2 + minSize);

    private static double GetNormalizedFrequency(int count, int maxCount) =>
        Math.Log10(count + 1) / Math.Log10(maxCount + 1);
}