using System;
using Army.Components;
using Common.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Army.Systems
{
	public sealed class SoldiersRowSpawnSystem : ComponentSystem
	{
		private const float BaseCooldown = 0.3f;

		private static readonly int2 GroundDimension = new int2(25, 25);

		private static EntityManager entityManager;
		private static ArmySettings settings;

		[Inject] private Data data;

		public static void Initialize(EntityManager entityManager, ArmySettings armySettings)
		{
			if (entityManager == null)
			{
				throw new ArgumentNullException(nameof(entityManager));
			}

			if (armySettings == null)
			{
				throw new ArgumentNullException(nameof(armySettings));
			}

			SoldiersRowSpawnSystem.entityManager = entityManager;
			settings = armySettings;
		}

		protected override void OnUpdate()
		{
			for (var i = 0; i < data.Length; ++i)
			{
				float cooldown = data.Cooldown[i].Value;
				cooldown -= Time.deltaTime;
				bool shouldSpawn = cooldown <= 0f;

				if (shouldSpawn)
				{
					cooldown = BaseCooldown;
				}

				data.Cooldown[i] = new SoldierSpawnCooldown {Value = cooldown};

				if (shouldSpawn)
				{
					SpawnSoldiersRow();
				}
			}
		}

		private void SpawnSoldiersRow()
		{
			// TODO: Extract spawning of the soldiers to a separate class and only call it from the system
			EntityArchetype archetype =
				entityManager.CreateArchetype(typeof(Position), typeof(Velocity), typeof(XBounds));

			int numberOfSoldiers = GroundDimension.y * 2;
			for (var i = 0; i < numberOfSoldiers; ++i)
			{
				float horizontalPosition = i - numberOfSoldiers / 2f + 0.5f;
				SpawnSoldier(archetype, horizontalPosition);
			}
		}

		private void SpawnSoldier(EntityArchetype archetype, float horizontalPosition)
		{
			Entity entity = entityManager.CreateEntity(archetype);

			SoldierSettings soldier = settings.Soldier;

			var position = new float3(-GroundDimension.x, 0, horizontalPosition);
			var xBounds = new float2(-GroundDimension.x, GroundDimension.x);

			entityManager.SetComponentData(entity, new Position {Value = position});
			entityManager.SetComponentData(entity, new Velocity {Value = soldier.Forward * soldier.Speed});
			entityManager.SetComponentData(entity, new XBounds {Value = xBounds});

			entityManager.AddSharedComponentData(entity, soldier.Renderer);
		}

		private struct Data
		{
			public readonly int Length;
			public ComponentDataArray<SoldierSpawnCooldown> Cooldown;
		}
	}
}