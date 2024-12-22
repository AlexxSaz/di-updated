using CommandLine;

namespace TagCloudConsoleClient.Options;

[Verb("image", HelpText = "Настройка изображения")]
public class ImageSettingsOption : IOption
{
    [Option('w', "width", HelpText = "Ширина")]
    public int Width { get; set; } = 2000;

    [Option('h', "height", HelpText = "Высота")]
    public int Height { get; set; } = 2000;
    
    [Option('l', "layout", HelpText = "Высота")]
    public int CloudLayout { get; set; } = 2000;
    
    [Option('h', "height", HelpText = "Высота")]
    public int FontFamily { get; set; } = 2000;

    public SettingsType SettingsType => SettingsType.Image;
}