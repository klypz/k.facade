namespace K.Facade.Data
{
	public static class FacadeFactory
	{
		public static IRepositoryFactory Repository { get; } = new RepositoryFactory();
	}
}
