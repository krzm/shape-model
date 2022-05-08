using System.Windows.Media;

namespace Shape.Model;

public class CircleAnalitics : ShapeGroup
{
    public override Visual[] GetShape()
    {
        var visual = new Visual[Group.Count];
        for (int i = 0; i < Group.Count; i++)
        {
            visual[i] = Group[i].GetVisual();
        }
        return visual;
    }
}