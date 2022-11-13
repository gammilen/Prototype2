using UnityEditor;
using UnityEngine;
using Ships.Core;

namespace Ships.Game
{
    [CreateAssetMenu(fileName = "ShipsConfiguration", menuName = "Game Data/Ships Configuration")]
    public class ShipsConfiguration : ScriptableObject
    {
        [field: SerializeField] public float RealDistanceMultiplier { get; private set; }
        [field: SerializeField] public float ShipRadius { get; private set; }
        [field: SerializeField] public ShipView ShipPrefab { get; private set; }
        [field: SerializeField] public ShotView ShotPrefab { get; private set; }
    }
}