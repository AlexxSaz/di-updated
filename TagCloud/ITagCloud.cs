using System.Drawing;
using TagCloud.Tags;

namespace TagCloud;

public interface ITagCloud
{
    int Width { get; }

    int Height { get; }

    int LeftBound { get; }

    int TopBound { get; }

    void SetNewSize(Rectangle frame);
}