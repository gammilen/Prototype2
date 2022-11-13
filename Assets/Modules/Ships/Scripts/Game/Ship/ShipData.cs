using System;
using System.Collections.Generic;
using UnityEngine;
using Ships.Core;

namespace Ships.Game
{
	[CreateAssetMenu(fileName ="Ship", menuName = "Data/Ship")]
	public class ShipData : ScriptableObject, IShipData
    {
        [SerializeField] private uint _weaponSlotsCount;
        [SerializeField] private uint _statsModulesSlotsCount;
        [field: SerializeField] public int HP { get; private set; }
        [field: SerializeField] public int Shield { get; private set; }
        [field: SerializeField, Tooltip("Points per second")] 
        public float ShieldRestoreSpeed { get; private set; }

#if UNITY_EDITOR
        private void OnValidate()
        {
            HP = Math.Max(HP, 1);
            Shield = Math.Max(Shield, 0);
            ShieldRestoreSpeed = Math.Max(ShieldRestoreSpeed, 0);
        }
#endif

        public IEnumerable<(ShipModulesSlotType type, uint capacity)> GetModulesSlotsCapacity()
        {
            yield return (ShipModulesSlotType.Stat, _statsModulesSlotsCount);
            yield return (ShipModulesSlotType.Weapon, _weaponSlotsCount);
        }
    }
}