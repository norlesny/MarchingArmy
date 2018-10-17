using System;
using Core.Installer;
using Unity.Entities;
using Unity.Transforms;

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
		}

		private void SpawnWall()
		{
			Entity entity = entityManager.CreateEntity(typeof(Position), typeof(Scale));
			
			entityManager.SetComponentData(entity, new Position{Value = settings.Position});
			entityManager.SetComponentData(entity, new Scale{Value = settings.Scale});
			
			entityManager.AddSharedComponentData(entity, settings.Renderer);
		}
	}
}