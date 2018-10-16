using System;
using Unity.Entities;

namespace Army.Components
{
	[Serializable]
	public struct SoldierSpawnCooldown : IComponentData
	{
		public float Value;
	}
}