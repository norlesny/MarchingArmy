using System;
using Unity.Mathematics;
using Unity.Rendering;
using UnityEngine;

namespace Environment
{
	[Serializable]
	public struct GroundSettings
	{
		[SerializeField] private GameObject prefab;
		[SerializeField] private float3 position;
		[SerializeField] private float3 scale;

		public float3 Scale => scale;

		public float3 Position => position;

		public MeshInstanceRenderer GroundRenderer
		{
			get
			{
				var component = prefab.GetComponent<MeshInstanceRendererComponent>();

				if (component == null)
				{
					throw new MissingComponentException(
						$"{nameof(EnvironmentSettings)}: {nameof(MeshInstanceRenderer)} not found on provided ground prefab");
				}

				return component.Value;
			}
		}
	}
}