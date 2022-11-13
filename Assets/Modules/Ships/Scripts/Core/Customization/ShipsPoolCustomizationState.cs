using System.Collections.Generic;

namespace Ships.Core
{
    public class ShipsPoolCustomizationState : IShipCustomizationState
    {
        private readonly ShipsSlotsCustomizationProcessor _customizationSetter;
        private readonly IReadOnlyDictionary<ShipModulesSlotType, List<ModuleInShipSlot>> _modulesInShips;

        public ShipsPoolCustomizationState(ShipsSlotsCustomizationProcessor customizationSetter)
        {
            _customizationSetter = customizationSetter;
            var modulesInShips = new Dictionary<ShipModulesSlotType, List<ModuleInShipSlot>>();
            foreach (var modulesInfo in _customizationSetter.GetStoreModulesInfo())
            {
                modulesInShips.Add(modulesInfo.type, CreateModulesSlots(modulesInfo.count));
            }
            _modulesInShips = modulesInShips;

            List<ModuleInShipSlot> CreateModulesSlots(int count)
            {
                var modulesSlots = new List<ModuleInShipSlot>();
                for (int i = 0; i < count; i++)
                {
                    var moduleSlot = new ModuleInShipSlot() { ShipIndex = -1, SlotIndex = -1 };
                    modulesSlots.Add(moduleSlot);
                }
                return modulesSlots;
            }
        }

        public void SetModuleInSlot(ShipModulesSlotType slotType, int shipIndex, int slotIndex, int moduleIndexInStore)
        {
            var moduleData = _modulesInShips[slotType][moduleIndexInStore];
            if (moduleData.IsSet)
            {
                ResetShipSlotCustomization(slotType, moduleData, moduleIndexInStore);
            }
            _customizationSetter.SetShipSlotCustomization(slotType, moduleIndexInStore, shipIndex, slotIndex);
            SetModuleInSlotValues(slotType, moduleIndexInStore, shipIndex, slotIndex);
        }

        public void UnsetModuleInSlot(ShipModulesSlotType slotType, int shipIndex, int slotIndex)
        {
            var moduleData = new ModuleInShipSlot() { ShipIndex = shipIndex, SlotIndex = slotIndex };
            for (int i = 0; i < _modulesInShips[slotType].Count; i++)
            {
                ModuleInShipSlot mData = _modulesInShips[slotType][i];
                if (_modulesInShips[slotType][i].Equals(moduleData))
                {
                    ResetShipSlotCustomization(slotType, mData, i);
                    return;
                }
            }
        }

        private void SetModuleInSlotValues(ShipModulesSlotType slotType, int moduleIndexInStore, int shipIndex, int slotIndex)
        {
            var moduleData = _modulesInShips[slotType][moduleIndexInStore];
            moduleData.ShipIndex = shipIndex;
            moduleData.SlotIndex = slotIndex;
            _modulesInShips[slotType][moduleIndexInStore] = moduleData;
        }

        private void ResetShipSlotCustomization(ShipModulesSlotType slotType, ModuleInShipSlot moduleData, int moduleIndexInStore)
        {
            _customizationSetter.ResetShipSlotCustomization(slotType, moduleData.ShipIndex, moduleData.SlotIndex);
            SetModuleInSlotValues(slotType, moduleIndexInStore, -1, -1);
        }
    }
}