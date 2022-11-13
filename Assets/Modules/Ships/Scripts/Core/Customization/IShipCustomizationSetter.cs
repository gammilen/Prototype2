namespace Ships.Core
{
    public interface IShipCustomizationSetter
    {
        bool TrySetModuleInSlot(ShipModulesSlotType slotType, IShipModuleData module, int slotIndex);
    }
}