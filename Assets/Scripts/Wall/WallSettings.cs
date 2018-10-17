using Unity.Mathematics;
using Unity.Rendering;
using UnityEngine;

namespace Wall
{
	[CreateAssetMenu(menuName = "Marching Army/Wall Settings")]
	public sealed class WallSettings : ScriptableObject
	{
		[SerializeField] private ArrowSettings arrow;
		[SerializeField] private float3 position;
		[SerializeField] private GameObject prefab;
		[SerializeField] private float3 scale;
		[SerializeField] private ArrowShooterSettings shooter;

		public MeshInstanceRenderer Renderer
		{
			get
			{
				var component = prefab.GetComponent<MeshInstanceRendererComponent>();

				if (component == null)
				{
					throw new MissingComponentException(
						$"{nameof(WallSettings)}: {nameof(MeshInstanceRenderer)} not found on provided wall prefab");
				}

				return component.Value;
			}
		}


		public float3 Position => position;

		public float3 Scale => scale;

		public ArrowShooterSettings Shooter => shooter;

		public ArrowSettings Arrow => arrow;
	}
}