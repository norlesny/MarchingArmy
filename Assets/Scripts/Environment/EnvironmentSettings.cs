using UnityEngine;

namespace Environment
{
	[CreateAssetMenu(menuName = "Marching Army/Environment Settings")]
	public sealed class EnvironmentSettings : ScriptableObject
	{
		[SerializeField] private GroundSettings ground;

		public GroundSettings Ground => ground;
	}
}