using System.Collections.Generic;

namespace Ships.Core
{
    public class ShipsSlotsCustomizationProcessor
    {
        protected readonly IShipSlotModulesStore _modulesStore;
        protected readonly IShipCustomizationSetterSource _customization;

        public ShipsSlotsCustomizationProcessor(IShipCustomizationSetterSource customization, IShipSlotModulesStore modulesStore)
        {
            _modulesStore = modulesStore;
            _customization = customization;
        }

        public IEnumerable<(ShipModulesSlotType type, int count)> GetStoreModulesInfo()
        {
            foreach (var modules in _modulesStore.GetAllModules())
            {
                yield return (modules.Key, modules.Value.Count);
            }
        }

        public void SetShipSlotCustomization(ShipModulesSlotType slotType, int moduleIndexInStore, 
            int shipIndex, int slotIndex)
        {
            var shipCustomization = _customization.GetShip(shipIndex);
            shipCustomization.TrySetModuleInSlot(slotType, 
                _modulesStore.GetSlotsModules(slotType)[moduleIndexInStore], slotIndex);
        }

        public void ResetShipSlotCustomization(ShipModulesSlotType slotType, int shipIndex, int slotIndex)
        {
            var shipCustomization = _customization.GetShip(shipIndex);
            shipCustomization.TrySetModuleInSlot(slotType, null, slotIndex);
        }
    }
}