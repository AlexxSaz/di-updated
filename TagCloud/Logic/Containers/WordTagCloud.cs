using TagCloud.Calculators;
using TagCloud.Logic.CloudLayouts;
using TagCloud.Readers;
using TagCloud.Tags;
using TagCloud.WordHandlers;

namespace TagCloud.Logic.Containers;

public class WordTagCloud(
    AppConfig appConfig,
    ICloudLayout cloudLayout,
    ISizeCalculator sizeCalculator,
    IFileReader reader,
    IWordHandler wordHandler) : ITagCloud
{
    public List<IWordTag> Tags { get; set; } = GetTags(reader, wordHandler, sizeCalculator);

    public ICloudLayout CloudLayout => cloudLayout;
    public int Width => appConfig.Width;
    public int Height => appConfig.Height;

    private static List<IWordTag> GetTags(IFileReader reader, IWordHandler wordHandler, ISizeCalculator sizeCalculator)
    {
        var words = reader.Read("aboutKonturWords.txt");
        var handledWords = wordHandler.Handle(words);
        var tags = sizeCalculator.Calculate(handledWords);

        return tags;
    }
}