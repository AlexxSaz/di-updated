using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Providers.Interfaces;
using TagCloudConsoleClient.Options;

namespace TagCloudConsoleClient.Actions;

public class PaletteAction(IPaletteProvider paletteProvider, Palette palette) : IConsoleAction
{
    public OptionType OptionType => OptionType.Color;

    public string Perform(IOption option)
    {
        var optionSettings = (ColorSettingsOption)option;
        var currentPalette = CreatePalette(optionSettings);
        paletteProvider.SetPalette(currentPalette);
        return
            $"Цвета установлены. Цвет текста - {optionSettings.Font}, цвет фона - {optionSettings.Background}.";
    }

    private Palette CreatePalette(ColorSettingsOption optionSettings) =>
        palette with { FontColor = optionSettings.Font, BackgroundColor = optionSettings.Background };
}