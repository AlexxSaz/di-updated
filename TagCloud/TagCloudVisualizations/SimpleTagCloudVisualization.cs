using System.Drawing;
using System.Drawing.Imaging;
using TagCloud.Extensions;
using TagCloud.Tags;

namespace TagCloud.TagCloudVisualizations;

public class SimpleTagCloudVisualization(AppConfig appConfig, ITagCloud tagCloud) : ITagCloudVisualization
{
    public void SaveImage()
    {
        const int rectangleOutline = 1;
        var bitmap = new Bitmap(
            appConfig.Width + rectangleOutline,
            appConfig.Height + rectangleOutline);
        using var graphics = Graphics.FromImage(bitmap);
        var brushColor = ColorTranslator.FromHtml(appConfig.FontColor);
        using var brush = new SolidBrush(brushColor);

        foreach (var tag in tagCloud.Tags)
        {
            using var font = new Font(appConfig.FontFamily, tag.FontSize);
            var x = tag.Frame.X + appConfig.Width / 2;
            var y = tag.Frame.Y + appConfig.Height / 2;
            graphics.DrawString(tag.Value, font, brush, x, y);
        }

        var path = appConfig.Filename;
        bitmap.Save(path, ImageFormat.Png);
    }
}