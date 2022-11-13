using System;
using Ships.Core;
using UnityEngine;

namespace Ships.Game
{
    public class BattleController : MonoBehaviour
    {
        [SerializeField] private ShipsArrangementConfig _shipsArrangementConfig;
        [SerializeField] private ShipsConfiguration _shipsConfiguration;
        [SerializeField] private BattleShips _ships;
        private BattleLogic _battleLogic;

        public ShipFactory ShipFactory { get; private set; }
        public IShipStatesSource ShipStatesSource => _ships;
        private Action _onBattleStart;

        private void Awake()
        {
            var durationResolver = new DurationResolver(_shipsArrangementConfig);
            var attackDirResolver = new AttackDestinationResolver(_ships);
            var shotMessageBroker = new ShotInFlightMessageBroker();
            var shipShootingFactory = new ShipShootingFactory(durationResolver, attackDirResolver, 
                _ships, shotMessageBroker);
            var shieldRestorationFactory = new ShipShieldRestorationFactory(_ships);

            var shotFactory = new ShotFactory(_shipsConfiguration);
            ShipFactory = new ShipFactory(_shipsConfiguration, shotFactory, shotMessageBroker);

            _battleLogic = new BattleLogic(_ships, shipShootingFactory, shieldRestorationFactory);
        }

        private void OnDisable()
        {
            _battleLogic.StopAll();
        }

        public void StartBattle()
        {
            _onBattleStart?.Invoke();
            _battleLogic.Start();
        }

        public void AddFinishBattleListener(Action listener)
        {
            _battleLogic.BattleFinishEvent += listener;
        }

        public void RemoveFinishBattleListener(Action listener)
        {
            _battleLogic.BattleFinishEvent -= listener;
        }

        public void AddStartBattleListener(Action listener)
        {
            _onBattleStart += listener;
        }

        public void RemoveStartBattleListener(Action listener)
        {
            _onBattleStart -= listener;
        }

        public void Restart()
        {
            ScenesLoader.Restart();
        }

        public float GetRealDistanceBetweenShips()
        {
            return _shipsConfiguration.ShipRadius
                + _shipsArrangementConfig.BaseDistance 
                * _shipsConfiguration.RealDistanceMultiplier;
        }
    }
}