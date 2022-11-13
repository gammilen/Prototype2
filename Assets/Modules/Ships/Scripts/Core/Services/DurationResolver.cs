namespace Ships.Core
{
    public class DurationResolver
    {
        private readonly ShipsArrangementConfig _shipsArrangementConfig;

        public DurationResolver(ShipsArrangementConfig shipsArrangementConfig)
        {
            _shipsArrangementConfig = shipsArrangementConfig;
        }

        public float Resolve(float speed)
        {
            return _shipsArrangementConfig.BaseDistance / speed;
        }
    }
}