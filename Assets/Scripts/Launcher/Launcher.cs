using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Launcher
{
	public class Launcher : MonoBehaviour
	{
		private EntityArchetype archetype;
		private EntityManager entityManager;
		private MeshInstanceRenderer renderer;

		private void Awake()
		{
			entityManager = World.Active.GetOrCreateManager<EntityManager>();

			archetype = entityManager.CreateArchetype(typeof(Position));

			renderer = FindObjectOfType<MeshInstanceRendererComponent>().Value;

			for (var i = 0; i < 10000; i++)
			{
				SpawnCube();
			}
		}

		private void SpawnCube()
		{
			Entity entity = entityManager.CreateEntity(archetype);

			var position = new float3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));

			entityManager.SetComponentData(entity, new Position {Value = position});

			entityManager.AddSharedComponentData(entity, renderer);
		}
	}
}