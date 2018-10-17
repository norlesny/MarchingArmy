using System;
using Unity.Mathematics;
using Unity.Rendering;
using UnityEngine;

namespace Wall
{
	[Serializable]
	public struct ArrowSettings
	{
		[SerializeField] private GameObject prefab;
		[SerializeField] private float3 scale;
		[SerializeField] private float speed;

		public float3 Scale => scale;

		public MeshInstanceRenderer Renderer
		{
			get
			{
				var component = prefab.GetComponent<MeshInstanceRendererComponent>();

				if (component == null)
				{
					throw new MissingComponentException(
						$"{nameof(ArrowSettings)}: {nameof(MeshInstanceRenderer)} not found on provided arrow prefab");
				}

				return component.Value;
			}
		}

		public float Speed => speed;
	}
}