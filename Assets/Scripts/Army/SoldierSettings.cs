using System;
using Environment;
using Unity.Mathematics;
using Unity.Rendering;
using UnityEngine;

namespace Army
{
	[Serializable]
	public struct SoldierSettings
	{
		[SerializeField] private float3 forward;
		[SerializeField] private GameObject prefab;
		[SerializeField] private float speed;

		public MeshInstanceRenderer Renderer
		{
			get
			{
				var component = prefab.GetComponent<MeshInstanceRendererComponent>();

				if (component == null)
				{
					throw new MissingComponentException(
						$"{nameof(EnvironmentSettings)}: {nameof(MeshInstanceRenderer)} not found on provided soldier prefab");
				}

				return component.Value;
			}
		}

		public float3 Forward => math.normalize(forward);

		public float Speed => speed;
	}
}