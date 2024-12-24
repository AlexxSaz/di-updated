using CommandLine;

namespace TagCloudConsoleClient.Options;

[Verb("logic", HelpText = "Настройка логики")]
public class LogicSettingsOption : IOption
{
    [Option('a', "angleStep", HelpText = "Шаг увеличения угла спирали.")]
    public double AngleStep { get; set; } = 0.01;

    [Option('r', "radiusStep", HelpText = "Шаг увеличения радиуса спирали.")]
    public double RadiusStep { get; set; } = 0.01;

    [Option('g', "generatorType", HelpText = "Тип генератора точек.\n1 - Спираль\n2 - Астроида")]
    public int PointGeneratorType { get; set; } = 1;

    public OptionType OptionType => OptionType.Logic;
}