using Army;
using Environment;
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
			new EnvironmentInstaller().Install(environment);
//			new ArmyInstaller().Install(army);
			new WallInstaller().Install(wall);
		}
	}
}