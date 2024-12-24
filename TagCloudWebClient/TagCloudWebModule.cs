using Autofac;

namespace TagCloudWebClient;

public class TagCloudWebModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<App>();
    }
}