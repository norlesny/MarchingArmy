using System;
using Unity.Entities;
using Unity.Transforms;

namespace Common.Utils
{
	public sealed class Attacher
	{
		private readonly EntityArchetype archetype;
		private readonly EntityManager entityManager;

		public Attacher(EntityManager entityManager)
		{
			if (entityManager == null)
			{
				throw new ArgumentNullException(nameof(entityManager));
			}

			this.entityManager = entityManager;

			archetype = entityManager.CreateArchetype(typeof(Attach));
		}

		public static Attacher Instance { get; set; }

		public void Attach(Entity child, Entity parent)
		{
			Entity entity = entityManager.CreateEntity(archetype);
			entityManager.SetComponentData(entity, new Attach
			{
				Child = child,
				Parent = parent
			});
		}
	}
}