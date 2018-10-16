using Environment;
using UnityEngine;

namespace Launcher
{
	public class Launcher : MonoBehaviour
	{
		[SerializeField] private EnvironmentSettings environment;

		private void Awake()
		{
			Run();
		}

		private void Run()
		{
			new EnvironmentInstaller().Install(environment);
		}
	}
}