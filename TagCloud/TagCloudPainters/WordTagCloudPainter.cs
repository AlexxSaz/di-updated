using System.Drawing;
using System.Drawing.Imaging;
using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Tags;
using TagCloud.Logic.Containers;

namespace TagCloud.TagCloudPainters;

public class WordTagCloudPainter(ImageSettings imageSettings, Palette palette, ITagCloud tagCloud) : ITagCloudPainter
{
    public void SaveImage()
    {
        const int rectangleOutline = 1;
        var bitmap = new Bitmap(
            tagCloud.Width + rectangleOutline,
            tagCloud.Height + rectangleOutline);
        using var graphics = Graphics.FromImage(bitmap);
        var fontColor = palette.PrimaryColor;
        var backgroundColor = palette.BackgroundColor;
        graphics.Clear(backgroundColor);
        using var brush = new SolidBrush(fontColor);

        foreach (var tag in tagCloud.Tags)
        {
            using var font = new Font(imageSettings.FontFamily, tag.FontSize);
            var frame =
                tagCloud.CloudLayout.PutNextRectangle(CalculateWordSize(graphics, tag, font));
            var x = frame.X + tagCloud.Width / 2;
            var y = frame.Y + tagCloud.Height / 2;
            graphics.DrawString(tag.Value, font, brush, x, y);
        }

        var path = imageSettings.Filename;
        bitmap.Save(path, ImageFormat.Png);
    }

    private static Size CalculateWordSize(Graphics graphics, IWordTag viewWord, Font font)
    {
        var textSize = graphics.MeasureString(viewWord.Value, font);
        var viewWidth = (int)Math.Ceiling(textSize.Width);
        var viewHeight = (int)Math.Ceiling(textSize.Height);
        var viewSize = new Size(viewWidth, viewHeight);
        return viewSize;
    }
}