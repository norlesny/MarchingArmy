using System;
using Unity.Entities;

namespace Wall.Components
{
	[Serializable]
	public struct SpawnCooldown : IComponentData
	{
		public float Value;
	}
}