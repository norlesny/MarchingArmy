using UnityEngine;

namespace Army
{
	[CreateAssetMenu(menuName = "Marching Army/Army Settings")]
	public sealed class ArmySettings : ScriptableObject
	{
		[SerializeField] private SoldierSettings soldier;

		public SoldierSettings Soldier => soldier;
	}
}