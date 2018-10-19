using System;
using Common.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Wall.Components;

namespace Wall.Systems
{
	public sealed class SpawnArrowSystem : ComponentSystem
	{
		private const float BaseCooldown = 1f;

		private static EntityManager entityManager;

		// TODO: This could be passed in the `SpawnArrow` component instead, it would allow for an easy way to spawn different types of arrows
		private static ArrowSettings settings;

		[Inject] private Data data;

		public static void Initialize(EntityManager entityManager, ArrowSettings settings)
		{
			if (entityManager == null)
			{
				throw new ArgumentNullException(nameof(entityManager));
			}

			SpawnArrowSystem.entityManager = entityManager;
			SpawnArrowSystem.settings = settings;
		}

		protected override void OnUpdate()
		{
			float deltaTime = Time.deltaTime;

			for (var i = 0; i < data.Length; ++i)
			{
				float cooldown = data.Cooldown[i].Value;
				cooldown -= deltaTime;
				bool shouldSpawn = cooldown <= 0f;

				if (shouldSpawn)
				{
					cooldown = BaseCooldown;
				}

				data.Cooldown[i] = new SpawnCooldown {Value = cooldown};

				if (shouldSpawn)
				{
					SpawnArrow();
				}
			}
		}

		private void SpawnArrow()
		{
			// TODO: Extract spawning of the arrow to a separate class and only call it from the system
			EntityArchetype archetype = entityManager.CreateArchetype(typeof(Position), typeof(Rotation),
				typeof(Velocity), typeof(Scale), typeof(DestroyCooldown), typeof(AffectedByGravity), typeof(Attached));

			for (var i = 0; i < 1; ++i)
			{
				Entity entity = entityManager.CreateEntity(archetype);

				// TODO: Arrows should be shot from the shooters (get position, heading and speed)
				var position = new float3(25, 9.5f, 0);
				var heading = new float3(-1, 0, 0);

				entityManager.SetComponentData(entity, new Position {Value = position});
				entityManager.SetComponentData(entity, new Velocity {Value = heading * settings.Speed});
				entityManager.SetComponentData(entity, new Scale {Value = settings.Scale});
				entityManager.SetComponentData(entity, new DestroyCooldown {Value = 5f});

				entityManager.AddSharedComponentData(entity, settings.Renderer);
			}
		}

		private struct Data
		{
			public readonly int Length;
			public ComponentDataArray<SpawnArrow> SpawnArrow;
			public ComponentDataArray<SpawnCooldown> Cooldown;
		}
	}
}