using TagCloud.Calculators;
using TagCloud.Infrastructure.Tags;
using TagCloud.Logic.CloudLayouts;
using TagCloud.WordHandlers;

namespace TagCloud.Logic.Containers;

public interface ITagCloud
{
    ICloudLayout CloudLayout { get; }
    int Width { get; }
    int Height { get; }

    List<IWordTag> GetTags(IEnumerable<string> words, IWordHandler wordHandler, ISizeCalculator sizeCalculator);
}