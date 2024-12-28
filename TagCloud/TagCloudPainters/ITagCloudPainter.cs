using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Tags;

namespace TagCloud.TagCloudPainters;

public interface ITagCloudPainter
{
    IReadOnlyCollection<IWordTag> PrintImage(
        IEnumerable<IWordTag> wordTags,
        ImageSettings imageSettings,
        LogicSettings logicSettings);
}