using UnityEngine;

namespace Ships.Core
{
	public class WeaponState
	{
		public readonly int Damage;
		public readonly float CooldownTime;
		public readonly float Speed;
		public readonly int Slot;

		public WeaponState(int damage, float cooldownTime, float speed, int slot)
        {
			Damage = damage;
			CooldownTime = cooldownTime;
			Speed = speed;
			Slot = slot;
		}
	}
}