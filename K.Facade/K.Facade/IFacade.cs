namespace K.Facade
{
	public interface IFactory
	{
		T GetInstance<T>();
		T GetInstance<T>(string target);
		
		IFactoryMapping Map { get; }
	}
}
