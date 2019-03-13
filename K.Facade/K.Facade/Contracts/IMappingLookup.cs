namespace K.Facade.Contracts
{

    public interface IMappingLookup
    {
        IFactory Config(string jsonFile);
        IFactory Config(string jsonFile, IMap map);

        IFactory Config(string[] assemblies);
        IFactory Config(string[] assemblies, IMap map);
    }
}
