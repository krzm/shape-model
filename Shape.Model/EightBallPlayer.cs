namespace Shape.Model;

public class EightBallPlayer : Player
{
    private int _score;

    public override int Score
    {
        get => 7 - _score;
        set => _score = value;
    }

    public override bool IsActive { get; set; }

    public EightBallPlayer()
    {

    }
}