using System.Collections.Generic;
using UnityEngine;
using Ships.Core;

namespace Ships.Game.UI
{
    public class BattleShipsStatsView : MonoBehaviour
    {
        [SerializeField] private List<ShipStatsElement> _ships;
        [SerializeField] private BattleController _battleController;

        private void Start()
        {
            var count = _battleController.ShipStatesSource.ShipStates.Count;
            for (int i = 0; i < _ships.Count; i++)
            {
                if (i >= count)
                {
                    _ships[i].gameObject.SetActive(false);
                    continue;
                }
                InitShipElement(_battleController.ShipStatesSource.ShipStates[i], _ships[i]);
            }
        }

        private void InitShipElement(IShipState shipState, ShipStatsElement elem)
        {
            shipState.HPChanged += (o, n) => elem.RefreshHP(n);
            shipState.ShieldChanged += (o, n) => elem.RefreshShield(n);
            elem.Setup(shipState.HP, shipState.Shield);
        }
    }
}