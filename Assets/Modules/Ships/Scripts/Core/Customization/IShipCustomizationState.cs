namespace Ships.Core
{
    public interface IShipCustomizationState
    {
        void SetModuleInSlot(ShipModulesSlotType slotType, int shipIndex, int slotIndex, int moduleIndexInStore);
        void UnsetModuleInSlot(ShipModulesSlotType slotType, int shipIndex, int slotIndex);
    }
}