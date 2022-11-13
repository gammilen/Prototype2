using UnityEngine;
using Ships.Core;

namespace Ships.Game
{
	[CreateAssetMenu(fileName = "StatModule", menuName = "Data/Stat Module")]
	public class StatModuleData : ScriptableObject, IStatModuleData
	{
		[field: SerializeField] public string Name { get; private set; }
		[field: SerializeField] public Stat Stat { get; private set; }
		[field: SerializeField] public Mod Modification { get; private set; }
		[field: SerializeField, Tooltip("Absolute value for Abs. Percentage for pct (1 = 100%)")] 
		public float ModificationValue { get; private set; }
	}
}