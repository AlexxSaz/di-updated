using System.Drawing;
using TagCloud.Infrastructure;
using TagCloud.Infrastructure.Providers.Interfaces;
using TagCloudConsoleClient.Options;

namespace TagCloudConsoleClient.Actions;

public class PaletteAction(IPaletteProvider paletteProvider) : IConsoleAction
{
    public OptionType OptionType => OptionType.Color;

    public string Perform(IOption option)
    {
        var optionSettings = (ColorSettingsOption)option;
        paletteProvider.SetPalette(CreatePalette(optionSettings));
        return
            $"Цвета установлены. Цвет текста - {GetColor(optionSettings.Font)}, цвет фона - {optionSettings.Background}.";
    }

    private static Palette CreatePalette(ColorSettingsOption optionSettings)
    {
        var palette = new Palette();
        var fontColor = GetColor(optionSettings.Font);
        var backgroundColor = GetColor(optionSettings.Background);
        return palette with { FontColor = fontColor, BackgroundColor = backgroundColor };
    }

    private static Color GetColor(byte colorNumber) =>
        colorNumber switch
        {
            1 => Color.Black,
            2 => Color.White,
            3 => Color.Red,
            4 => Color.Blue,
            5 => Color.Green,
            6 => Color.Gray,
            7 => Color.Brown,
            8 => Color.Yellow,
            _ => Color.Black
        };
}