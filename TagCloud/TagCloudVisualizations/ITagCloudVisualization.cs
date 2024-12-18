namespace TagCloud.TagCloudVisualizations;

public interface ITagCloudVisualization
{
    void SaveTagCloudAsBitmap(ITagCloud tagCloud, string filePath);
}