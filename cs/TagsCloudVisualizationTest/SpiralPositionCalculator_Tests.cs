using System.Drawing;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudVisualization.TagCloud;

namespace TagsCloudVisualization.Tests
{
    [TestFixture]
    public class SpiralPositionCalculatorTests
    {
        private SpiralPositionCalculator calculator;
        private Point center;

        [SetUp]
        public void SetUp()
        {
            center = new Point(0, 0);
            calculator = new SpiralPositionCalculator(center);
        }

        [Test]
        public void CalculateNextPosition_ShouldReturnRectangleAtCenter_WhenNoRectanglesExist()
        {
            var size = new Size(10, 10);
            var rectangles = new List<Rectangle>();

            var result = calculator.CalculateNextPosition(rectangles, size);

            result.Location.Should().Be(center);
        }

        [Test]
        public void CalculateNextPosition_ShouldReturnNonIntersectingRectangle_WhenRectanglesExist()
        {
            var size = new Size(10, 10);
            var rectangles = new List<Rectangle>
            {
                new Rectangle(new Point(0, 0), size)
            };

            var result = calculator.CalculateNextPosition(rectangles, size);

            result.IntersectsWith(rectangles[0]).Should().BeFalse();
        }

        [Test]
        public void CalculateNextPosition_ShouldIncreaseOffset_WhenAngleCompletesFullCircle()
        {
            var size = new Size(10, 10);
            var rectangles = new List<Rectangle>();

            for (int i = 0; i < 100; i++)
            {
                calculator.CalculateNextPosition(rectangles, size);
            }

            var result = calculator.CalculateNextPosition(rectangles, size);

            result.Location.Should().NotBe(center);
        }

        [Test]
        public void ValidateRectanglePosition_ShouldReturnTrue_WhenNoIntersections()
        {
            var size = new Size(10, 10);
            var rectangles = new List<Rectangle>();
            var rectangle = new Rectangle(new Point(0, 0), size);

            var result = calculator.ValidateRectanglePosition(rectangles, rectangle);

            result.Should().BeTrue();
        }

        [Test]
        public void ValidateRectanglePosition_ShouldReturnFalse_WhenIntersectsWithExistingRectangle()
        {
            var size = new Size(10, 10);
            var rectangles = new List<Rectangle>
            {
                new Rectangle(new Point(0, 0), size)
            };
            var rectangle = new Rectangle(new Point(0, 0), size);

            var result = calculator.ValidateRectanglePosition(rectangles, rectangle);

            result.Should().BeFalse();
        }
    }
}