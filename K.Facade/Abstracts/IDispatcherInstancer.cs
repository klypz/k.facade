using K.Facade.Mapper;

namespace K.Facade.Abstracts
{
	public interface IDispatcherInstancer
	{
		object GetInstance(Mapping mapping);
	}
}
