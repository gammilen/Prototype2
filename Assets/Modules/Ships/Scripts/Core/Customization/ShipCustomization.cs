using System.Collections.Generic;

namespace Ships.Core
{
    public class ShipCustomization : IShipCustomization, IShipCustomizationSetter
    {
        private readonly IReadOnlyDictionary<ShipModulesSlotType, IShipModuleData[]> _modules;
        public IShipData ShipData { get; }

        public event ShipModuleChange ShipModuleChangeEvent;

        public ShipCustomization(IShipData data)
        {
            ShipData = data;
            var modules = new Dictionary<ShipModulesSlotType, IShipModuleData[]>();
            foreach (var slotsCapacity in data.GetModulesSlotsCapacity())
            {
                modules[slotsCapacity.type] = new IShipModuleData[slotsCapacity.capacity];
            }
            _modules = modules;
        }

        bool IShipCustomizationSetter.TrySetModuleInSlot(ShipModulesSlotType slotType, IShipModuleData module, int slotIndex)
        {
            if (_modules.ContainsKey(slotType) && _modules[slotType].Length > slotIndex)
            {
                _modules[slotType][slotIndex] = module;
                ShipModuleChangeEvent?.Invoke(slotType, slotIndex);
                return true;
            }
            return false;
        }

        IReadOnlyList<IShipModuleData> IShipCustomization.GetModules(ShipModulesSlotType slotType)
        {
            return _modules.ContainsKey(slotType) ? _modules[slotType] : new IShipModuleData[] { };
        }

        IEnumerable<(ShipModulesSlotType, IReadOnlyList<IShipModuleData>)> IShipCustomization.GetAllModules()
        {
            foreach (var modules in _modules)
            {
                yield return (modules.Key, modules.Value);
            }
        }
    }
}