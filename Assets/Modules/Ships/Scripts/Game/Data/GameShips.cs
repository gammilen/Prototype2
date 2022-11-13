using System.Collections.Generic;
using UnityEngine;
using Ships.Core;

namespace Ships.Game
{
    [CreateAssetMenu(fileName = "GameShips", menuName = "Data/Game Ships")]
    public class GameShips : ScriptableObject
    {
        [field: SerializeField] public ShipData ShipA;
        [field: SerializeField] public ShipData ShipB;

        public IReadOnlyList<IShipData> GetShips()
        {
            return new ShipData[] { ShipA, ShipB };
        }
    }
}