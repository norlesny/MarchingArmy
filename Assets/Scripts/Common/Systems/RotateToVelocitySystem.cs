using Common.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Common.Systems
{
	public sealed class RotateToVelocitySystem : ComponentSystem
	{
		[Inject] private Data data;

		protected override void OnUpdate()
		{
			var upVector = new float3(0, 1, 0);
			for (var i = 0; i < data.Length; ++i)
			{
				quaternion rotation = data.Rotation[i].Value;
				float3 velocity = data.Velocity[i].Value;

				data.Rotation[i] = new Rotation
					{Value = quaternion.LookRotation(velocity, math.mul(rotation, upVector))};
			}
		}

		private struct Data
		{
			public readonly int Length;
			public ComponentDataArray<Rotation> Rotation;
			public ComponentDataArray<Velocity> Velocity;
		}
	}
}