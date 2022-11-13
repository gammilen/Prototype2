using System.Collections.Generic;

namespace Ships.Core
{
    public interface IStatModuleData : IShipModuleData
    {
        Stat Stat { get; }
        Mod Modification { get; }
        float ModificationValue { get; }
    }
}