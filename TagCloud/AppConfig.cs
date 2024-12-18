using TagCloud.Readers;

namespace TagCloud;

public class AppConfig(IFileReader fileReader)
{
    private const string BoringWordsFilePath = "BoringWordsDictionary.txt";

    public int Width { get; set; } = 960;
    public int Height { get; set; } = 600;
    public double RadiusStep { get; set; } = 0.01;
    public double AngleStep { get; set; } = 0.01;
    public string FontFamily { get; set; } = "Arial";
    public string FontColor { get; set; } = "#FFFFFF";

    public string BackgroundColor { get; set; } = "#000000";
    public string Filename { get; set; } = "TagCloud.png";

    public HashSet<string> BoringWords =>
        fileReader.Read(BoringWordsFilePath).ToHashSet();
}