using System;
using Unity.Entities;

namespace Common.Components
{
	[Serializable]
	public struct DestroyCooldown : IComponentData
	{
		public float Value;
	}
}