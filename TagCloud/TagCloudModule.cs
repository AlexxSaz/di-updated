using Autofac;
using TagCloud.Calculators;
using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Providers;
using TagCloud.Infrastructure.Providers.Interfaces;
using TagCloud.Infrastructure.Tags;
using TagCloud.Logic.CloudLayouts;
using TagCloud.Logic.PointGenerators;
using TagCloud.Logic.PointGenerators.Factory;
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
        builder.RegisterType<SimpleWordHandler>().As<IWordHandler>().SingleInstance();
        builder.RegisterType<SimplePointGeneratorFactory>().As<IPointGeneratorFactory>().SingleInstance();
        
        builder.RegisterType<ImageSettingsProvider>().As<IImageSettingsProvider>().SingleInstance();
        builder.RegisterType<LogicSettingsProvider>().As<ILogicSettingsProvider>().SingleInstance();
        builder.RegisterType<PaletteProvider>().As<IPaletteProvider>().SingleInstance();
        
        builder.RegisterType<WordTagCloudPainter>().As<ITagCloudPainter>();
        builder.RegisterType<SimpleWordTag>().As<IWordTag>();
        builder.RegisterType<SimpleCloudLayout>().As<ICloudLayout>();
        builder.RegisterType<SpiralPointGenerator>().As<IPointGenerator>();
        
        builder.RegisterType<ImageSettings>();
        builder.RegisterType<Palette>();
        builder.RegisterType<LogicSettings>();
        builder.RegisterType<SaveSettings>();
    }
}