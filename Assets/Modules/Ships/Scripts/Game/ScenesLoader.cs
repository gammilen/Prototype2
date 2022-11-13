using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ships.Game
{
    public static class ScenesLoader
    {
        private const string Main = "ShipsMain";
        private const string Battle = "ShipsBattle";
        private const string Customization = "ShipsCustomization";

        public static void Restart()
        {
            SceneManager.LoadScene(Main);
        }

        public static void LoadCustomization()
        {
            SceneManager.LoadScene(Customization, LoadSceneMode.Additive);
        }

        public static void LoadBattle()
        {
            var loadOp = SceneManager.LoadSceneAsync(Battle, LoadSceneMode.Additive);
            loadOp.completed += UnloadCustomization;

            void UnloadCustomization(AsyncOperation op)
            {
                if (SceneManager.GetSceneByName(Customization).isLoaded)
                {
                    SceneManager.UnloadSceneAsync(Customization);
                }
            }
        }
    }
}