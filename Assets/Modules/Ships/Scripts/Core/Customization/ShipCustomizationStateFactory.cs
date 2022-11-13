using System.Collections.Generic;

namespace Ships.Core
{
    public static class ShipCustomizationStateFactory
    {
        public static IShipCustomizationState GetShipCustomizationState(IShipCustomizationSetterSource customization, 
            IShipSlotModulesStore modulesStore)
        {
            var customizationProcessor = new ShipsSlotsCustomizationProcessor(customization, modulesStore);
            return modulesStore.IsPool
                ? new ShipsPoolCustomizationState(customizationProcessor)
                : new ShipsPlainCustomizationState(customizationProcessor);
        }
    }
}