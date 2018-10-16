using System;
using Common.Components;
using Core.Installer;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Army
{
	public sealed class ArmyInstaller : IInstaller<ArmySettings>
	{
		private static readonly int2 GroundDimension = new int2(25, 25);

		private EntityManager entityManager;
		private ArmySettings settings;

		public void Install(ArmySettings settings)
		{
			if (settings == null)
			{
				throw new ArgumentNullException(nameof(settings));
			}

			entityManager = World.Active.GetOrCreateManager<EntityManager>();
			this.settings = settings;

			SpawnSoldiers();
		}

		private void SpawnSoldiers()
		{
			EntityArchetype archetype = entityManager.CreateArchetype(typeof(Position), typeof(Heading), typeof(Speed));

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

			entityManager.SetComponentData(entity, new Position {Value = position});
			entityManager.SetComponentData(entity, new Heading {Value = soldier.Forward});
			entityManager.SetComponentData(entity, new Speed {Value = soldier.Speed});

			entityManager.AddSharedComponentData(entity, soldier.Renderer);
		}
	}
}