using System.Collections.Generic;
using Ships.Core;
using UnityEngine;

namespace Ships.Game
{
    public class ShipView : MonoBehaviour, IInfoHandler<ShotInFlight>
    {
        [SerializeField] private GameObject _shield;
        [SerializeField] private Vector3 _weaponsRootOffset;
        [SerializeField] private float _weaponsSpace;
        private Ship _ship;
        private IReadOnlyList<Vector3> _weaponShootPositions;

        private void OnDisable()
        {
            _ship.RemoveShotSubscriber(this);
            _ship.ShieldActivityEvent -= UpdateShieldState;
            _ship.DeadEvent -= DestroyShip;
        }

        public void Init(Ship ship, Vector3 positionOffset, Vector3 forward)
        {
            _ship = ship;
            _ship.ShieldActivityEvent += UpdateShieldState;
            _ship.DeadEvent += DestroyShip;
            transform.position = positionOffset;
            transform.forward = forward;
            if (ship.WeaponsSlots > 0)
            {
                InitWeapons();
                _ship.AddShotSubscriber(this);
            }
            UpdateShieldState(_ship.HasShield());
        }

        void IInfoHandler<ShotInFlight>.Handle(ShotInFlight info)
        {
            TryShoot(info);
        }

        private void TryShoot(ShotInFlight info)
        {
            var slot = info.Shot.Weapon.Slot;
            if (_weaponShootPositions.Count <= slot)
            {
                return;
            }
            _ship.ShotFactory.Create(info, _weaponShootPositions[slot], transform.forward);
        }

        private void InitWeapons()
        {
            var positions = new List<Vector3>();
            var x = _weaponsRootOffset.x;
            x -= 0.5f * _weaponsSpace * (_ship.WeaponsSlots - 1);
            for (int i = 0; i < _ship.WeaponsSlots; i++)
            {
                var pos = _weaponsRootOffset;
                pos.x = x;
                x += _weaponsSpace;
                positions.Add(transform.TransformPoint(pos));
            }
            _weaponShootPositions = positions;
        }

        private void UpdateShieldState(bool isActive)
        {
            _shield.SetActive(isActive);
        }

        private void DestroyShip()
        {
            Destroy(gameObject);
        }
    }
}