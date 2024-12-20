using System.Drawing;
using System.Drawing.Imaging;
using TagCloud.Logic.Containers;
using TagCloud.Tags;

namespace TagCloud.TagCloudVisualizations;

public class WordTagCloudPainter(AppConfig appConfig, ITagCloud tagCloud) : ITagCloudPainter
{
    public void SaveImage()
    {
        const int rectangleOutline = 1;
        var bitmap = new Bitmap(
            tagCloud.Width + rectangleOutline,
            tagCloud.Height + rectangleOutline);
        using var graphics = Graphics.FromImage(bitmap);
        var brushColor = ColorTranslator.FromHtml(appConfig.FontColor);
        using var brush = new SolidBrush(brushColor);

        foreach (var tag in tagCloud.Tags)
        {
            using var font = new Font(appConfig.FontFamily, tag.FontSize);
            var tagToPrint =
                tag.SetFrame(tagCloud.CloudLayout.PutNextRectangle(CalculateWordSize(graphics, tag, font)));
            var x = tagToPrint.Frame.X + tagCloud.Width / 2;
            var y = tagToPrint.Frame.Y + tagCloud.Height / 2;
            graphics.DrawString(tagToPrint.Value, font, brush, x, y);
        }

        var path = appConfig.Filename;
        bitmap.Save(path, ImageFormat.Png);
    }

    private static Size CalculateWordSize(Graphics graphics, ITag viewWord, Font font)
    {
        var textSize = graphics.MeasureString(viewWord.Value, font);
        var viewWidth = (int)Math.Ceiling(textSize.Width);
        var viewHeight = (int)Math.Ceiling(textSize.Height);
        var viewSize = new Size(viewWidth, viewHeight);
        return viewSize;
    }
}