namespace K.Facade.Structure
{
	public interface IFacadeFactory
	{
		T GetInstance<T>();
		T GetInstance<T>(string target);
	}
}
