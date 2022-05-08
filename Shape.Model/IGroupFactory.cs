using System.Windows;

namespace Shape.Model;

public interface IGroupFactory
{
    IShapeGroup GetShape(
        SelectedGroup selectedGroup
        , Point massCenter);
}