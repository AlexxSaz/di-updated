using TagCloud.Calculators;
using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Tags;
using TagCloud.Logic.CloudLayouts;
using TagCloud.Readers;
using TagCloud.WordHandlers;

namespace TagCloud.Logic.Containers;

public class WordTagCloud(
    ImageSettings imageSettings,
    ICloudLayout cloudLayout,
    ISizeCalculator sizeCalculator,
    IFileReader reader,
    IWordHandler wordHandler) : ITagCloud
{
    public List<IWordTag> Tags { get; set; } = GetTags(reader, wordHandler, sizeCalculator);

    public ICloudLayout CloudLayout => cloudLayout;
    public int Width => imageSettings.Width;
    public int Height => imageSettings.Height;

    private static List<IWordTag> GetTags(IFileReader reader, IWordHandler wordHandler, ISizeCalculator sizeCalculator)
    {
        var words = reader.Read("aboutKonturWords.txt");
        var handledWords = wordHandler.Handle(words);
        var tags = sizeCalculator.Calculate(handledWords);

        return tags;
    }
}