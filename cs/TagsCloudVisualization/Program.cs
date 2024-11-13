using System.Drawing;
using TagsCloudVisualization.TagCloud;

var l = new CircularCloudLayouter(new Point(250,250));
for (int i = 0; i < 100; i++)
{
    var rand = new Random();
    l.PutNextRectangle(new Size(rand.Next(10,70),rand.Next(10,70)));
}

var drawer = new BaseCloudDrawer();
drawer.DrawCloud(l.Rectangles);
