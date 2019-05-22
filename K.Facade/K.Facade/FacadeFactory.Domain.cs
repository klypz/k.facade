using K.Facade.DomainService;

namespace K.Facade
{
	public static partial class FacadeFactory
	{
		public static IFactory Domain { get; } = new DomainFactory();
	}
}
