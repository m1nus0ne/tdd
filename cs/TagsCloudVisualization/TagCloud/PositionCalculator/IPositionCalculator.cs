using System.Drawing;

namespace TagsCloudVisualization.TagCloud;

public interface IPositionCalculator
{
    public Rectangle CalculateNextPosition(List<Rectangle> rectangles, Size nextRectangleSize);
    public bool ValidateRectanglePosition(List<Rectangle> rectangles, Rectangle currentRectangle);
}