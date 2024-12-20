using Autofac;
using TagCloud.Calculators;
using TagCloud.Logic.CloudLayouts;
using TagCloud.Logic.Containers;
using TagCloud.Logic.PointGenerators;
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
        
        builder.RegisterType<SingleWordInRowFileReader>().As<IFileReader>().SingleInstance();
        builder.RegisterType<WordSizeCalculator>().As<ISizeCalculator>().SingleInstance();
        builder.RegisterType<WordTagCloudPainter>().As<ITagCloudPainter>().SingleInstance();
        builder.RegisterType<WordTagCloud>().As<ITagCloud>().SingleInstance();
        builder.RegisterType<WordTag>().As<ITag>().SingleInstance();
        builder.RegisterType<SimpleWordHandler>().As<IWordHandler>().SingleInstance();
        builder.RegisterType<CircularCloudLayout>().As<ICloudLayout>().SingleInstance();
        builder.RegisterType<SpiralPointGenerator>().As<IPointGenerator>().SingleInstance();
        builder.RegisterType<AppConfig>();
        var container = builder.Build();
        
        var tagCloudPainter = container.Resolve<ITagCloudPainter>();
        tagCloudPainter.SaveImage();
    }


}