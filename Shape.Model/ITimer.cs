namespace Shape.Model;

public interface ITimer
{
    double ElapsedSeconds { get; }

    void Reset();
    void Start();
    void Stop();
}