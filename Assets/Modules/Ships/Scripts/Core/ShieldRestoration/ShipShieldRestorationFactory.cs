using System.Collections.Generic;
using UnityEngine;

namespace Ships.Core
{

    public class ShipShieldRestorationFactory
    {
        private ShieldRestorationApplier _shieldRestorationApplier;
        
        public ShipShieldRestorationFactory(IShipSettersSource shipSettersSource)
        {
            _shieldRestorationApplier = new ShieldRestorationApplier(shipSettersSource);
        }

        public ShipShieldRestorationHandler Create(IShipState shipState)
        {
            return new ShipShieldRestorationHandler(shipState, _shieldRestorationApplier);
        }
    }
}