using Environment;
using UnityEngine;

namespace Launcher
{
	public class Launcher : MonoBehaviour
	{
		[SerializeField] private EnvironmentSettings environment;

		private void Awake()
		{
			Start();
		}

		private void Start()
		{
			new EnvironmentInstaller().Install(environment);
		}
	}
}