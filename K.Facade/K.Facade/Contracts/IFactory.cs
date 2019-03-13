namespace K.Facade.Contracts
{
    public interface IFactory
    {
        T GetInstance<T>();
        T GetInstance<T>(string target);
        bool HasInstance<T>();
        bool HasInstance<T>(string target);
        bool TryGetInstance<T>(out T output);
        bool TryGetInstance<T>(string target, out T output);
    }
}
