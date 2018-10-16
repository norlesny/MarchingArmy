using System;
using Unity.Entities;
using Unity.Mathematics;

namespace Common.Components
{
	[Serializable]
	public struct XBounds : IComponentData
	{
		public float2 Value;
	}
}