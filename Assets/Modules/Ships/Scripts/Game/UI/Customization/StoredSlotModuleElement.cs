using System;
using UnityEngine;
using UnityEngine.UI;
using Ships.Core;

namespace Ships.Game.UI
{
	public readonly struct ShipModuleSlotInfo
    {
		public readonly ShipModulesSlotType SlotType;
		public readonly int ShipIndex;
		public readonly int SlotIndex;

		public ShipModuleSlotInfo(ShipModulesSlotType slotType, int shipIndex, int slotIndex)
        {
			SlotType = slotType;
			ShipIndex = shipIndex;
			SlotIndex = slotIndex;
        }
	}

	public struct StoredSlotModuleInfo
    {
		public readonly ShipModulesSlotType SlotType;
		public readonly IShipModuleData ShipModule;
		public readonly int InStoreIndex;

		public StoredSlotModuleInfo(ShipModulesSlotType slotType, IShipModuleData shipModule, int inStoreIndex)
        {
			SlotType = slotType;
			ShipModule = shipModule;
			InStoreIndex = inStoreIndex;
        }
	}

	public class StoredSlotModuleElement : MonoBehaviour
	{
		[SerializeField] private Button _btn;
		[SerializeField] private Text _name;
		public StoredSlotModuleInfo ModuleInfo { get; private set; }

		public event Action<StoredSlotModuleInfo> ClickEvent;

        private void Awake()
        {
			_btn.onClick.AddListener(RaiseEvent);
        }

        public void Init(StoredSlotModuleInfo moduleInfo)
		{
			ModuleInfo = moduleInfo;
			_name.text = moduleInfo.ShipModule.Name;
		}

		private void RaiseEvent()
        {
			ClickEvent?.Invoke(ModuleInfo);
		}
	}
}