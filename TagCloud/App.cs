using TagCloud.Logic.CloudLayouts;
using TagCloud.Readers;
using TagCloud.TagCloudPainters;
using TagCloud.WordHandlers;

namespace TagCloud;

public class App(
    ITagCloudPainter painter,
    ICloudLayout layout,
    IFileReader fileReader,
    IWordHandler wordHandler,
    AppConfig appConfig)
{
    public void Run()
    {
    }
}