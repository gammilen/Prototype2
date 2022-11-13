namespace Ships.Core
{
    public class ShipsPlainCustomizationState : IShipCustomizationState
    {
        private readonly ShipsSlotsCustomizationProcessor _customizationSetter;

        public ShipsPlainCustomizationState(ShipsSlotsCustomizationProcessor customizationSetter)
        {
            _customizationSetter = customizationSetter;
        }

        public void SetModuleInSlot(ShipModulesSlotType slotType, int shipIndex, int slotIndex, int moduleIndexInStore)
        {
            _customizationSetter.SetShipSlotCustomization(slotType, moduleIndexInStore, shipIndex, slotIndex);
        }

        public void UnsetModuleInSlot(ShipModulesSlotType slotType, int shipIndex, int slotIndex)
        {
            _customizationSetter.ResetShipSlotCustomization(slotType, shipIndex, slotIndex);
        }
    }
}