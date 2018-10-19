using Common.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Common.Systems
{
	public sealed class VelocityMovementSystem : ComponentSystem
	{
		[Inject] private Data data;

		protected override void OnUpdate()
		{
			float deltaTime = Time.deltaTime;
			for (var i = 0; i < data.Length; ++i)
			{
				float3 position = data.Position[i].Value;
				float3 velocity = data.Velocity[i].Value;

				position += velocity * deltaTime;

				data.Position[i] = new Position {Value = position};
			}
		}

		private struct Data
		{
			public readonly int Length;
			public ComponentDataArray<Position> Position;
			public ComponentDataArray<Velocity> Velocity;
		}
	}
}