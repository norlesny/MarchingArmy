using System;
using Core.Installer;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Environment
{
	public sealed class EnvironmentInstaller : IInstaller<EnvironmentSettings>
	{
		private EntityManager entityManager;
		private EnvironmentSettings settings;

		public void Install(EnvironmentSettings settings)
		{
			if (settings == null)
			{
				throw new ArgumentNullException(nameof(settings));
			}

			entityManager = World.Active.GetOrCreateManager<EntityManager>();
			this.settings = settings;

			SpawnGround();
		}

		private void SpawnGround()
		{
			Entity entity = entityManager.CreateEntity(typeof(Position), typeof(Scale));

			entityManager.SetComponentData(entity, new Position {Value = float3.zero});
			entityManager.SetComponentData(entity, new Scale {Value = new float3(1f, 1f, 1f)});

			entityManager.AddSharedComponentData(entity, settings.GroundRenderer);
		}
	}
}