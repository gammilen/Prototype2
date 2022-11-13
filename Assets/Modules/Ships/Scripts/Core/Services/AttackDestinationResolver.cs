using System;

namespace Ships.Core
{
    
    public class AttackDestinationResolver
    {
        private readonly IShipStatesSource _ships;

        public AttackDestinationResolver(IShipStatesSource ships)
        {
            _ships = ships;
        }

        public IShipState Resolve(IShipState state)
        {
            if (_ships.ShipStates[0] == state)
            {
                return _ships.ShipStates[1];
            }
            if (_ships.ShipStates[1] == state)
            {
                return _ships.ShipStates[0];
            }
            throw new NotImplementedException();
        }
    }
}