namespace TagCloud.Calculators;

public interface ISizeCalculator
{
    Dictionary<string, int> Calculate(IEnumerable<string> words, int maxSize = 24, int minSize = 8);
}