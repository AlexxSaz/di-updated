using System.Drawing;
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
    public List<ITag> Tags { get; set; } = GetTags(reader, wordHandler, sizeCalculator);

    public ICloudLayout CloudLayout => cloudLayout;
    public int Width => appConfig.Width;
    public int Height => appConfig.Height;

    private static List<ITag> GetTags(IFileReader reader, IWordHandler wordHandler, ISizeCalculator sizeCalculator)
    {
        var result = new List<ITag>();
        var words = reader.Read("aboutKonturWords.txt");
        var handledWords = wordHandler.Handle(words);
        var dictHandledWords = sizeCalculator.Calculate(handledWords);
        foreach (var wordPair in dictHandledWords)
        {
            var tag = new WordTag(wordPair.Key, wordPair.Value, Rectangle.Empty);
            result.Add(tag);
        }

        return result;
    }
}