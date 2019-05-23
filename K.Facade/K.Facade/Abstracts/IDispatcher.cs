namespace K.Facade.Abstracts
{
	public interface IDispatcher
	{
		T GetInstance<T>();
		T GetInstance<T>(string target);
	}
}
