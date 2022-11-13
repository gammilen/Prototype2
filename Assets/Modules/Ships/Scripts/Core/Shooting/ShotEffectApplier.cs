using System;

namespace Ships.Core
{
    public class ShotEffectApplier
    {
        private readonly IShipSettersSource _shipSettersSource;
        public event Action<IShipState> ShotApplied;

        public ShotEffectApplier(IShipSettersSource shipSettersSource)
        {
            _shipSettersSource = shipSettersSource;
        }

        public void Apply(ShotInFlight shot)
        {
            if (shot.Target.HP <= 0) return;
            var target = _shipSettersSource.GetShipStateSetter(shot.Target);
            if (shot.Target.Shield >= shot.Shot.Damage)
            {
                target.Shield = shot.Target.Shield - shot.Shot.Damage;
            }
            else
            {
                var damage = shot.Shot.Damage - shot.Target.Shield;
                target.Shield = 0;
                target.HP = Math.Max(shot.Target.HP - damage, 0);
            }
            ShotApplied?.Invoke(shot.Target);
        }
    }
}