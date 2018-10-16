using Common.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Common.Systems
{
	public sealed class MoveForwardSystem : ComponentSystem
	{
		[Inject] private Data data;

		protected override void OnUpdate()
		{
			float deltaTime = Time.deltaTime;
			for (var i = 0; i < data.Length; ++i)
			{
				float3 position = data.Position[i].Value;
				float3 heading = data.Heading[i].Value;
				float speed = data.Speed[i].Value;

				position += heading * speed * deltaTime;

				data.Position[i] = new Position {Value = position};
			}
		}

		private struct Data
		{
			public readonly int Length;
			public ComponentDataArray<Position> Position;
			public ComponentDataArray<Heading> Heading;
			public ComponentDataArray<Speed> Speed;
		}
	}
}