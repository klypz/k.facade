using K.Facade.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace K.Facade
{
    public static class Factory
    {
        private static MappingConfig mappingConfig = new MappingConfig();
        private static Mapping Mapping { get; set; } = new Mapping();
        public static T GetInstance<T>()
        {
            return Mapping.GetInstance<T>();
        }

        public static T GetInstance<T>(string target)
        {
            return Mapping.GetInstance<T>(target);
        }

        public static void Config(Action<IMap> action)
        {
            mappingConfig.Config(action, Mapping);
        }
    }
}
