using System.Drawing;
using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Tags;
using TagCloud.Logic.CloudContainers;
using TagCloud.Logic.CloudLayouts;
using TagCloud.Logic.PointGenerators.Factory;
using Font = TagCloud.Model.Font;
using Point = TagCloud.Model.Point;

namespace TagCloud.TagCloudPainters;

public class WordTagCloudPainter : ITagCloudPainter
{
    public IReadOnlyCollection<IWordTag> PrintImage(
        IEnumerable<IWordTag> wordTags,
        ImageSettings imageSettings,
        LogicSettings logicSettings)
    {
        const int rectangleOutline = 1;
        var cloudLayout = new StandardCloudLayout(logicSettings, new StandardPointGeneratorFactory());
        using var bitmap = new Bitmap(
            imageSettings.Width + rectangleOutline,
            imageSettings.Height + rectangleOutline);
        using var graphics = Graphics.FromImage(bitmap);

        return (from tag in wordTags
            let font = tag.Font with { Family = imageSettings.FontFamily }
            let frame = cloudLayout.PutNextRectangle(CalculateWordSize(graphics, tag, font))
            let tagLocation = new Point(frame.X + imageSettings.Width / 2, frame.Y + imageSettings.Height / 2)
            select new StandardWordTag(tag.Value, font, tagLocation)).Cast<IWordTag>().ToList();
    }

    private static Size CalculateWordSize(Graphics graphics, IWordTag wordTag, Font font)
    {
        var textSize = graphics.MeasureString(wordTag.Value,
            new System.Drawing.Font(font.Family, font.Size));
        var viewWidth = (int)Math.Ceiling(textSize.Width);
        var viewHeight = (int)Math.Ceiling(textSize.Height);
        var viewSize = new Size(viewWidth, viewHeight);
        return viewSize;
    }
}