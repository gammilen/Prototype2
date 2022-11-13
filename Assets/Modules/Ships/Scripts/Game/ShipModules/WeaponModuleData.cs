using System;
using UnityEngine;
using Ships.Core;

namespace Ships.Game
{
    [CreateAssetMenu(fileName = "WeaponModule", menuName = "Data/Weapon Module")]
	public class WeaponModuleData : ScriptableObject, IWeaponModuleData
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField, Tooltip("In seconds")] 
        public float CooldownTime { get; private set; }
        public float Speed => 1f / CooldownTime;

#if UNITY_EDITOR
        private void OnValidate()
        {
            Damage = Math.Max(Damage, 1);
            CooldownTime = Math.Max(CooldownTime, 0);
        }
#endif
    }
}