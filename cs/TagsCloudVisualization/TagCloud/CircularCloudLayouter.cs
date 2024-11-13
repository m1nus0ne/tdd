using System.Drawing;

namespace TagsCloudVisualization.TagCloud;

public class CircularCloudLayouter(Point center)
{
    private readonly Point center = center;
    private readonly IPositionCalculator calculator = new SpiralPositionCalculator(center);

    public List<Rectangle> Rectangles { get; private set; } = [];

    public Rectangle PutNextRectangle(Size rectangleSize)
    {
        if (rectangleSize.Width <= 0)
            throw new ArgumentException("Size width must be positive number");
        if (rectangleSize.Height <= 0)
            throw new ArgumentException("Size height must be positive number");

        var temp = calculator.CalculateNextPosition(Rectangles, rectangleSize); //вывести на ленивую реализацию?
        Rectangles.Add(temp);
        return temp;
    }
}