using TagCloud.Infrastructure.Tags;

namespace TagCloud.Calculators;

public interface ISizeCalculator
{
    List<IWordTag> Calculate(IEnumerable<string> words, int maxSize = 24, int minSize = 8);
}