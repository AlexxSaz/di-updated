using System.Drawing;
using System.Drawing.Imaging;
using TagCloud.Calculators;
using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Tags;
using TagCloud.Logic.CloudLayouts;
using TagCloud.Logic.PointGenerators.Factory;
using TagCloud.Readers;
using TagCloud.WordHandlers;

namespace TagCloud.TagCloudPainters;

public class WordTagCloudPainter(
    IFileReader reader,
    IWordHandler wordHandler,
    ISizeCalculator sizeCalculator) : ITagCloudPainter
{
    public IReadOnlyCollection<IWordTag> SaveImage(
        IEnumerable<string> words,
        ImageSettings imageSettings,
        LogicSettings logicSettings)
    {
        var result = new List<IWordTag>();
        const int rectangleOutline = 1;
        var cloudLayout = new SimpleCloudLayout(logicSettings, new SimplePointGeneratorFactory());
        var bitmap = new Bitmap(
            imageSettings.Width + rectangleOutline,
            imageSettings.Height + rectangleOutline);
        using var graphics = Graphics.FromImage(bitmap);
        var tags = cloudLayout.GetTags(
            words,
            wordHandler,
            sizeCalculator,
            imageSettings);

        foreach (var tag in tags)
        {
            using var font = new Font(imageSettings.FontFamily, tag.Font.Size);
            var frame =
                cloudLayout.PutNextRectangle(CalculateWordSize(graphics, tag, font));
            var tagLocation = new Point(frame.X + imageSettings.Width / 2, frame.Y + imageSettings.Height / 2);
            var tagToPrint = new SimpleWordTag(tag.Value, font, tagLocation);
            result.Add(tagToPrint);
        }

        return result;
    }

    private static Size CalculateWordSize(Graphics graphics, IWordTag wordTag, Font font)
    {
        var textSize = graphics.MeasureString(wordTag.Value, font);
        var viewWidth = (int)Math.Ceiling(textSize.Width);
        var viewHeight = (int)Math.Ceiling(textSize.Height);
        var viewSize = new Size(viewWidth, viewHeight);
        return viewSize;
    }
}