using System.Drawing;
using TagCloud.Extensions;
using TagCloud.Tags;

namespace TagCloud.TagCloudVisualizations;

public class SimpleTagCloudVisualization : ITagCloudVisualization
{
    private static readonly Random Random = new();

    private static Pen GetRandomPen =>
        new(Color.FromArgb(
            Random.Next(0, 255),
            Random.Next(0, 255),
            Random.Next(0, 255)));
    
    private readonly List<ITag> tags = [];
    
    public void AddTag(ITag tag) => tags.Add(tag);

    public void SaveTagCloudAsBitmap(ITagCloud tagCloud, string file)
    {
        const int rectangleOutline = 1;

        using var bitmap = new Bitmap(
            tagCloud.Width + rectangleOutline,
            tagCloud.Height + rectangleOutline);
        var frameShift = new Size(-tagCloud.LeftBound, -tagCloud.TopBound);

        using (var graphics = Graphics.FromImage(bitmap))
        {
            foreach (var rectangleInFrame in tags.Select(tag =>
                         MoveRectangleToImageFrame(tag.Frame, frameShift)))
            {
                graphics.DrawRectangle(GetRandomPen, rectangleInFrame);
            }
        }

        bitmap.Save(file);
    }

    private static Rectangle MoveRectangleToImageFrame(Rectangle rectangle, Size imageCenter) =>
        new(rectangle.Location.MoveTo(imageCenter), rectangle.Size);
}