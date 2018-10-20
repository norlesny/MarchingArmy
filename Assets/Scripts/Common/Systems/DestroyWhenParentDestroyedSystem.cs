using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Common.Systems
{
	public sealed class DestroyWhenParentDestroyedSystem : ComponentSystem
	{
		[Inject] private Data data;

		protected override void OnUpdate()
		{
			float deltaTime = Time.deltaTime;
			for (var i = 0; i < data.Length; ++i)
			{
				Entity parent = data.Parent[i].Value;
				
			}
		}

		private struct Data
		{
			public readonly int Length;
			public EntityArray Entity;
			public ComponentDataArray<Parent> Parent;
		}
	}
}