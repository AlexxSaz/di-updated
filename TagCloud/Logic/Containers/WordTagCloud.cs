using TagCloud.Calculators;
using TagCloud.Infrastructure.Providers.Interfaces;
using TagCloud.Infrastructure.Tags;
using TagCloud.Logic.CloudLayouts;
using TagCloud.WordHandlers;

namespace TagCloud.Logic.Containers;

public class WordTagCloud : ITagCloud
{
    public ICloudLayout CloudLayout { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }

    public WordTagCloud(IImageSettingsProvider imageSettingsProvider, ILogicSettingsProvider logicSettingsProvider)
    {
        var imageSettings = imageSettingsProvider.GetImageSettings();
        var logicSettings = logicSettingsProvider.GetLogicSettings();
        Width = imageSettings.Width;
        Height = imageSettings.Height;
        CloudLayout = new CircularCloudLayout(logicSettings);
    }

    public List<IWordTag> GetTags(IEnumerable<string> words, IWordHandler wordHandler, ISizeCalculator sizeCalculator)
    {
        var handledWords = wordHandler.Handle(words);
        return sizeCalculator.Calculate(handledWords);
    }
}