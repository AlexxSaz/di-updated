using TagCloud.Infrastructure.Tags;

namespace TagCloud.Logic.CloudContainers;

public interface ITagCloud
{
    IReadOnlyCollection<IWordTag> GetTags(IEnumerable<string> words);
}