using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Ships.Game.UI
{
    public class ShipStatsElement : MonoBehaviour
    {
        [SerializeField] private Text _hpValue;
        [SerializeField] private Text _shieldValue;

        public void RefreshHP(int hp)
        {
            _hpValue.text = hp.ToString();
        }

        public void RefreshShield(int shield)
        {
            _shieldValue.text = shield.ToString();
        }

        public void Setup(int hp, int shield)
        {
            RefreshHP(hp);
            RefreshShield(shield);
            SetActive(true);
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}