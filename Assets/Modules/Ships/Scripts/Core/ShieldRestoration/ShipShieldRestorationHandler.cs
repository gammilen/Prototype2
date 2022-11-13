namespace Ships.Core
{
    public class ShipShieldRestorationHandler
    {
        private readonly ShieldRestorationApplier _restorationApplier;
        private readonly IShipState _ship;
        private readonly Timer _restoreTimer;
        private bool _canRestore;
        private bool _isRestoring;

        public ShipShieldRestorationHandler(IShipState ship, ShieldRestorationApplier restorationApplier)
        {
            _restorationApplier = restorationApplier;
            _ship = ship;
            _ship.ShieldChanged += UpdateRestorationState;
            _restoreTimer = new Timer(_ship.ShieldPointRestoreTime);
            _restoreTimer.OnExpired += RestoreShield;
        }

        public void StartRestoration()
        {
            _canRestore = true;
            UpdateRestorationState();
        }

        public void StopRestoration()
        {
            _canRestore = false;
            _isRestoring = false;
            _restoreTimer.Stop();
        }

        private void UpdateRestorationState(int oldValue, int newValue)
        {
            UpdateRestorationState();
        }

        private void UpdateRestorationState()
        {
            if (_isRestoring && (!_canRestore || _ship.Shield == _ship.MaxShield))
            {
                _isRestoring = false;
            }
            else if (_canRestore && !_isRestoring && _ship.Shield < _ship.MaxShield)
            {
                _isRestoring = true;
                _restoreTimer.Restart();
            }
        }

        private void RestoreShield()
        {
            if (!_isRestoring)
            {
                return;
            }
            _restorationApplier.Apply(_ship);
            _restoreTimer.Restart();
        }
    }
}