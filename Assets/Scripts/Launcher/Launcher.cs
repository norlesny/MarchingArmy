using Army;
using Common.Utils;
using Environment;
using Unity.Entities;
using UnityEngine;
using Wall;

namespace Launcher
{
	public class Launcher : MonoBehaviour
	{
		[SerializeField] private ArmySettings army;
		[SerializeField] private EnvironmentSettings environment;
		[SerializeField] private WallSettings wall;

		private void Awake()
		{
			Run();
		}

		private void Run()
		{
			Attacher.Instance = new Attacher(World.Active.GetOrCreateManager<EntityManager>());
			
			new EnvironmentInstaller().Install(environment);
			new ArmyInstaller().Install(army);
			new WallInstaller().Install(wall);
		}
	}
}