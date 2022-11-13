using Ships.Core;
using System;

namespace Ships.Game
{
    public delegate void ShieldActivityChanged(bool isActive);
    public class Ship
    {
        public readonly ShotFactory ShotFactory;
        private readonly ISubscribingMessageBroker<ShotInFlight, IShipState> _shotSubscribeBroker;
        private readonly IShipState _shipState;

        public int WeaponsSlots { get; }
        public event ShieldActivityChanged ShieldActivityEvent;
        public event Action DeadEvent;

        public Ship(IShipState shipState, ShotFactory shotFactory, 
            ISubscribingMessageBroker<ShotInFlight, IShipState> shotSubscribeBroker)
        {
            _shipState = shipState;
            WeaponsSlots = _shipState.Customization.GetModules(ShipModulesSlotType.Weapon).Count;
            ShotFactory = shotFactory;
            _shotSubscribeBroker = shotSubscribeBroker;
            _shipState.ShieldChanged += RefreshShieldActivity;
            _shipState.HPChanged += CheckDeadState;
        }

        public bool HasShield()
        {
            return _shipState.Shield > 0;
        }

        public void AddShotSubscriber(IInfoHandler<ShotInFlight> subscriber)
        {
            _shotSubscribeBroker.AddSubscriber(subscriber, _shipState);
        }

        public void RemoveShotSubscriber(IInfoHandler<ShotInFlight> subscriber)
        {
            _shotSubscribeBroker.RemoveSubscriber(subscriber, _shipState);
        }

        private void RefreshShieldActivity(int oldValue, int newValue)
        {
            if (oldValue <= 0 && newValue > 0)
            {
                ShieldActivityEvent?.Invoke(true);
            }
            else if (newValue <= 0 && oldValue > 0)
            {
                ShieldActivityEvent?.Invoke(false);
            }
        }

        private void CheckDeadState(int oldValue, int newValue)
        {
            if (oldValue > newValue && newValue <= 0)
            {
                DeadEvent?.Invoke();
            }
        }
    }
}