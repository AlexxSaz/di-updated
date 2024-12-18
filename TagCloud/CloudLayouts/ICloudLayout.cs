using System.Drawing;

namespace TagCloud.CloudLayouts;

public interface ICloudLayout
{
    public Rectangle PutNextRectangle(Size rectangleSize);
}