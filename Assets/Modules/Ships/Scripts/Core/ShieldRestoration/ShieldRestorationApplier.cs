namespace Ships.Core
{
    public class ShieldRestorationApplier
    {
        private readonly IShipSettersSource _shipSettersSource;

        public ShieldRestorationApplier(IShipSettersSource shipSettersSource)
        {
            _shipSettersSource = shipSettersSource;
        }

        public void Apply(IShipState ship)
        {
            var stateSetter = _shipSettersSource.GetShipStateSetter(ship);
            if (ship.Shield < ship.MaxShield)
            {
                stateSetter.Shield = ship.Shield + 1;
            }
        }
    }
}