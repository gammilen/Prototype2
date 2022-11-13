using System.Collections.Generic;
using Ships.Core;

namespace Ships.Game
{
    public class ShipState : IShipState, IShipStateSetter
	{
		private int _hp;
		private int _shield;

		public int MaxShield { get; }
		public float ShieldPointRestoreTime { get; }
		public IShipCustomization Customization { get; }
		public IReadOnlyList<WeaponState> Weapons { get; }
		
		public int HP 
		{
			get => _hp;
			set
            {
				if (value == _hp) return;
				var old = _hp;
				_hp = value;
				HPChanged(old, _hp);
            }
		}

		public int Shield
        {
			get => _shield;
			set
            {
				if (value == _shield) return;
				var old = _shield;
				_shield = value;
				ShieldChanged(old, _shield);
            }
        }

		public event ValueChange<int> HPChanged;
		public event ValueChange<int> ShieldChanged;

		public ShipState(IShipCustomization customization, IReadOnlyList<WeaponState> weapons,
			float shieldPointRestoreTime, int hp, int shield)
        {
			Customization = customization;
			ShieldPointRestoreTime = shieldPointRestoreTime;
			Weapons = weapons;
			_hp = hp;
			_shield = MaxShield = shield;
        }
	}
}