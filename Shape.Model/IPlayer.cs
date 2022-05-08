namespace Shape.Model;

public interface IPlayer
{
    bool IsActive { get; set; }

    int Score { get; set; }

    string Name { get; set; }

    string Color { get; set; }

    bool AllScored(List<IShape> notScoredBalls);
}