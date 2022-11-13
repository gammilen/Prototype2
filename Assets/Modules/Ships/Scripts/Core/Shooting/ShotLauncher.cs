namespace Ships.Core
{
    public class ShotLauncher
    {
        private readonly AttackDestinationResolver _destinationResolver;
        private readonly ShotEffectApplier _shotsApplier;
        private readonly ShotsTimersSource _shotsTimersSource;
        private readonly IPublishingMessageBroker<ShotInFlight> _shotPublishBroker;

        public ShotLauncher(AttackDestinationResolver destinationResolver, ShotEffectApplier shotsApplier,
            ShotsTimersSource shotsTimersSource, IPublishingMessageBroker<ShotInFlight> shotPublishBroker)
        {
            _destinationResolver = destinationResolver;
            _shotsApplier = shotsApplier;
            _shotsTimersSource = shotsTimersSource;
            _shotPublishBroker = shotPublishBroker;
        }

        public void Launch(Shot shot, IShipState ship)
        {
            var target = _destinationResolver.Resolve(ship);
            var timer = _shotsTimersSource.GetLifeTimer(shot);
            var shotInFlight = new ShotInFlight(shot, target, ship, timer);
            timer.OnExpired += () => _shotsApplier.Apply(shotInFlight);
            timer.Restart();
            _shotPublishBroker.Publish(shotInFlight);
        }

        public void StopShotsFlight()
        {
            _shotsTimersSource.StopAllTimers();
        }
    }
}