using System.Collections.Generic;

namespace Ships.Core
{
    public interface IShipCustomizationSetterSource
    {
        IShipCustomizationSetter GetShip(int index);
    }

    public interface IShipCustomizationSource
    {
        IReadOnlyList<IShipCustomization> Ships { get; }
    }
}