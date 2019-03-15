namespace K.Facade
{
    public interface IFactory
    {
        IMappingConfig MappingConfig { get; }

        T GetInstance<T>();
        T GetInstance<T>(string target);
    }
}