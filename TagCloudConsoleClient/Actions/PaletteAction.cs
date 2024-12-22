using TagCloudConsoleClient.Options;

namespace TagCloudConsoleClient.Actions;

public class PaletteAction : IConsoleAction
{
    public SettingsType SettingsType => SettingsType.Palette;
    public string Perform(IOption iOption)
    {
        throw new NotImplementedException();
    }
}