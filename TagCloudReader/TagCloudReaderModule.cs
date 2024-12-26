using Autofac;
using TagCloud.Readers;

namespace TagCloudReader;

public class TagCloudReaderModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<SingleWordInRowFileReader>().As<IFileReader>().SingleInstance();
    }
}