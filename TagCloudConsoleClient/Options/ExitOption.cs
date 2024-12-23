using CommandLine;

namespace TagCloudConsoleClient.Options;

[Verb("exit", HelpText = "Выход")]
public class ExitOption : IOption
{
    public SettingsType SettingsType => SettingsType.Exit;
}