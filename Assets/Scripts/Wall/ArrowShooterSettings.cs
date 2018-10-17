using System;
using Unity.Mathematics;
using Unity.Rendering;
using UnityEngine;

namespace Wall
{
	[Serializable]
	public struct ArrowShooterSettings
	{
		[SerializeField] private GameObject prefab;
		[SerializeField] private float3 scale;

		public MeshInstanceRenderer Renderer
		{
			get
			{
				var component = prefab.GetComponent<MeshInstanceRendererComponent>();

				if (component == null)
				{
					throw new MissingComponentException(
						$"{nameof(ArrowShooterSettings)}: {nameof(MeshInstanceRenderer)} not found on provided shooter prefab");
				}

				return component.Value;
			}
		}

		public float3 Scale => scale;
	}
}