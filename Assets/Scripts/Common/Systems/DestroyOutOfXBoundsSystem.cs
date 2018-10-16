using Common.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Common.Systems
{
	public sealed class DestroyOutOfXBoundsSystem : ComponentSystem
	{
		[Inject] private Data data;

		protected override void OnUpdate()
		{
			for (var i = 0; i < data.Length; ++i)
			{
				float3 position = data.Position[i].Value;
				float2 bound = data.XBounds[i].Value;

				if (position.x < bound.x || position.x > bound.y)
				{
					PostUpdateCommands.DestroyEntity(data.Entities[i]);
				}
			}
		}

		private struct Data
		{
			public readonly int Length;
			public EntityArray Entities;
			public ComponentDataArray<Position> Position;
			public ComponentDataArray<XBounds> XBounds;
		}
	}
}