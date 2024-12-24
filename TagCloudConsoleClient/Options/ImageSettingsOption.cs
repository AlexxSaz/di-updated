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
    public byte FontFamily { get; set; } = 1;
    
    [Option('u', "font", HelpText = "Вид шрифта")]
    public byte MaxFontSize { get; set; } = 36;
    
    [Option('l', "font", HelpText = "Вид шрифта")]
    public byte MinFontSize { get; set; } = 10;

    public OptionType OptionType => OptionType.Image;
}