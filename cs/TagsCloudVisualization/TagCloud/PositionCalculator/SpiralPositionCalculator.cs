using System.Drawing;

namespace TagsCloudVisualization.TagCloud;

public class SpiralPositionCalculator(Point center) : IPositionCalculator
{
    private double currentAngle = 0.0;
    private double currentOffset = 0.0;
    private const double offsetDelta = 2;
    private const double angleDelta = 0.1;

    public Rectangle CalculateNextPosition(List<Rectangle> rectangles, Size nextRectangleSize)
    {
        while (true)
        {
            var newRectangle = RectangleFromParams(nextRectangleSize);
            currentAngle += angleDelta;
            if (currentAngle >= 2 * Math.PI)
            {
                currentAngle = 0;
                currentOffset += offsetDelta;
            }

            if (ValidateRectanglePosition(rectangles, newRectangle))
                return newRectangle;
        }
    }

    private Rectangle RectangleFromParams(Size nextRectangleSize)
    {
        var x = (int)(center.X + currentOffset * Math.Cos(currentAngle)); //надо центровать?
        var y = (int)(center.Y + currentOffset * Math.Sin(currentAngle));
        var newRectangle = new Rectangle(new Point(x, y), nextRectangleSize);
        return newRectangle;
    }

    public bool ValidateRectanglePosition(List<Rectangle> rectangles, Rectangle currentRectangle)
    {
        return !rectangles.Any(r => r.IntersectsWith(currentRectangle));
    }
}