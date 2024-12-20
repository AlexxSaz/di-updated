using System.Drawing;
using TagCloud.CloudLayouts;
using TagCloud.Tags;

namespace TagCloud;

public class WordTagCloud(AppConfig appConfig, ICloudLayout cloudLayout) : ITagCloud
{
    public List<ITag> Tags { get; set; } = new();

    public ICloudLayout CloudLayout => cloudLayout;
    public int Width => appConfig.Width;
    public int Height => appConfig.Height;
}