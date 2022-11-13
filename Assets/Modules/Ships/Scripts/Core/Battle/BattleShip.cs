using System.Collections;
using UnityEngine;

namespace Ships.Core
{
    public class BattleShip
    {
        private readonly IShipState _ship;
        private readonly ShipShootingHandler _shootingHandler;
        private readonly ShipShieldRestorationHandler _shieldRestoration;

        public BattleShip(IShipState ship, ShipShootingHandler shootingHandler, ShipShieldRestorationHandler shieldRestoration)
        {
            _ship = ship;
            _shootingHandler = shootingHandler;
            _shieldRestoration = shieldRestoration;
        }

        public void Start()
        {
            _shieldRestoration.StartRestoration();
            _shootingHandler.StartShooting();
        }

        public void Stop()
        {
            _shootingHandler.StopShooting();
            _shieldRestoration.StopRestoration();
        }

    }
}