using CommandLine;

namespace TagCloudConsoleClient.Options;

[Verb("image", HelpText = "Настройка изображения")]
public class ImageSettingsOption : IOption
{
    [Option('w', "width", HelpText = "Ширина")]
    public int Width { get; set; } = 2000;

    [Option('h', "height", HelpText = "Высота")]
    public int Height { get; set; } = 2000;
    
    [Option('f', "font", HelpText = "Вид шрифта")]
    public int FontFamily { get; set; } = 2000;

    public SettingsType SettingsType => SettingsType.Image;
}