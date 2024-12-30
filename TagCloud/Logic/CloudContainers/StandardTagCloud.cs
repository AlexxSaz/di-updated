using TagCloud.Calculators;
using TagCloud.Infrastructure.Tags;
using TagCloud.Logic.CloudLayouts;
using TagCloud.WordHandlers;

namespace TagCloud.Logic.CloudContainers;

public class StandardTagCloud(ICloudLayout cloudLayout, IWordHandler wordHandler, ISizeCalculator sizeCalculator) : ITagCloud
{
    public ICloudLayout CloudLayout => cloudLayout;

    public IReadOnlyCollection<IWordTag> GetTags(IEnumerable<string> words)
    {
        var handledWords = wordHandler.Handle(words);
        return sizeCalculator.Calculate(handledWords);
    }
}