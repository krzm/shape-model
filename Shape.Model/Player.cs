namespace Shape.Model;

public abstract class Player : IPlayer
{
    private const int SpecialBallsCount = 2;

    abstract public int Score { get; set; }

    abstract public bool IsActive { get; set; }

    public string Name { get; set; }

    public string Color { get; set; }

    public bool AllScored(List<IShape> notScoredBalls) =>
        notScoredBalls.Count(
        ball => ball.TextFlag == Color) == SpecialBallsCount;
}