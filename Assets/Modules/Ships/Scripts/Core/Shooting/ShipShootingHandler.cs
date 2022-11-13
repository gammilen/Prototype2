namespace Ships.Core
{
    public class ShipShootingHandler
    {
        private readonly IShipState _ship;
        private readonly ShotLauncher _launcher;
        private readonly WeaponShotsSource _shotsSource;
        private readonly WeaponCooldownTimersSource _cooldownTimersSource;

        private bool _isShooting;

        public ShipShootingHandler(IShipState ship, ShotLauncher launcher, WeaponShotsSource shotsSource)
        {
            _ship = ship;
            _launcher = launcher;
            _shotsSource = shotsSource;
            _cooldownTimersSource = new WeaponCooldownTimersSource(ship.Weapons);
            foreach (var timer in _cooldownTimersSource.Timers)
            {
                timer.Value.OnExpired += () => MakeShot(timer.Key);
            }
        }

        public void StartShooting()
        {
            _isShooting = true;
            foreach (var weapon in _ship.Weapons)
            {
                MakeShot(weapon);
            }
        }

        public void StopShooting()
        {
            _isShooting = false;
            _cooldownTimersSource.StopTimers();
            _launcher.StopShotsFlight();
        }

        private void MakeShot(WeaponState weapon)
        {
            if (!_isShooting) return;
            _cooldownTimersSource.GetTimer(weapon).Restart();
            _launcher.Launch(_shotsSource.GetShot(weapon), _ship);
        }
    }
}