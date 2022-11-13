using System.Collections.Generic;
using UnityEngine;
using Ships.Core;

namespace Ships.Game
{
    [CreateAssetMenu(fileName ="BattleShips", menuName ="Data/Battle Ships")]
    public class BattleShips : ScriptableObject, IShipStatesSource, IShipSettersSource
    {
        public IReadOnlyList<IShipState> ShipStates => _shipStates;
        public IReadOnlyList<ShipState> _shipStates;

        public void Init(IReadOnlyList<ShipState> shipsData)
        {
            _shipStates = shipsData;
        }

        IShipStateSetter IShipSettersSource.GetShipStateSetter(IShipState shipState)
        {
            foreach (var state in _shipStates)
            {
                if (state == shipState)
                {
                    return state;
                }
            }
            throw new System.ArgumentException("Can't find setter for ship state");
        }
    }
}