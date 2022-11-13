namespace Ships.Core
{
    public class ShotInFlight
    {
        public readonly Shot Shot;
        public readonly IShipState Target;
        public readonly IShipState Source;
        public readonly ITimeProgress FlightProgress;

        public ShotInFlight(Shot shot, IShipState target, IShipState source, ITimeProgress progress)
        {
            Shot = shot;
            Target = target;
            Source = source;
            FlightProgress = progress;
        }
    }
}