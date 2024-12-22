using System.Drawing;
using System.Drawing.Imaging;
using TagCloud.Logic.Containers;
using TagCloud.Tags;

namespace TagCloud.TagCloudPainters;

public class WordTagCloudPainter(AppConfig appConfig, ITagCloud tagCloud) : ITagCloudPainter
{
    public void SaveImage()
    {
        const int rectangleOutline = 1;
        var bitmap = new Bitmap(
            tagCloud.Width + rectangleOutline,
            tagCloud.Height + rectangleOutline);
        using var graphics = Graphics.FromImage(bitmap);
        var fontColor = ColorTranslator.FromHtml(appConfig.FontColor);
        var backgroundColor = ColorTranslator.FromHtml(appConfig.BackgroundColor);
        graphics.Clear(backgroundColor);
        using var brush = new SolidBrush(fontColor);

        foreach (var tag in tagCloud.Tags)
        {
            using var font = new Font(appConfig.FontFamily, tag.FontSize);
            var frame =
                tagCloud.CloudLayout.PutNextRectangle(CalculateWordSize(graphics, tag, font));
            var x = frame.X + tagCloud.Width / 2;
            var y = frame.Y + tagCloud.Height / 2;
            graphics.DrawString(tag.Value, font, brush, x, y);
        }

        var path = appConfig.Filename;
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