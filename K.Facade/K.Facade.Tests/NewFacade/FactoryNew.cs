namespace K.Facade.Tests.NewFacade
{
	public abstract class Repo
    {

    }

    public interface IUseRepo
    {
		string Name { get; }
	}

	internal class UseRepo : Repo, IUseRepo
	{
		public string Name => "UseRepo";
	}
}
