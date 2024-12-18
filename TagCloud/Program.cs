using Autofac;
using TagCloud.CloudLayouts;
using TagCloud.Readers;
using TagCloud.TagCloudVisualizations;
using TagCloud.Tags;
using TagCloud.WordHandlers;

namespace TagCloud;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<App>();
        builder.RegisterType<TagCloud>().As<ITagCloud>().SingleInstance();
        builder.RegisterType<CircularCloudLayout>().As<ICloudLayout>().SingleInstance();
        builder.RegisterType<SingleWordInRowFileReader>().As<IFileReader>().SingleInstance();
        builder.RegisterType<SimpleTagCloudVisualization>()
            .As<ITagCloudVisualization>()
            .SingleInstance();

        builder.RegisterType<AppConfig>().SingleInstance();
        builder.RegisterType<SimpleWordHandler>().As<IWordHandler>().SingleInstance();
        builder.RegisterType<WordTag>().As<ITag>().SingleInstance();

        var container = builder.Build();
        var app = container.Resolve<App>();
        app.Run();
    }
}