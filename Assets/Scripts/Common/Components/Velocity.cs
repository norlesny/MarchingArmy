using System;
using Unity.Entities;
using Unity.Mathematics;

namespace Common.Components
{
	[Serializable]
	public struct Velocity : IComponentData
	{
		public float3 Value;
	}
}