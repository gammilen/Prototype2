using System.Collections.Generic;

namespace Ships.Core
{
    public interface IShipStatesSource
    {
        IReadOnlyList<IShipState> ShipStates { get; }
    }
}