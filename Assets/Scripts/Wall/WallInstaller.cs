using System;
using Core.Installer;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Wall.Components;
using Wall.Systems;

namespace Wall
{
	public sealed class WallInstaller : IInstaller<WallSettings>
	{
		private EntityManager entityManager;
		private WallSettings settings;

		public void Install(WallSettings settings)
		{
			if (settings == null)
			{
				throw new ArgumentNullException(nameof(settings));
			}

			entityManager = World.Active.GetOrCreateManager<EntityManager>();
			this.settings = settings;

			SpawnWall();
			InitializeArrowShooters();
		}

		private void InitializeArrowShooters()
		{
			SpawnArrowSystem.Initialize(entityManager, settings.Arrow);

			EntityArchetype archetype = entityManager.CreateArchetype(
				typeof(Position), typeof(Scale), typeof(SpawnArrow), typeof(SpawnCooldown));

			for (var i = 0; i < 1; ++i)
			{
				Entity entity = entityManager.CreateEntity(archetype);

				var position = new float3(
					settings.Position.x,
					(settings.Shooter.Scale.y + settings.Scale.y) / 2f + settings.Position.y,
					0);

				entityManager.SetComponentData(entity, new Position {Value = position});
				entityManager.SetComponentData(entity, new Scale {Value = settings.Shooter.Scale});
				entityManager.SetComponentData(entity, new SpawnCooldown {Value = 1f});

				entityManager.AddSharedComponentData(entity, settings.Shooter.Renderer);
			}
		}

		private void SpawnWall()
		{
			Entity entity = entityManager.CreateEntity(typeof(Position), typeof(Scale));

			entityManager.SetComponentData(entity, new Position {Value = settings.Position});
			entityManager.SetComponentData(entity, new Scale {Value = settings.Scale});

			entityManager.AddSharedComponentData(entity, settings.Renderer);
		}
	}
}