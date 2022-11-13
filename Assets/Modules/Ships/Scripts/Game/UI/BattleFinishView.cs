using UnityEngine;

namespace Ships.Game.UI
{
    public class BattleFinishView : MonoBehaviour
    {
        [SerializeField] private BattleController _battleController;
        [SerializeField] private GameObject _finishIndicator;

        private void Start()
        {
            _finishIndicator.SetActive(false);
            _battleController.AddFinishBattleListener(ShowFinishIndicator);
        }

        private void ShowFinishIndicator()
        {
            _finishIndicator.SetActive(true);
        }
    }
}