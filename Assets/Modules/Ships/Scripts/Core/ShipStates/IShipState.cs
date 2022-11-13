using System;
using System.Collections.Generic;

namespace Ships.Core
{
	public delegate void ValueChange<T>(T oldValue, T newValue);

	public interface IShipState
    {
		int MaxShield { get; }
		float ShieldPointRestoreTime { get; }
		IShipCustomization Customization { get; }
		IReadOnlyList<WeaponState> Weapons { get; }
		int HP { get; }
		int Shield { get; }
		
		event ValueChange<int> HPChanged;
		event ValueChange<int> ShieldChanged;
	}	
}