using Autofac;
using TagCloud;
using TagCloudConsoleClient;
using TagCloudConsoleClient.Runners;

var builder = new ContainerBuilder();
builder.RegisterModule(new TagCloudConsoleModule());
builder.RegisterModule(new TagCloudModule());

var app = builder.Build();
var appRunner = app.Resolve<IAppRunner>();
appRunner.Run();