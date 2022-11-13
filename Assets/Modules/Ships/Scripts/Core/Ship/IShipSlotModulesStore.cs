using System.Collections.Generic;

namespace Ships.Core
{
    public interface IShipSlotModulesStore
    {
        bool IsPool { get; }
        IReadOnlyList<IShipModuleData> GetSlotsModules(ShipModulesSlotType slotType);
        IReadOnlyDictionary<ShipModulesSlotType, IReadOnlyList<IShipModuleData>> GetAllModules();
    }
}