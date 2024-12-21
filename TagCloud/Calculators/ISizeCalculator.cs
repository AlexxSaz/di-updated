using TagCloud.Tags;

namespace TagCloud.Calculators;

public interface ISizeCalculator
{
    List<ITag> Calculate(IEnumerable<string> words, int maxSize = 24, int minSize = 8);
}