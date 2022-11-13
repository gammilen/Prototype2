using UnityEngine;

namespace Ships.Game
{
	public class BattleShipsArranger : MonoBehaviour
    {
        [SerializeField] private BattleController _battleController;

        private void Awake()
        {
            _battleController.AddStartBattleListener(ArrangeShips);
        }

        private void ArrangeShips()
        {
            var halfDist = 0.5f * _battleController.GetRealDistanceBetweenShips();
            var factory = _battleController.ShipFactory;
            factory.Create(_battleController.ShipStatesSource.ShipStates[0], 
                new Vector3(-halfDist, 0, 0), Vector3.right);
            factory.Create(_battleController.ShipStatesSource.ShipStates[1], 
                new Vector3(halfDist, 0, 0), Vector3.left);
        }
    }
}