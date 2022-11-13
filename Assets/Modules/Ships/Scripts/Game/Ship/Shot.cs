using Ships.Core;

namespace Ships.Game
{
    public class Shot
    {
        public readonly ShotInFlight ShotData;
        public readonly float Speed;

        public Shot(ShotInFlight shotData, float realSpeed)
        {
            ShotData = shotData;
            Speed = realSpeed;
        }
    }
}