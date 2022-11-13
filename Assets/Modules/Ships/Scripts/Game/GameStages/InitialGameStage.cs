using UnityEngine;
using UnityEngine.SceneManagement;
using Ships.Core;

namespace Ships.Game
{
    public class InitialGameStage : MonoBehaviour
    {
        [SerializeField] private GameShips _ships;
        [SerializeField] private ShipsCustomization _cutomization;

        private void Awake()
        {
            _cutomization.Init(_ships.GetShips());
            ScenesLoader.LoadCustomization();
        }
    }
}