using System.Collections.Generic;

namespace Ships.Core
{
    public class WeaponShotsSource
    {
        private readonly IReadOnlyDictionary<WeaponState, Shot> _shots;

        public WeaponShotsSource(IReadOnlyList<WeaponState> weapons)
        {
            var shots = new Dictionary<WeaponState, Shot>();
            foreach (var weapon in weapons)
            {
                shots.Add(weapon, new Shot(weapon, weapon.Damage, weapon.Speed));
            }
            _shots = shots;
        }

        public Shot GetShot(WeaponState weapon)
        {
            return _shots.ContainsKey(weapon) ? _shots[weapon] : null;
        }
    }
}