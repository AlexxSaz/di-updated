using CommandLine;

namespace TagCloudConsoleClient.Options;

[Verb("color", HelpText = "Настройка цвета")]
public class ColorSettingsOption : IOption
{
    [Option('f', "font", HelpText = "Цвет текста")]
    public byte Font { get; set; } = 1;

    [Option('b', "background", HelpText = "Цвет заливки")]
    public byte Background { get; set; } = 2;

    public SettingsType SettingsType => SettingsType.Color;
}