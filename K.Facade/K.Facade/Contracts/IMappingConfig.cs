using System;

namespace K.Facade.Contracts
{
    public interface IMappingConfig
    {
        IFactory Config(Action<IMap> action);
        IFactory Config(Action<IMap> action, IMap map);
    }
}
