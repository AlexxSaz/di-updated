using FractalPainting.Application;
using FractalPainting.Application.Actions;
using FractalPainting.Application.Fractals;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services
    .AddSingleton<IApiAction, DragonFractalAction>()
    .AddSingleton<IApiAction, UpdateImageSettingsAction>()
    .AddSingleton<IApiAction, UpdatePaletteSettingsAction>()
    .AddSingleton<IApiAction, GetImageSettingsAction>()
    .AddSingleton<IApiAction, GetPaletteSettingsAction>()
    .AddSingleton<IApiAction, KochFractalAction>()
    .AddSingleton<App>();

services.AddSingleton<IObjectSerializer, XmlObjectSerializer>();
services.AddSingleton<IBlobStorage, FileBlobStorage>();
services.AddSingleton<SettingsManager>();
services.AddSingleton<IImageSettingsProvider, AppSettings>(x => 
    x.GetRequiredService<SettingsManager>().Load());
services.AddSingleton<Palette>();
services.AddSingleton<KochPainter>();
services.AddSingleton<IDragonPainterFactory, DragonPainterFactory>();
services.AddSingleton<DragonFractalAction>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<App>();
await app.Run();