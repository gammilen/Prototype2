using System.Collections.Generic;

namespace Ships.Core
{
    public class ShotsTimersSource
    {
        private readonly DurationResolver _durationResolver;
        private List<Timer> _shotsTimers = new();

        public ShotsTimersSource(DurationResolver durationResolver)
        {
            _durationResolver = durationResolver;
        }

        public Timer GetLifeTimer(Shot shot)
        {
            var timer = new Timer(_durationResolver.Resolve(shot.Speed));
            _shotsTimers.Add(timer);
            timer.OnExpired += () => _shotsTimers.Remove(timer);
            return timer;
        }

        public void StopAllTimers()
        {
            foreach (var timer in _shotsTimers)
            {
                timer.Stop();
            }
        }
    }
}