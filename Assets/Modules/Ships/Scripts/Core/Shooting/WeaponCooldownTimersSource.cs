using System.Collections.Generic;

namespace Ships.Core
{

    public class WeaponCooldownTimersSource
    {
        public readonly IReadOnlyDictionary<WeaponState, Timer> Timers;

        public WeaponCooldownTimersSource(IReadOnlyList<WeaponState> weapons)
        {
            var timers = new Dictionary<WeaponState, Timer>();
            foreach (var weapon in weapons)
            {
                var timer = new Timer(weapon.CooldownTime);
                
                timers.Add(weapon, timer);
            }
            Timers = timers;
        }

        public Timer GetTimer(WeaponState weapon)
        {
            return Timers[weapon];
        }

        public void StopTimers()
        {
            foreach (var timer in Timers.Values)
            {
                timer.Stop();
            }
        }
    }
}