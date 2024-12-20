using System.Drawing;
using Autofac;
using TagCloud.Calculators;
using TagCloud.CloudLayouts;
using TagCloud.PointGenerators;
using TagCloud.Readers;
using TagCloud.TagCloudVisualizations;
using TagCloud.Tags;
using TagCloud.WordHandlers;

namespace TagCloud;

public static class Program
{
    public static void Main(string[] args)
    {
        var center = new Point();
        
        var reader = new SingleWordInRowFileReader();
        var appConfig = new AppConfig(reader);
        var pointGenerator = new SpiralPointGenerator(appConfig, new Size(center));
        var cloudLayout = new CircularCloudLayout(center, pointGenerator);
        var tagCloud = new WordTagCloud(appConfig, cloudLayout);
        var sizeCalculator = new WordSizeCalculator();
        tagCloud.Tags.AddRange(GetTags(reader, appConfig, sizeCalculator));

        var painter = new WordTagCloudPainter(appConfig, tagCloud);
        painter.SaveImage();
    }

    private static List<ITag> GetTags(IFileReader reader, AppConfig appConfig, ISizeCalculator sizeCalculator)
    {
        var result = new List<ITag>();
        var words = reader.Read("aboutKonturWords.txt");
        var wordHandler = new SimpleWordHandler(appConfig);
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