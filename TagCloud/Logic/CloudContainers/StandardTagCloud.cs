using TagCloud.Calculators;
using TagCloud.Infrastructure.Tags;
using TagCloud.WordHandlers;

namespace TagCloud.Logic.CloudContainers;

public class StandardTagCloud(IWordHandler wordHandler, ISizeCalculator sizeCalculator) : ITagCloud
{
    public IReadOnlyCollection<IWordTag> GetTags(IEnumerable<string> words)
    {
        var handledWords = wordHandler.Handle(words);
        return sizeCalculator.Calculate(handledWords);
    }
}