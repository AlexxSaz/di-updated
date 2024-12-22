using CommandLine;
using TagCloud.Logic.CloudLayouts;

namespace TagCloudConsoleClient.Options;

[Verb("logic", HelpText = "Настройка логики")]
public class LogicSettingsOption : IOption
{
    [Option('a', "angleStep", HelpText = "Шаг увеличения угла спирали.")]
    public double AngleStep { get; set; } = 0.01;

    [Option('r', "radiusStep", HelpText = "Шаг увеличения радиуса спирали.")]
    public double RadiusStep { get; set; } = 0.01;
    
    [Option('l', "layout", HelpText = "Лайаут облака.")]
    public ICloudLayout CloudLayout { get; set; }

    public SettingsType SettingsType => SettingsType.Logic;
}