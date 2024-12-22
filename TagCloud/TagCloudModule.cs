using Autofac;
using TagCloud.Calculators;
using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Providers;
using TagCloud.Infrastructure.Tags;
using TagCloud.Logic.CloudLayouts;
using TagCloud.Logic.Containers;
using TagCloud.Logic.PointGenerators;
using TagCloud.Readers;
using TagCloud.TagCloudPainters;
using TagCloud.WordHandlers;

namespace TagCloud;

public class TagCloudModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<SingleWordInRowFileReader>().As<IFileReader>().SingleInstance();
        builder.RegisterType<WordSizeCalculator>().As<ISizeCalculator>().SingleInstance();
        builder.RegisterType<WordTagCloudPainter>().As<ITagCloudPainter>().InstancePerDependency();
        builder.RegisterType<WordTagCloud>().As<ITagCloud>().InstancePerDependency();
        builder.RegisterType<SimpleWordTag>().As<IWordTag>().SingleInstance();
        builder.RegisterType<SimpleWordHandler>().As<IWordHandler>().SingleInstance();
        builder.RegisterType<CircularCloudLayout>().As<ICloudLayout>();
        builder.RegisterType<SpiralPointGenerator>().As<IPointGenerator>();
        builder.RegisterType<ImageSettingsProvider>().As<IImageSettingsProvider>().SingleInstance();
        builder.RegisterType<LogicSettingsProvider>().As<ILogicSettingsProvider>().SingleInstance();
        builder.RegisterType<ImageSettings>();
        builder.RegisterType<Palette>();
        builder.RegisterType<LogicSettings>();
        builder.RegisterType<SaveSettings>();
    }
}