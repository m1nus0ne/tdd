using System.Drawing;
using System.Globalization;

namespace TagsCloudVisualization.TagCloud;

public class BaseCloudDrawer : ICloudDrawer
{
    public void DrawCloud(List<Rectangle> rectangles, string? fileName = null, string? path = null,
        int imageWidth = 500)
    {
        path ??= Environment.CurrentDirectory;
        fileName ??= DateTime.Now.ToOADate().ToString(CultureInfo.InvariantCulture);
        using var bitmap = new Bitmap(imageWidth, imageWidth);
        using var graphics = Graphics.FromImage(bitmap);
        graphics.Clear(Color.White);

        foreach (var rectangle in rectangles)
        {
            graphics.DrawRectangle(new Pen(Color.Black), rectangle);
        }

        bitmap.Save(Path.Combine(path, fileName + ".png"));
    }
}