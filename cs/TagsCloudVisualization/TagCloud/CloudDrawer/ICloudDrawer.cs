using System.Drawing;

namespace TagsCloudVisualization.TagCloud;

public interface ICloudDrawer
{
    public void DrawCloud(List<Rectangle> rectangles, string? fileName, string? path, int imageWidth);
}