using System.Collections.Generic;
using UnityEngine;
using Ships.Core;

namespace Ships.Game
{
	[CreateAssetMenu(fileName = "ModulesStore", menuName = "Data/Modules Store")]
	public class ModulesStore : ScriptableObject, IShipSlotModulesStore
	{
		[SerializeField] private List<WeaponModuleData> _weaponModules;
		[SerializeField] private List<StatModuleData> _statModules;

		[field: SerializeField, Tooltip("Can use one module only once")]
		public bool IsPool { get; private set; }

		IReadOnlyList<IShipModuleData> IShipSlotModulesStore.GetSlotsModules(ShipModulesSlotType slotType)
		{
			return slotType switch
			{
				ShipModulesSlotType.Stat => _statModules,
				ShipModulesSlotType.Weapon => _weaponModules,
				_ => new List<IShipModuleData>()
			};
		}

		IReadOnlyDictionary<ShipModulesSlotType, IReadOnlyList<IShipModuleData>> IShipSlotModulesStore.GetAllModules()
		{
			return new Dictionary<ShipModulesSlotType, IReadOnlyList<IShipModuleData>>
			{
				{ ShipModulesSlotType.Stat, _statModules },
				{ ShipModulesSlotType.Weapon, _weaponModules },
			};
		}
	}
}