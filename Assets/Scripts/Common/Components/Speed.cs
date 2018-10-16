using System;
using Unity.Entities;

namespace Common.Components
{
	[Serializable]
	public struct Speed : IComponentData
	{
		public float Value;
	}
}