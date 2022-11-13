using UnityEngine;

namespace Ships.Game
{
	public class BattleStarter : MonoBehaviour
    {
        [SerializeField] private BattleController _battleController;

        private void Start()
        {
            _battleController.StartBattle();
        }
    }
}