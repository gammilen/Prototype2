using System.Collections.Generic;

namespace Ships.Core
{
    public delegate void ShipModuleChange(ShipModulesSlotType slotType, int slot);

    public interface IShipCustomization
    {
        IShipData ShipData { get; }
        IReadOnlyList<IShipModuleData> GetModules(ShipModulesSlotType slotType);
        IEnumerable<(ShipModulesSlotType type, IReadOnlyList<IShipModuleData> modules)> GetAllModules();
        event ShipModuleChange ShipModuleChangeEvent;
    }
}