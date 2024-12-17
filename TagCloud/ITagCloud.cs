using System.Drawing;

namespace TagCloud;

public interface ITagCloud
{
    public List<Rectangle> Rectangles { get; }
    
    public int Width { get; }
    
    public int Height { get; }
    
    public int LeftBound { get; }
    
    public int TopBound { get; }
    
    public void AddNextRectangleWith(Size size);
}