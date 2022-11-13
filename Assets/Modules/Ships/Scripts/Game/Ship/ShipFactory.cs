using UnityEditor;
using UnityEngine;
using Ships.Core;

namespace Ships.Game
{
    public class ShipFactory
    {
        private readonly ShipsConfiguration _shipsConfiguration;
        private readonly ShotFactory _shotFactory;
        private readonly ISubscribingMessageBroker<ShotInFlight, IShipState> _shotSubscribeBroker;

        public ShipFactory(ShipsConfiguration shipsConfiguration, ShotFactory shotFactory,
            ISubscribingMessageBroker<ShotInFlight, IShipState> shotSubscribeBroker)
        {
            _shotFactory = shotFactory;
            _shipsConfiguration = shipsConfiguration;
            _shotSubscribeBroker = shotSubscribeBroker;
        }

        public Ship Create(IShipState shipState, Vector3 positionsOffset, Vector3 forward)
        {
            var ship = new Ship(shipState, _shotFactory, _shotSubscribeBroker);
            var shipView = Object.Instantiate(_shipsConfiguration.ShipPrefab);
            shipView.Init(ship, positionsOffset, forward);
            return ship;
        }

    }
}