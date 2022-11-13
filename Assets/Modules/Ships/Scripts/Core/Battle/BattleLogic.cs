using System;
using System.Collections.Generic;

namespace Ships.Core
{
    public class BattleLogic
    {
        public readonly List<BattleShip> Ships;
        public event Action BattleFinishEvent;

        public BattleLogic(IShipStatesSource ships, ShipShootingFactory shipShootingFactory, 
            ShipShieldRestorationFactory shieldRestorationFactory)
        {
            Ships = new List<BattleShip>();

            foreach (var shipState in ships.ShipStates)
            {
                Ships.Add(new BattleShip(shipState, shipShootingFactory.Create(shipState), 
                    shieldRestorationFactory.Create(shipState)));
                shipState.HPChanged += CheckKill;
            }
        }

        public void Start()
        {
            foreach (var ship in Ships)
            {
                ship.Start();
            }
        }

        public void StopAll()
        {
            foreach (var ship in Ships)
            {
                ship.Stop();
            }
        }

        private void CheckKill(int oldValue, int newValue)
        {
            if (newValue <= 0)
            {
                StopAll();
                BattleFinishEvent?.Invoke();
            }
        }
    }
}