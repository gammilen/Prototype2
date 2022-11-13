using System.Collections.Generic;
using UnityEngine;
using Ships.Core;

namespace Ships.Game
{
    [CreateAssetMenu(fileName = "ShipsCustomization", menuName = "Data/Ships Customization")]
    public class ShipsCustomization : ScriptableObject, IShipCustomizationSource, IShipCustomizationSetterSource
    {
        public IReadOnlyList<IShipCustomization> Ships => _ships;
        private IReadOnlyList<ShipCustomization> _ships;

        public void Init(IReadOnlyList<IShipData> shipsData)
        {
            var shipsCustomization = new List<ShipCustomization>();
            foreach (var shipData in shipsData)
            {
                shipsCustomization.Add(new ShipCustomization(shipData));
            }
            _ships = shipsCustomization;
        }

        IShipCustomizationSetter IShipCustomizationSetterSource.GetShip(int index)
        {
            return _ships[index];
        }
    }
}