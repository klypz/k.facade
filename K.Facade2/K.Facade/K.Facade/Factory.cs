namespace K.Facade
{
	public static partial class Factory
	{
		public static FacadeFactory Domain { get; } = new DomainFactory();
	}
}
