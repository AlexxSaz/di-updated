using TagCloud.CloudLayouts;
using TagCloud.Readers;
using TagCloud.TagCloudVisualizations;
using TagCloud.WordHandlers;

namespace TagCloud;

public class App(
    ITagCloudVisualization visualization,
    ICloudLayout layout,
    IFileReader fileReader,
    IWordHandler wordHandler,
    AppConfig appConfig)
{
    public void Run()
    {
    }
}