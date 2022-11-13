using System.Collections.Generic;
using UnityEngine;

namespace Ships.Core
{
    public class ShipShootingFactory
    {
        private readonly ShotLauncher _shotsLauncher;

        public ShipShootingFactory(DurationResolver durationResolver,
            AttackDestinationResolver attackDestinationResolver, IShipSettersSource shipSettersSource,
            IPublishingMessageBroker<ShotInFlight> shotPublishBroker)
        {
            _shotsLauncher = new ShotLauncher(
                attackDestinationResolver, 
                new ShotEffectApplier(shipSettersSource),
                new ShotsTimersSource(durationResolver), 
                shotPublishBroker);
        }

        public ShipShootingHandler Create(IShipState shipState)
        {
            return new ShipShootingHandler(shipState, _shotsLauncher, new WeaponShotsSource(shipState.Weapons));
        }
    }
}