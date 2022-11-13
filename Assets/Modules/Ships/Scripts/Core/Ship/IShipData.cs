using System.Collections.Generic;

namespace Ships.Core
{
    public interface IShipData
    {
        int HP { get; }
        int Shield { get; }
        float ShieldRestoreSpeed { get; }
        IEnumerable<(ShipModulesSlotType type, uint capacity)> GetModulesSlotsCapacity();
    }
}