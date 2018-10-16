using Unity.Rendering;
using UnityEngine;

namespace Environment
{
	[CreateAssetMenu(menuName = "Marching Army/Environment Settings")]
	public sealed class EnvironmentSettings : ScriptableObject
	{
		[SerializeField] private GameObject ground;

		public MeshInstanceRenderer GroundRenderer
		{
			get
			{
				var component = ground.GetComponent<MeshInstanceRendererComponent>();

				if (component == null)
				{
					throw new MissingComponentException(
						$"{nameof(EnvironmentSettings)}: {nameof(MeshInstanceRenderer)} not found on provided ground object");
				}

				return component.Value;
			}
		}
	}
}