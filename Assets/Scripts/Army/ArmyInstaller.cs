using System;
using Army.Components;
using Army.Systems;
using Core.Installer;
using Unity.Entities;

namespace Army
{
	public sealed class ArmyInstaller : IInstaller<ArmySettings>
	{
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

			InitializeSystems();
		}

		private void InitializeSystems()
		{
			InitializeSpawnSystem();
		}

		private void InitializeSpawnSystem()
		{
			SoldiersRowSpawnSystem.Initialize(entityManager, settings);

			Entity entity = entityManager.CreateEntity(typeof(SoldierSpawnCooldown));
			entityManager.SetComponentData(entity, new SoldierSpawnCooldown {Value = 0f});
		}
	}
}