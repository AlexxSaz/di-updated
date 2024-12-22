using Autofac;
using TagCloud.Calculators;
using TagCloud.Logic.CloudLayouts;
using TagCloud.Logic.Containers;
using TagCloud.Logic.PointGenerators;
using TagCloud.Readers;
using TagCloud.TagCloudPainters;
using TagCloud.Tags;
using TagCloud.WordHandlers;

namespace TagCloud;

public class TagCloudModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<SingleWordInRowFileReader>().As<IFileReader>().SingleInstance();
        builder.RegisterType<WordSizeCalculator>().As<ISizeCalculator>().SingleInstance();
        builder.RegisterType<WordTagCloudPainter>().As<ITagCloudPainter>().SingleInstance();
        builder.RegisterType<WordTagCloud>().As<ITagCloud>().SingleInstance();
        builder.RegisterType<SimpleWordTag>().As<IWordTag>().SingleInstance();
        builder.RegisterType<SimpleWordHandler>().As<IWordHandler>().SingleInstance();
        builder.RegisterType<CircularCloudLayout>().As<ICloudLayout>().SingleInstance();
        builder.RegisterType<SpiralPointGenerator>().As<IPointGenerator>().SingleInstance();
    }
}