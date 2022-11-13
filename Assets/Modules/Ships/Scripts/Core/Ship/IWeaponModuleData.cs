using System.Collections.Generic;

namespace Ships.Core
{
    public interface IWeaponModuleData : IShipModuleData
    {
        int Damage { get; }
        public float CooldownTime { get; }
        float Speed { get; }
    }
}