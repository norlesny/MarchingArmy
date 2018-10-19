using Common.Components;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Common.Systems
{
	// For simplicity sake, for now, it only supports down gravity force with a set power
	public sealed class GravitySystem : ComponentSystem
	{
		[Inject] private Data data;

		protected override void OnUpdate()
		{
			float velocityYChange = 9.8f * Time.deltaTime;

			for (var i = 0; i < data.Length; ++i)
			{
				float3 velocity = data.Velocity[i].Value;

				velocity.y -= velocityYChange;

				data.Velocity[i] = new Velocity {Value = velocity};
			}
		}

		private struct Data
		{
			public readonly int Length;
			public ComponentDataArray<Velocity> Velocity;
			public ComponentDataArray<AffectedByGravity> AffectedByGravity;
		}
	}
}