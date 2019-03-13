using K.Facade.Contracts;
using System;
using System.Linq;

namespace K.Facade
{

    public sealed class MappingConfig : IMappingConfig
    {
        public IFactory Config(Action<IMap> action)
        {
            return Config(action, new Mapping());
        }

        public IFactory Config(Action<IMap> action, IMap map)
        {
            if(typeof(Mapping) != map.GetType())
            {
                throw new InvalidCastException();
            }

            action.Invoke(map);
            return (IFactory)map;
        }
    }
}
