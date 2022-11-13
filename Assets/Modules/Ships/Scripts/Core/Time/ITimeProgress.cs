namespace Ships.Core
{
    public interface ITimeProgress
    {
        bool IsInProcess { get; }
        float TimeInSeconds { get; }
        float GetProgress();
    }
}