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
    public void SaveImage(
        ImageSettings imageSettings,
        Palette palette,
        SaveSettings saveSettings,
        LogicSettings logicSettings)
    {
        const int rectangleOutline = 1;
        var cloudLayout = new SimpleCloudLayout(logicSettings, new PointGeneratorFactory());
        var bitmap = new Bitmap(
            imageSettings.Width + rectangleOutline,
            imageSettings.Height + rectangleOutline);
        using var graphics = Graphics.FromImage(bitmap);
        var fontColor = palette.FontColor;
        var backgroundColor = palette.BackgroundColor;
        graphics.Clear(backgroundColor);
        using var brush = new SolidBrush(fontColor);
        var words = reader.Read(saveSettings.InputTxtFile);
        var tags = cloudLayout.GetTags(
            words,
            wordHandler,
            sizeCalculator,
            imageSettings);

        foreach (var tag in tags)
        {
            using var font = new Font(imageSettings.FontFamily, tag.FontSize);
            var frame =
                cloudLayout.PutNextRectangle(CalculateWordSize(graphics, tag, font));
            var x = frame.X + imageSettings.Width / 2;
            var y = frame.Y + imageSettings.Height / 2;
            graphics.DrawString(tag.Value, font, brush, x, y);
        }

        var path = saveSettings.OutputPngFile;
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