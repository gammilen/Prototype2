using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Ships.Core;

namespace Ships.Game
{
    public class ShotFactory
    {
        private readonly ShipsConfiguration _shipsConfiguration;
        private readonly ShotsPool _shotsPool = new();

        public ShotFactory(ShipsConfiguration shipsConfiguration)
        {
            _shipsConfiguration = shipsConfiguration;
        }
        public Shot Create(ShotInFlight shotData, Vector3 position, Vector3 direction)
        {
            var realSpeed = shotData.Shot.Speed * _shipsConfiguration.RealDistanceMultiplier;
            var shot = new Shot(shotData, realSpeed);
            var shotView = _shotsPool.GetShotView(_shipsConfiguration.ShotPrefab);
            shotView.Init(shot, position, direction);
            return shot;
        }
    }

    public class ShotsPool
    {
        private Dictionary<ShotView, List<ShotView>> _pool = new();

        public ShotView GetShotView(ShotView origin)
        {
            if (_pool.ContainsKey(origin))
            {
                foreach (var poolView in _pool[origin])
                {
                    if (!poolView.gameObject.activeSelf)
                    {
                        poolView.gameObject.SetActive(true);
                        return poolView;
                    }
                }
            }
            else
            {
                _pool.Add(origin, new List<ShotView>());
            }
            var view = Object.Instantiate(origin);
            _pool[origin].Add(view);
            return view;
        }
    }
}