namespace Core.Installer
{
	public interface IInstaller<in TArg1> : IInstaller
	{
		void Install(TArg1 arg1);
	}
}