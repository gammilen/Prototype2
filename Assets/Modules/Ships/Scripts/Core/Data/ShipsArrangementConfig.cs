using System;
using UnityEngine;

namespace Ships.Core
{
    [CreateAssetMenu(fileName = "ShipsArrangement", menuName = "Data/Ships Arrangement")]
    public class ShipsArrangementConfig : ScriptableObject
    {
        [field: SerializeField] public float BaseDistance { get; private set; }

#if UNITY_EDITOR
        private void OnValidate()
        {
            BaseDistance = Math.Max(0, BaseDistance);
        }
#endif
    }
}