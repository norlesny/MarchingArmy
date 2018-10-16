using System;
using Common.Components;
using Core.Installer;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Army
{
	public sealed class ArmyInstaller : IInstaller<SoldierSettings>
	{
		private EntityManager entityManager;
		private SoldierSettings settings;

		public void Install(SoldierSettings settings)
		{
			if (settings == null)
			{
				throw new ArgumentNullException(nameof(settings));
			}

			entityManager = World.Active.GetOrCreateManager<EntityManager>();
			this.settings = settings;

			SpawnSoldier();
		}

		private void SpawnSoldier()
		{
			Entity entity = entityManager.CreateEntity(typeof(Position), typeof(Heading), typeof(Speed));

			entityManager.SetComponentData(entity, new Position {Value = float3.zero});
			entityManager.SetComponentData(entity, new Heading {Value = settings.Forward});
			entityManager.SetComponentData(entity, new Speed {Value = settings.Speed});

			entityManager.AddSharedComponentData(entity, settings.SoldierRenderer);
		}
	}
}